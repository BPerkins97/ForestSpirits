const gameScreen = document.getElementById("game-container");
const fieldContainer = document.getElementById("field-container");
const inventarElement = document.getElementById("inventar-container");
const inventarWaterCounter = document.getElementById("inventar-water");
const inventarSunCounter = document.getElementById("inventar-sun");
const inventarSeedlingCounter = document.getElementById("inventar-seedling");

const progressBarWater = document.getElementById("progress-bar-water");
const progressBarSun = document.getElementById("progress-bar-sun");
const progressBarProgress = document.getElementById("progress-bar-progress");
const fieldContextInfo = document.getElementById("field-context-info");
const gameInfoCo2 = document.getElementById("game-info-co2");
const gameInfoTime = document.getElementById("game-info-time");
fieldContextInfo.style.display = "none";

const GAME_CONFIG = {
    resourceAdmissionRate: 100
};

const WIDTH_TO_HEIGHT = 829.0 / 718.0;
const FIELD_WIDTH = 100.0;
const FIELD_HEIGHT = FIELD_WIDTH * WIDTH_TO_HEIGHT;
const FIELD_HEIGHT_DIFF = FIELD_HEIGHT * 0.75;
const FIELD_ROWS = 7;
const FIELD_COLUMNS = 10;

let fields = [];
let lastGameState = {};
let gameState = {
    isSun: false,
    isWater: false,
    inventar: {
        sun: 0,
        water: 0,
        seedling: 3
    }
};
let drag = undefined;

fieldContainer.addEventListener("mousemove", function(event) {
    if(drag) {
        drag.element.style.top = event.y + "px";
        drag.element.style.left = event.x + "px";
    }
});

fieldContainer.addEventListener("click", function(event) {
    fieldContextInfo.style.display = "none";
    const coordinate = pointToCoordinate(toPoint(event.x, event.y));
    if (!coordinate) {
        if (drag) {
            fieldContainer.removeChild(drag.element);
        }
        return;
    }
    if (drag) {
        if (drag.type === "sun") {
            reduceInventarSun();
            fields[coordinate.row][coordinate.column].sun += 50;
            updateFieldType(coordinate);         
        } else if (drag.type === "water") {
            reduceInventarWater();
            fields[coordinate.row][coordinate.column].water += 50;
            updateFieldType(coordinate);   
        } else if (drag.type === "seedling" && fields[coordinate.row][coordinate.column].type === "field-ripe") {
            reduceInventarSeedling();
            updateField(coordinate, "field-seedling");
        }

        fieldContainer.removeChild(drag.element);
        drag = undefined;
    } else if (isField(event.target)) {
        progressBarSun.value = fields[coordinate.row][coordinate.column].sun;
        progressBarWater.value = fields[coordinate.row][coordinate.column].water;
        progressBarProgress.value = fields[coordinate.row][coordinate.column].progress;
        fieldContextInfo.style.top = event.y + "px";
        fieldContextInfo.style.left = event.x + "px";
        fieldContextInfo.style.display = "block";
    } else {

    }
});

function isField(element) {
    const classes = element.classList;
    for (let i=0;i<classes.length;i++) {
        if (classes[i] === "field") {
            return true;
        }
    }
    return false;
}

function reduceInventarSeedling() {
    gameState.inventar.seedling--;
    inventarSeedlingCounter.innerText = gameState.inventar.seedling;
}

function updateFieldType(coordinate) {
    if (fields[coordinate.row][coordinate.column].water > 0 && fields[coordinate.row][coordinate.column].sun > 0) {
        const type = fields[coordinate.row][coordinate.column].type;
        fields[coordinate.row][coordinate.column].sun -= 50;
        fields[coordinate.row][coordinate.column].water -= 50;
        if (type === "field-normal") {
            updateField(coordinate, "field-half-ripe");
        } else if (type === "field-half-ripe") {
            updateField(coordinate, "field-ripe");
        }            
    }
}

document.getElementById("inventar-sun-container").addEventListener("click", function(event) {
    if (gameState.inventar.sun <= 0) {
        return;
    }
    let element = document.createElement("div");
    element.classList.add("sun");
    element.classList.add("drag");
    element.style.top = event.y + "px";
    element.style.left = event.x + "px";
    drag = {
        element: element,
        type: "sun"
    }
    fieldContainer.appendChild(element);
});

document.getElementById("inventar-water-container").addEventListener("click", function(event) {
    if (gameState.inventar.water <= 0) {
        return;
    }
    let element = document.createElement("div");
    element.classList.add("water");
    element.classList.add("drag");
    element.style.top = event.y + "px";
    element.style.left = event.x + "px";
    drag = {
        element: element,
        type: "water"
    }
    fieldContainer.appendChild(element);
});

