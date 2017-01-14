var Playlist = require('mongoose').model('Playlist'),
    constants = require('../common/constants');

var cache = {
    expires: undefined,
    data: undefined
};

module.exports = {
    create: function(playlist, user, callback) {
        if (constants.categories.indexOf(playlist.category) < 0) {
            callback('Invalid category');
            return;
        }
        playlist.creator = user.username;
        playlist.date = new Date();

        Playlist.create(playlist, callback);
    },
    public: function(page, pageSize, callback) {
        page = page || 1;
        pageSize = pageSize || 10;

        if (page == 1 && cache.expires && cache.expires < new Date()) {
            callback(null, cache.data);
            return;
        }

        Playlist
            .find({public: true })
            .sort({
                date: 'desc'
            })
            .limit(pageSize)
            .skip((page - 1) * pageSize)
            .exec(function(err, foundPlaylists) {
                if (err) {
                    callback(err);
                    return;
                }

                Playlist.count().exec(function(err, numberOfPlaylists) {
                    var data = {
                        playlists: foundPlaylists,
                        currentPage: page,
                        pageSize: pageSize,
                        total: numberOfPlaylists
                    };

                    callback(err, data);

                    cache.data = data;
                    cache.expires = new Date() + 10;
                });
            })
    },
    private: function(page, pageSize, user, callback) {
        page = page || 1;
        pageSize = pageSize || 10;

        if (page == 1 && cache.expires && cache.expires < new Date()) {
            callback(null, cache.data);
            return;
        }

        Playlist
            .find({'haveAcces.username': user.username})
            .sort({
                date: 'desc'
            })
            .limit(pageSize)
            .skip((page - 1) * pageSize)
            .exec(function(err, foundPlaylists) {
                if (err) {
                    callback(err);
                    return;
                }

                Playlist.count().exec(function(err, numberOfPlaylists) {
                    var data = {
                        playlists: foundPlaylists,
                        currentPage: page,
                        pageSize: pageSize,
                        total: numberOfPlaylists
                    };

                    callback(err, data);

                    cache.data = data;
                    cache.expires = new Date() + 10;
                });
            })
    },
    mine: function(page, pageSize, user, callback) {
        page = page || 1;
        pageSize = pageSize || 10;

        if (page == 1 && cache.expires && cache.expires < new Date()) {
            callback(null, cache.data);
            return;
        }

        Playlist
            .find({'creator': user.username})
            .sort({
                date: 'desc'
            })
            .limit(pageSize)
            .skip((page - 1) * pageSize)
            .exec(function(err, foundPlaylists) {
                if (err) {
                    callback(err);
                    return;
                }

                Playlist.count().exec(function(err, numberOfPlaylists) {
                    var data = {
                        playlists: foundPlaylists,
                        currentPage: page,
                        pageSize: pageSize,
                        total: numberOfPlaylists
                    };

                    callback(err, data);

                    cache.data = data;
                    cache.expires = new Date() + 10;
                });
            })
    },
    byId: function(id, callback) {
        Playlist
            .findOne({id:id})
            .exec(function(err, foundPlaylist) {
                callback(err, foundPlaylist);
            })
    },
    accessor: function(username,id, callback) {
        Playlist
            .findOne({id:id})
            .exec(function(err, foundPlaylist) {
                foundPlaylist.haveAccess.add(username);
            })
    }
};