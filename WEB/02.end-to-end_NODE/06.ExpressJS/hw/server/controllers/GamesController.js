var games = require('../data/games'),
    users = require('../data/users');

var CONTROLLER_NAME = 'games';

module.exports = {
    getAll: function (req, res, next) {
        games.getAll(function (err, allGames) {
            if (err) return;
            res.render(CONTROLLER_NAME + '/games', { games: allGames, currentUser: req.user });
        });
    },
    create: function (req, res, next) {
        var newGame = {
            gameState: 'WaitingForOpponent',
            redPlayer: req.user.username,
            blackPlayer: '',
            field: '---------',
            winner: '',
            losser: '',
        }

        games.create(newGame, function (err, game) {
            if (err) {
                console.log('Failed to create new game: ' + err);
                return;
            }

            console.log('Game was created ' + game);
            res.redirect('/games');
        });
    },
    join: function (req, res, next) {
        games.update(req.params.id, function (err, game) {
            if (err) {
                console.log('Failed to find game: ' + err);
                return;
            }

            if (req.user.username === game.redPlayer) {
                req.session.error = 'You are creater by this game!';
                res.redirect('/games');
            }
            else {
                game.blackPlayer = req.user.username;
                game.gameState = 'RedInTurn';
                game.save(function (err, game) {
                    if (err) {
                        console.log('Failed to join user in game: ' + err);
                        return;
                    }

                    console.log('User was joined to the game: ' + game);
                });

                res.redirect('/games/' + req.params.id);
            }
        });
    },
    play: function (req, res, next) {
        games.update(req.params.id, function (err, game) {
            if (err) {
                console.log('Failed to find game: ' + err);
                return;
            }

            if (game.field.indexOf('-') === -1) {
                game.gameState = 'Tie';
            }

            var row = Number(req.body.index[0]),
                col = Number(req.body.index[1]);

            if ((game.gameState === 'RedInTurn' && game.redPlayer === req.user.username)
                || (game.gameState === 'BlackInTurn' && game.blackPlayer === req.user.username)) {
                var index = ((row - 1) * 3) + col - 1;
                if (game.gameState === 'RedInTurn') {
                    game.gameState = 'BlackInTurn';
                    game.field = game.field.substring(0, index) + 'X' + game.field.substring(index + 1);
                    console.log(game.field);
                }
                else if (game.gameState === 'BlackInTurn') {
                    game.gameState = 'RedInTurn';
                    game.field = game.field.substring(0, index) + 'O' + game.field.substring(index + 1);
                }

                for (var i = 0; i < 8; i += 3) {
                    var findRow = true;
                    for (var j = i + 1; j < i + 3; j++) {
                        if (game.field[i] === '-' || game.field[i] !== game.field[j]) {
                            findRow = false;
                            break;
                        }
                    }

                    if (findRow) {
                        if (game.field[i] === 'X') {
                            game.gameState = 'WonByRed';
                            game.winner = game.redPlayer;
                            game.losser = game.blackPlayer;
                            
                        }
                        else {
                            game.gameState = 'WonByBlack';
                            game.winner = game.blackPlayer;
                            game.losser = game.redPlayer;
                        }
                    }
                }

                for (var i = 0; i < 3; i += 1) {
                    var findRow = true;
                    for (var j = i + 3; j < 9; j += 3) {
                        if (game.field[i] === '-' || game.field[i] !== game.field[j]) {
                            findRow = false;
                            break;
                        }
                    }

                    if (findRow) {
                        if (game.field[i] === 'X') {
                            game.gameState = 'WonByRed';
                            game.winner = game.redPlayer;
                            game.losser = game.blackPlayer;
                        }
                        else {
                            game.gameState = 'WonByBlack';
                            game.winner = game.blackPlayer;
                            game.losser = game.redPlayer;
                        }
                    }
                }

                if (game.field[0] != '-' && game.field[0] === game.field[4] && game.field[0] === game.field[8]) {
                    if (game.field[0] === 'X') {
                        game.gameState = 'WonByRed';
                        game.winner = game.redPlayer;
                        game.losser = game.blackPlayer;
                    }
                    else {
                        game.gameState = 'WonByBlack';
                        game.winner = game.blackPlayer;
                        game.losser = game.redPlayer;
                    }
                }

                if (game.field[2] != '-' && game.field[2] === game.field[4] && game.field[2] === game.field[6]) {
                    if (game.field[2] === 'X') {
                        game.gameState = 'WonByRed';
                        game.winner = game.redPlayer;
                        game.losser = game.blackPlayer;
                    }
                    else {
                        game.gameState = 'WonByBlack';
                        game.winner = game.blackPlayer;
                        game.losser = game.redPlayer;
                    }
                }

                if (game.gameState === 'WonByRed' || game.gameState === 'WonByBlack') {
                    users.getByNames(game.redPlayer, game.blackPlayer, function (err, dbUsers) {
                        if (err) {
                            console.log('Cannot find the users: ' + err);
                            return;
                        }

                        var redUser = dbUsers[0],
                            blackUser = dbUsers[1];

                        if (game.winner === redUser.username) {
                            redUser.wins += 1;
                            blackUser.losses += 1;
                        }
                        else {
                            blackUser.wins += 1;
                            redUser.losses += 1;
                        }

                        redUser.save(function (err, data) {
                            if (err) {
                                console.log('Cannot update users statistic: ' + err);
                                return;
                            }

                            console.log('RedUser statistic updated!');
                        });

                        blackUser.save(function (err, data) {
                            if (err) {
                                console.log('Cannot update users statistic: ' + err);
                                return;
                            }

                            console.log('BlackUser statistic updated!');
                        });
                    });
                }

                game.save(function (err, game) {
                    if (err) {
                        console.log('The turn was failed: ' + err);
                        return;
                    }

                    console.log('End turn!');
                });
            }
            else {
                req.session.error = 'It is not your turn!';
            }

            res.redirect('/games/' + req.params.id);
        });
    },
    getById: function (req, res, next) {
        if (!req.user) {
            res.redirect('/login');
        }

        games.getById(req.params.id, function (err, game) {
            if (err) {
                console.log('Cannot find the game: ' + err);
                return;
            }

            users.getByNames(game.redPlayer, game.blackPlayer, function (err, users) {
                if (err) {
                    console.log('Cannot find the users: ' + err);
                    return;
                }

                res.render(CONTROLLER_NAME + '/game-field',
                    {
                        game: game,
                        redPlayer: game.redPlayer === users[0].username ? users[0] : users[1],
                        blackPlayer: game.blackPlayer === users[0].username ? users[0] : users[1],
                        currentUser: req.user
                    });
            });
        });
    }
};