document.getElementById("inventar-seedling-container").addEventListener("click", function(event) {
    if (gameState.inventar.seedling <= 0) {
        return;
    }
    let element = document.createElement("div");
    element.classList.add("seedling");
    element.classList.add("drag");
    element.style.top = event.y + "px";
    element.style.left = event.x + "px";
    drag = {
        element: element,
        type: "seedling"
    }
    fieldContainer.appendChild(element);
});

gameLoop();

function reduceInventarWater() {
    gameState.inventar.water--;
    inventarWaterCounter.innerText = gameState.inventar.water;
}

function reduceInventarSun() {
    gameState.inventar.sun--;
    inventarSunCounter.innerText = gameState.inventar.sun;
}

async function gameLoop() {
    initField();
    updateField(toCoordinate(0, 0), "field-seedling");
    updateField(toCoordinate(FIELD_ROWS-1, FIELD_COLUMNS-1), "field-city");
    for (let i = 0;i<100;i++) {
        lastGameState = JSON.parse(JSON.stringify(gameState));
        fieldContainer.children = [];
        update();
        redraw();
        await Sleep(1000.0);
    }
}

function update() {
    gameState.isSun = lastGameState.isSun || Math.random() < 1;
    gameState.isWater = lastGameState.isWater || Math.random() < 1;
    if (Math.random() < 0.1) {
        expandCity();
    }
    for (let i=0;i<fields.length;i++) {
        for (let j=0;j<fields[i].length;j++) {
            if (fields[i][j].type === "field-seedling") {
                if (fields[i][j].progress >= 100) {
                    updateField(toCoordinate(i, j), "field-tree");
                } else if (fields[i][j].sun >= 100 && fields[i][j].water >= 100) {
                    fields[i][j].progress = Math.min(fields[i][j].progress + GAME_CONFIG.resourceAdmissionRate, 100);
                } else {
                    fields[i][j].sun = Math.min(fields[i][j].sun + GAME_CONFIG.resourceAdmissionRate, 100);
                    fields[i][j].water = Math.min(fields[i][j].water + GAME_CONFIG.resourceAdmissionRate, 100);
                }
            }
        }
    }
}

// TODO das hier besser machen, dass die stadt in alle Richtungen ausbreitet
function expandCity() {
    for (let i=0;i<fields.length;i++) {
        for (let j=0;j<fields[i].length;j++) {
            if (fields[i][j].type === "field-city") {
                if (i-1 >= 0) {
                    if (fields[i-1][j].type === "field-normal") {
                        updateField(toCoordinate(i-1,j), "field-city");
                        return;
                    }
                    if (j+1 < FIELD_COLUMNS) {
                        if (fields[i-1][j+1].type === "field-normal") {
                            updateField(toCoordinate(i-1,j+1), "field-city");
                            return;
                        }
                    }
                }
                if (j-1 >= 0) {
                    if (fields[i][j-1].type === "field-normal") {
                        updateField(toCoordinate(i,j-1), "field-city");
                        return;
                    }
                }
                if (j+1 < FIELD_COLUMNS) {
                    if (fields[i][j+1].type === "field-normal") {
                        updateField(toCoordinate(i,j+1), "field-city");
                        return;
                    }
                }
                if (i+1 < FIELD_ROWS) {
                    if (fields[i+1][j].type === "field-normal") {
                        updateField(toCoordinate(i+1,j), "field-city");
                        return;
                    }
                    if (j+1 < FIELD_COLUMNS) {
                        if (fields[i+1][j+1].type === "field-normal") {
                            updateField(toCoordinate(i+1,j+1), "field-city");
                            return;
                        }
                    
                    }
                }
            }
        }
    }
}

function Sleep(milliseconds) {
    return new Promise(resolve => setTimeout(resolve, milliseconds));
}

