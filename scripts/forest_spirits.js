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

const WIDTH_TO_HEIGHT = 829.0 / 718.0;
const FIELD_WIDTH = 100.0;
const FIELD_HEIGHT = FIELD_WIDTH * WIDTH_TO_HEIGHT;
const FIELD_HEIGHT_DIFF = FIELD_HEIGHT * 0.75;

let fieldElements;
let lastGameState;
let gameState;
let drag = null;

play();

async function play () {
    forestSpiritsAPI.initialize(gameSettings);
    gameState = forestSpiritsAPI.getGameState();
    initfieldElements();
    while (!forestSpiritsAPI.isGameOver()) {
        lastGameState = JSON.parse(JSON.stringify(gameState));;
        forestSpiritsAPI.tick();
        gameState = forestSpiritsAPI.getGameState();
        redraw();
        await Sleep(100.0);
    }
}

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
            forestSpiritsAPI.feedSun(coordinate.row, coordinate.column);       
        } else if (drag.type === "water") {
            forestSpiritsAPI.feedWater(coordinate.row, coordinate.column);  
        } else if (drag.type === "seedling" && gameState.fields[coordinate.row][coordinate.column].type === forestSpiritsConstants.fieldTypes.ripe) {
            forestSpiritsAPI.plantSeedling(coordinate.row, coordinate.column);
        }

        fieldContainer.removeChild(drag.element);
        drag = undefined;
    } else if (isField(event.target)) {
        progressBarSun.value = gameState.fields[coordinate.row][coordinate.column].sun;
        progressBarWater.value = gameState.fields[coordinate.row][coordinate.column].water;
        progressBarProgress.value = gameState.fields[coordinate.row][coordinate.column].progress;
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

function Sleep(milliseconds) {
    return new Promise(resolve => setTimeout(resolve, milliseconds));
}

function redraw() {
    inventarSunCounter.innerText = gameState.inventar.sun;
    inventarWaterCounter.innerText = gameState.inventar.water;
    inventarSeedlingCounter.innerText = gameState.inventar.seedlings;
    gameInfoCo2.innerText = gameState.co2;
    if (gameState.isSun && !lastGameState.isSun) {
        let point = coordinateToPoint(toCoordinate(gameSettings.boardSize.rows, gameSettings.boardSize.columns));
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
        let point = coordinateToPoint(toCoordinate(gameSettings.boardSize.rows, gameSettings.boardSize.columns));
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
    for (let i=0;i<fieldElements.length;i++) {
        for (let j=0;j<fieldElements[i].length;j++) {
            if (gameState.fields[i][j].type != lastGameState.fields[i][j].type) {
                updateField(toCoordinate(i, j), gameState.fields[i][j].type);
            }
        }
    }
}

function collectSun(event) {
    fieldContainer.removeChild(event.srcElement);
    forestSpiritsAPI.collectSun();
    gameState.isSun = false;
}

function collectWater(event) {
    fieldContainer.removeChild(event.srcElement);
    forestSpiritsAPI.collectWater();
    gameState.isWater = false;
}

function initfieldElements() {
    fieldElements = [];
    for (let i=0;i<gameSettings.boardSize.rows;i++) {
        fieldElements[i] = [];
        for (let j=0;j<gameSettings.boardSize.columns;j++) {
            updateField(toCoordinate(i, j), gameState.fields[i][j].type);
        }
    }
}

function updateField(coordinate, fieldType) {
    if (fieldElements[coordinate.row][coordinate.column]) {
        fieldContainer.removeChild(fieldElements[coordinate.row][coordinate.column]);
    }
    let temp = document.createElement("div");
    temp.classList.add("field");
    temp.classList.add(fieldType);
    const point = coordinateToPoint(coordinate);
    temp.style.top = point.y + "px";
    temp.style.left = point.x + "px";
    fieldContainer.appendChild(temp);
    fieldElements[coordinate.row][coordinate.column] = temp;
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
    for (let row=0;row<gameSettings.boardSize.rows;row++) {
        for (let column=0;column<gameSettings.boardSize.rows;column++) {
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