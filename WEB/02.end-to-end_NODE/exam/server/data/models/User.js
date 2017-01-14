var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');

var requiredMessage = '{PATH} is required';

module.exports.init = function() {
    var userSchema = mongoose.Schema({
        username: { type: String, required: requiredMessage, unique: true },
        email: { type: String, required: requiredMessage},
        salt: String,
        hashPass: String,
        firstName: { type: String, required: requiredMessage},
        lastName: { type: String, required: requiredMessage},
        facebook: String,
        youtube: String,
        rating: { type: Number, default: 0},
        playlists: [{ playlist: String}],
        avatar: String
    });

    userSchema.method({
        authenticate: function(password) {
            if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
                return true;
            }
            else {
                return false;
            }
        }
    });

    var User = mongoose.model('User', userSchema);
};


