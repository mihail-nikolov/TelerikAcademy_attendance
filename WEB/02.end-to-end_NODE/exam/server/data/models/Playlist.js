var mongoose = require('mongoose');

var requiredMessage = '{PATH} is required';

module.exports.init = function() {
    var playlistSchema = mongoose.Schema({
        title: { type: String, required: requiredMessage },
        description: { type: String, required: requiredMessage },
        category: { type: String, required: requiredMessage },
        date: { type: Date, required: requiredMessage },
        creator: { type: String, required: requiredMessage },
        haveAccess:[{username:String}],
        videos: [{
            video: String
        }],
        comments: [{
            username: String,
            content: String
        }],
        rating: { type: Number, default: 0},
        public: {type: Boolean, reqired: requiredMessage}
    });

    var Playlist = mongoose.model('Playlist', playlistSchema);
};



