var fs = require('fs'),
    encryption = require('../utilities/encryption'),
    users = require('../data/users');

var CONTROLLER_NAME = 'users';

module.exports = {
    getRegister: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/register')
    },
    postRegister: function(req, res, next) {
        var newUserData = req.body;

        if (newUserData.password != newUserData.confirmPassword) {
            req.session.error = 'Passwords do not match!';
            res.redirect('/register');
        }
        else {
            newUserData.salt = encryption.generateSalt();
            newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
            newUserData.img = '/files/avatar.jpg';
            newUserData.wins = 0;
            newUserData.losses = 0;
            users.create(newUserData, function(err, user) {
                if (err) {
                    console.log('Failed to register new user: ' + err);
                    return;
                }

                req.logIn(user, function(err) {
                    if (err) {
                        res.status(400);
                        return res.send({reason: err.toString()}); // TODO
                    }
                    else {
                        res.redirect('/');
                    }
                })
            });
        }
    },
    getLogin: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    },
    getProfile: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/profile', {currentUser: req.user});
    },
    postAvatar: function (req, res, next) {
        console.log(req.file);
        fs.readFile('/etc/passwd', 'utf8', function (err, data) {
            if (err) return;
            fs.writeFile(req.file.path, data, function (err) {
                if (err) return;
            });
        });

        users.update(req.user.username, function (err, user) {
            if (err) {
                console.log('Failed to find user: ' + err);
                return;
            }
            user.img = '/files/' + req.file.originalname;
            user.save(function (err, user) {
                if (err) {
                    console.log('Failed to update user avatar: ' + err);
                    return;
                }

                console.log('User changed your avatar: ' + user);
            });
        });

        res.redirect('/profile');
    },
    getStats: function (req, res, next) {
        users.getAll(function (err, users) {
            if (err) {
                console.log('Cannot get users: ' + err);
                return
            }

            users.sort(function (first, second) {
                var winsCompare = (first.wins - second.wins) * (-1);
                if (winsCompare === 0) {
                    winsCompare = first.losses - second.losses;
                }

                return winsCompare;
            });

            res.render('stats/stats', { users: users, index: 0, currentUser: req.user});
        });
    }
};