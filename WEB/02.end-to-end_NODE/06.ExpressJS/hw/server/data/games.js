var Game = require('mongoose').model('Game');

module.exports = {
    create: function (game, callback) {
        Game.create(game, callback);
    },
    getAll: function (callback) {
        Game.find(callback);
    },
    update: function (id, callback) {
        Game.findOne({ _id: id }, callback);
    },
    getById: function (id, callback) {
        Game.findOne({ _id: id }, callback);
    }
};