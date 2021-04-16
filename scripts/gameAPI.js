const forestSpiritsConstants = {
    fieldTypes: {
        normal: "field-normal",
        city: "field-city",
        tree: "field-tree",
        seedling: "field-seedling",
        halfRipe: "field-half-ripe",
        ripe: "field-ripe"
    }
}

const forestSpiritsAPI = {
    gameState: {
        isSun: false,
        isWater: false,
        co2: 0,
        fields: [],
        inventar: {
            sun: 0,
            water: 0,
            seedlings: 0
        }
    },
    gameConfig: undefined,

    initialize: function (config) {
        this.gameConfig = config;
        for (let i=0;i<config.boardSize.rows;i++) {
            this.gameState.fields[i] = [];
            for (let j=0;j<config.boardSize.columns;j++) {
                this.gameState.fields[i][j] = {
                    type: forestSpiritsConstants.fieldTypes.normal,
                    water: 0,
                    sun: 0,
                    progress: 0
                }
            }
        }
        this.gameState.fields[config.cityLocation.row-1][config.cityLocation.column-1].type = forestSpiritsConstants.fieldTypes.city;
        this.gameState.fields[config.playerLocation.row-1][config.playerLocation.column-1].type = forestSpiritsConstants.fieldTypes.tree;
        this.gameState.inventar.seedlings = config.inventar.seedlings;
        this.gameState.co2 = config.co2.start;
    },

    collectSun: function() {
        this.gameState.inventar.sun++;
        this.gameState.isSun = false;
    },

    collectWater: function() {
        this.gameState.inventar.water++;
        this.gameState.isWater = false;
    },

    feedWater: function(row, column) {
        const fieldType = gameState.fields[row][column].type;
        if (fieldType === forestSpiritsConstants.fieldTypes.ripe || fieldType === forestSpiritsConstants.fieldTypes.city) {
            return false;
        }

        console.log(fieldType);
        if (fieldType === forestSpiritsConstants.fieldTypes.normal || fieldType === forestSpiritsConstants.fieldTypes.halfRipe || fieldType === forestSpiritsConstants.fieldTypes.ripe) {
            this.gameState.fields[row][column].water += this.gameConfig.resourceRates.field.feed;
            console.log(this.gameState.fields[row][column].water);
            this.gameState.fields[row][column].water = Math.min(100, this.gameState.fields[row][column].water);
            this.gameState.inventar.water--;

            if (this.gameState.fields[row][column].water >= 100 && this.gameState.fields[row][column].sun >= 100) {
                this.gameState.fields[row][column].type = fieldType === forestSpiritsConstants.fieldTypes.normal ? forestSpiritsConstants.fieldTypes.halfRipe : forestSpiritsConstants.fieldTypes.ripe;
                this.gameState.fields[row][column].water = 0;
                this.gameState.fields[row][column].sun = 0;
                this.gameState.fields[row][column].progress = 0;
            }
        } else {
            if (this.gameState.fields[row][column].water >= 100 && this.gameState.fields[row][column].sun >= 100) {
                this.gameState.inventar.water--;
                this.gameState.fields[row][column].progress += this.gameConfig.resourceRates.plant.progress;
                if (this.gameState.fields[row][column].progress >= 100) {
                    this.gameState.inventar.seedlings++;
                    this.gameState.fields[row][column].progress -= 100;
                }
            } else if (this.gameState.fields[row][column].water >= 100) {
                return false;
            } else {
                this.gameState.fields[row][column].water += this.gameConfig.resourceRates.plant.feed;
                this.gameState.fields[row][column].water = Math.min(100, this.gameState.fields[row][column].water);
                this.gameState.inventar.water--;
            }
        }
        return true;
    },

    feedSun: function(row, column) {
        const fieldType = gameState.fields[row][column].type;
        if (fieldType === forestSpiritsConstants.fieldTypes.ripe || fieldType === forestSpiritsConstants.fieldTypes.city) {
            return false;
        }

        if (fieldType === forestSpiritsConstants.fieldTypes.normal || fieldType === forestSpiritsConstants.fieldTypes.halfRipe || fieldType === forestSpiritsConstants.fieldTypes.ripe) {
            this.gameState.fields[row][column].sun += this.gameConfig.resourceRates.field.feed;
            this.gameState.fields[row][column].sun = Math.min(100, this.gameState.fields[row][column].sun);
            this.gameState.inventar.sun--;

            if (this.gameState.fields[row][column].water >= 100 && this.gameState.fields[row][column].sun >= 100) {
                this.gameState.fields[row][column].type = fieldType === forestSpiritsConstants.fieldTypes.normal ? forestSpiritsConstants.fieldTypes.halfRipe : forestSpiritsConstants.fieldTypes.ripe;
                this.gameState.fields[row][column].water = 0;
                this.gameState.fields[row][column].sun = 0;
                this.gameState.fields[row][column].progress = 0;
            }
        } else {
            if (this.gameState.fields[row][column].water >= 100 && this.gameState.fields[row][column].sun >= 100) {
                this.gameState.inventar.sun--;
                this.gameState.fields[row][column].progress += this.gameConfig.resourceRates.plant.progress;
                if (this.gameState.fields[row][column].progress >= 100) {
                    this.gameState.inventar.seedlings++;
                    this.gameState.fields[row][column].progress -= 100;
                }
            } else if (this.gameState.fields[row][column].sun >= 100) {
                return false;
            } else {
                this.gameState.inventar.sun--;
                this.gameState.fields[row][column].sun += this.gameConfig.resourceRates.plant.feed;
                this.gameState.fields[row][column].sun = Math.min(100, this.gameState.fields[row][column].sun);
            }
        }
        return true;
    },

    isGameOver: function() {
        return this.gameState.co2 <= 0 || this.gameState.co2 >= 10000;
    },

    tick: function () {
        this.gameState.isSun = gameState.isSun || Math.random() * 100 < gameSettings.resourceRates.collection;
        this.gameState.isWater = gameState.isWater || Math.random() * 100 < gameSettings.resourceRates.collection;

        if (Math.random() * 100 < gameSettings.resourceRates.city.growth) {
            this.expandCity(gameState.fields);
        }
        let treeCounter = 0;
        let cityCounter = 0;
        for (let i=0;i<this.gameState.fields.length;i++) {
            for (let j=0;j<this.gameState.fields[i].length;j++) {
                if (this.gameState.fields[i][j].type === forestSpiritsConstants.fieldTypes.seedling) {
                    if (this.gameState.fields[i][j].progress >= 100) {
                        this.gameState.fields[i][j].type = forestSpiritsConstants.fieldTypes.tree;
                        this.gameState.fields[i][j].water = 0;
                        this.gameState.fields[i][j].sun = 0;
                        this.gameState.fields[i][j].progress = 0;
                    } else if (gameState.fields[i][j].sun >= 100 && gameState.fields[i][j].water >= 100) {
                        this.gameState.fields[i][j].progress = Math.min(gameState.fields[i][j].progress + this.gameConfig.resourceRates.plant.progress, 100);
                    } else {
                        this.gameState.fields[i][j].sun = Math.min(gameState.fields[i][j].sun + this.gameConfig.resourceRates.plant.admission, 100);
                        this.gameState.fields[i][j].water = Math.min(gameState.fields[i][j].water + this.gameConfig.resourceRates.plant.admission, 100);
                    }
                } else if (this.gameState.fields[i][j].type === forestSpiritsConstants.fieldTypes.tree) {
                    if (this.gameState.fields[i][j].progress >= 100) {
                        this.gameState.inventar.seedlings++;
                        this.gameState.fields[i][j].progress = 0;
                    } else if (gameState.fields[i][j].sun >= 100 && gameState.fields[i][j].water >= 100) {
                        this.gameState.fields[i][j].progress = Math.min(gameState.fields[i][j].progress + this.gameConfig.resourceRates.plant.progress, 100);
                    } else {
                        this.gameState.fields[i][j].sun = Math.min(gameState.fields[i][j].sun + this.gameConfig.resourceRates.plant.admission, 100);
                        this.gameState.fields[i][j].water = Math.min(gameState.fields[i][j].water + this.gameConfig.resourceRates.plant.admission, 100);
                    }
                    treeCounter++;
                } else if (this.gameState.fields[i][j].type === forestSpiritsConstants.fieldTypes.city) {
                    cityCounter++;
                }
            }
        }
        this.gameState.co2 += -1 * treeCounter * gameSettings.co2.tree + cityCounter * gameSettings.co2.city;
    },

    plantSeedling: function(row, column) {
        if (this.gameState.fields[row][column].type != forestSpiritsConstants.fieldTypes.ripe) {
            return false;
        }
        this.gameState.inventar.seedlings--;
        this.gameState.fields[row][column].type = forestSpiritsConstants.fieldTypes.seedling;
        this.gameState.fields[row][column].water = 0;
        this.gameState.fields[row][column].sun = 0;
        this.gameState.fields[row][column].progress = 0;
        return true;
    },

    // TODO das hier besser machen, dass die stadt in alle Richtungen ausbreitet
    expandCity: function() {
        for (let i=0;i<this.gameState.fields.length;i++) {
            for (let j=0;j<this.gameState.fields[i].length;j++) {
                if (this.gameState.fields[i][j].type === "field-city") {
                    if (i-1 >= 0) {
                        if (this.gameState.fields[i-1][j].type === forestSpiritsConstants.fieldTypes.normal) {
                            this.gameState.fields[i-1][j].type = forestSpiritsConstants.fieldTypes.city;
                            return;
                        }
                        if (j+1 < FIELD_COLUMNS) {
                            if (this.gameState.fields[i-1][j+1].type === forestSpiritsConstants.fieldTypes.normal) {
                                this.gameState.fields[i-1][j+1].type = forestSpiritsConstants.fieldTypes.city;
                                return;
                            }
                        }
                    }
                    if (j-1 >= 0) {
                        if (this.gameState.fields[i][j-1].type === forestSpiritsConstants.fieldTypes.normal) {
                            this.gameState.fields[i][j-1].type = forestSpiritsConstants.fieldTypes.city;
                            return;
                        }
                    }
                    if (j+1 < FIELD_COLUMNS) {
                        if (this.gameState.fields[i][j+1].type === forestSpiritsConstants.fieldTypes.normal) {
                            this.gameState.fields[i][j-1].type = forestSpiritsConstants.fieldTypes.city;
                            return;
                        }
                    }
                    if (i+1 < FIELD_ROWS) {
                        if (this.gameState.fields[i+1][j].type === forestSpiritsConstants.fieldTypes.normal) {
                            this.gameState.fields[i+1][j].type = forestSpiritsConstants.fieldTypes.city;
                            return;
                        }
                        if (j+1 < FIELD_COLUMNS) {
                            if (this.gameState.fields[i+1][j+1].type === forestSpiritsConstants.fieldTypes.normal) {
                                this.gameState.fields[i+1][j+1].type = forestSpiritsConstants.fieldTypes.city;
                                return;
                            }
                        
                        }
                    }
                }
            }
        }
    },

    getGameState: function() {
        return JSON.parse(JSON.stringify(this.gameState));
    }
};