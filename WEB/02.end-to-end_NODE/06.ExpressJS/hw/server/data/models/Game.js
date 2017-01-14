var mongoose = require('mongoose');

module.exports.init = function () {
    var gameSchema = mongoose.Schema({
        gameState: String,
        redPlayer: String,
        blackPlayer: String,
        field: String,
        winner: String,
        losser: String,
    });

    var Game = mongoose.model('Game', gameSchema);
};


