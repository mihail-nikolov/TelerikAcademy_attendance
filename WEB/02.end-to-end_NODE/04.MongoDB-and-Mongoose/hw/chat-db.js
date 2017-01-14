var mongodb = require('mongodb'),
    mongoClient = mongodb.MongoClient,
    url = 'mongodb://localhost:27017/chat';

exports.registerUser = function (user) {
    mongoClient.connect(url, function (err, db) {
        var users = db.collection('users');
        console.log('Inserting ' + user + ' into collection Users');
        users.insert(user, function (err, data) {
            console.log(user + ' inserted into collection Users');
            console.log(data);
            console.log('------------------------------------------------');
        });
    });
}

exports.sendMessage = function (message) {
    mongoClient.connect(url, function (err, db) {
        var messages = db.collection('messages');
        console.log('Inserting ' + message + ' into collection Messages');
        messages.insert(message, function (err, data) {
            console.log(message + ' inserted into collection Messages');
            console.log(data);
            console.log('------------------------------------------------');
        });
    });
}

exports.getMessages = function (message) {
    mongoClient.connect(url, function (err, db) {
        var messages = db.collection('messages');
        var query = {
            from: message.with,
            to: message.and
        }

        messages.find(query).toArray(function (err, data) {
            if (err) throw err;
            console.log('All messages with ' + query.from + ' and ' + query.to);
            console.log(data);
        });
    });
}