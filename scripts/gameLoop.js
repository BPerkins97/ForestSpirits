function play (updateFrontendCallback) {
        forestSpiritsAPI.initialize(gameSettings);
        while (!forestSpiritsAPI.isGameOver()) {
            forestSpiritsAPI.tick();
            updateFrontendCallback();
            await Sleep(1000.0);
        }
    }
}

