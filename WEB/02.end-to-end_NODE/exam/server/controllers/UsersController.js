var encryption = require('../utilities/encryption');
var users = require('../data/users');

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
            users.create(newUserData, function(err, user) {
                if (err) {
                    console.log('Failed to register new user: ' + err);
                    return;
                }

                req.logIn(user, function(err) {
                    if (err) {
                        res.status(400);
                        return res.send({reason: err.toString()});
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
    getInfo: function (req,res,next) {
        res.render(CONTROLLER_NAME + '/profile');
    },
    postInfo: function (req, res, next) {
        users.update(req.user.username, function (err, user) {
            if (err) {
                console.log('Failed to find user: ' + err);
                return;
            }
            user.avatar= req.user.avatar;
            user.firstName= req.user.firstName;
            user.lastName= req.user.lastName;
            user.email= req.user.email;
            user.facebook= req.user.facebook;
            user.youtube= req.user.youtube;
            user.email= req.user.email;
            user.save(function (err, user) {
                if (err) {
                    console.log('Failed to update user info: ' + err);
                    return;
                }

                console.log('User changed your info: ' + user);
            });
        });
        res.redirect('/profile');
    },
    updateInfo: function (req, res, next) {
        users.update(req.user.username, function (err, user) {
            if (err) {
                console.log('Failed to find user: ' + err);
                return;
            }
            user.avatar= req.user.avatar;
            user.firstName= req.user.firstName;
            user.lastName= req.user.lastName;
            user.email= req.user.email;
            user.facebook= req.user.facebook;
            user.youtube= req.user.youtube;
            user.email= req.user.email;
            user.save(function (err, user) {
                if (err) {
                    console.log('Failed to update user info: ' + err);
                    return;
                }

                console.log('User changed your info: ' + user);
            });
        });
        res.redirect('/profile');
    }
};