function redraw() {
    if (gameState.isSun && !lastGameState.isSun) {
        console.log("hello");
        let point = coordinateToPoint(toCoordinate(FIELD_ROWS, FIELD_COLUMNS));
        point = toPoint(Math.random() * point.x, Math.random() * point.y);
        let temp = document.createElement("div");
        temp.classList.add("sun");
        temp.classList.add("resource");
        temp.id = "sun";
        temp.style.top = point.y + "px";
        temp.style.left = point.x + "px";
        temp.addEventListener("click", collectSun);
        fieldContainer.appendChild(temp);
    }
    if (gameState.isWater && !lastGameState.isWater) {
        let point = coordinateToPoint(toCoordinate(FIELD_ROWS, FIELD_COLUMNS));
        point = toPoint(Math.random() * point.x, Math.random() * point.y);
        let temp = document.createElement("div");
        temp.classList.add("water");
        temp.classList.add("resource");
        temp.id = "water";
        temp.style.top = point.y + "px";
        temp.style.left = point.x + "px";
        temp.addEventListener("click", collectWater);
        fieldContainer.appendChild(temp);
    }
    for (let i=0;i<fields.length;i++) {
        for (let j=0;j<fields[i].length;j++) {
            updateField(toCoordinate(i, j), fields[i][j].type);
        }
    }
}

function collectSun(event) {
    fieldContainer.removeChild(event.srcElement);
    gameState.inventar.sun++;
    gameState.isSun = false;
    inventarSunCounter.innerText = gameState.inventar.sun;
}

function collectWater(event) {
    fieldContainer.removeChild(event.srcElement);
    gameState.inventar.water++;
    gameState.isWater = false;
    inventarWaterCounter.innerText = gameState.inventar.water;
}

function initField() {
    for (let i=0;i<FIELD_ROWS;i++) {
        fields[i] = [];
        for (let j=0;j<FIELD_COLUMNS;j++) {
            fields[i][j] = {
                element: undefined,
                sun: 0,
                water: 0,
                progress: 0,
                type: "field-normal"
            };
            updateField(toCoordinate(i, j), "field-normal");
        }
    }
}

function updateField(coordinate, fieldType) {
    if (fields[coordinate.row][coordinate.column].element) {
        fieldContainer.removeChild(fields[coordinate.row][coordinate.column].element);
    }
    let temp = document.createElement("div");
    temp.classList.add("field");
    temp.classList.add(fieldType);
    const point = coordinateToPoint(coordinate);
    temp.style.top = point.y + "px";
    temp.style.left = point.x + "px";
    fieldContainer.appendChild(temp);
    fields[coordinate.row][coordinate.column].element = temp;
    fields[coordinate.row][coordinate.column].type = fieldType;
}

function coordinateToPoint(coordinate) {
    if (coordinate.row % 2 === 0) {
        return toPoint(
            coordinate.column * FIELD_WIDTH,
            coordinate.row * FIELD_HEIGHT_DIFF
        ); 
    } else {
        return toPoint(
            coordinate.column * FIELD_WIDTH + FIELD_WIDTH / 2.0,
            coordinate.row * FIELD_HEIGHT_DIFF
        );
    }
}

function toCoordinate(row, column) {
    return {
        row: parseInt(row),
        column: parseInt(column)
    }
}

function toPoint(x, y) {
    return {
        x: parseInt(x),
        y: parseInt(y)
    }
}

function pointToCoordinate(point) {
    for (let row=0;row<FIELD_ROWS;row++) {
        for (let column=0;column<FIELD_COLUMNS;column++) {
            if (hasBeenClicked(row, column, point)) {
                return toCoordinate(row, column);
            }
        }
    }
}

function hasBeenClicked(row, column, point) {
    const xBase = row % 2 == 0 ? 0 : FIELD_WIDTH / 2.0;
    const lowerLeft = toPoint(xBase + column * FIELD_WIDTH, (row+1) * 0.75 * FIELD_HEIGHT);
    const lower = toPoint(xBase + FIELD_WIDTH / 2.0 + column * FIELD_WIDTH, FIELD_HEIGHT + row * 0.75 * FIELD_HEIGHT);
    //const lowerRight = toPoint(xBase + column * FIELD_WIDTH + FIELD_WIDTH, (row+1) * 0.75 * FIELD_HEIGHT);

    if (point.x > xBase + FIELD_WIDTH + column * FIELD_WIDTH || point.x < xBase + column * FIELD_WIDTH) {
        return false;
    }

    let steigung = (lower.y - lowerLeft.y) / (lower.x - lowerLeft.x);
    let basis = steigung * lower.x * -1 + lower.y;
    let shouldBeY = steigung * point.x + basis;

    if (point.y > shouldBeY || point.y < shouldBeY - FIELD_HEIGHT)
    {
        return false;
    }

    steigung = -steigung;
    basis = steigung * lower.x * -1 + lower.y;

    shouldBeY = steigung * point.x + basis;
    if (point.y > shouldBeY || point.y < shouldBeY - FIELD_HEIGHT)
    {
        return false;
    }

    return true;
}