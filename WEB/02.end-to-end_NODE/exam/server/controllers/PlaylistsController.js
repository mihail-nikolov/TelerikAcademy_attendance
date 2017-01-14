var playlists = require('../data/playlist'),
    users = require('../data/users'),
    constants = require('../common/constants');

var CONTROLLER_NAME = 'playlists';

module.exports = {
    getCreate: function (req, res) {
        res.render(CONTROLLER_NAME + '/create', {
            categories: constants.categories
        });
    },
    postCreate: function(req, res) {
        var playlist = req.body;
        var user = req.user;
        playlists.create(
            playlist,
            {
                username: user.username
            },
            function (err, playlist) {
                if (err) {
                    var data = {
                        categories: constants.categories,
                        errorMessage: err
                    };
                    res.render(CONTROLLER_NAME + '/create', data);
                }
                else {
                    res.redirect('/playlists/details/' + playlist._id);
                }
            })
    },
    getPublic: function(req, res) {
        var page = req.query.page;
        var pageSize = req.query.pageSize;

        playlists.public(page, pageSize, function(err, data) {
            res.render(CONTROLLER_NAME + '/public', {
                data: data
            });
        });
    },
    getPrivate: function(req, res) {
        var user = req.user;
        var page = req.query.page;
        var pageSize = req.query.pageSize;

        playlists.private(page, pageSize,user, function(err, data) {
            res.render(CONTROLLER_NAME + '/private', {
                data: data
            });
        });
    },
    getMine: function(req, res) {
        var page = req.query.page;
        var pageSize = req.query.pageSize;
        var user = req.user;

        playlists.mine(page, pageSize,user, function(err, data) {
            res.render(CONTROLLER_NAME + '/mine', {
                data: data
            });
        });
    },
    getById: function(req, res) {
        var id = req.query.id;
        playlists.byId(id, function(err, foundPlaylist) {
            console.log(foundPlaylist.title);
            res.render(CONTROLLER_NAME + '/byId', {
                playlist: foundPlaylist
            });
        });
    },
    addAccessor: function(req, res) {
        var id = req.query.id;
        playlists.accessor(username, id, function(err, foundPlaylist) {
            console.log('here' + foundPlaylist.haveAccess[0]);
            res.redirect('/' );
        });

    }
};