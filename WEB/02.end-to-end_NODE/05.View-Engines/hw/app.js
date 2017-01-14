'use strict';

var express = require('express'),
    path = require('path'),
    jade = require('jade'),
    app = express(),
    port = 3000;

app.use(express.static(path.join(__dirname, 'node_modules')));

app.get('/', function (req, res) {
    res.sendFile(__dirname + '/views/home.html');
});

app.get('/Smart%20phones', function (req, res) {
    res.sendFile(__dirname + '/views/smart-phones.html');
});

app.get('/tablets', function (req, res) {
    res.sendFile(__dirname + '/views/tablets.html');
});

app.get('/wearables', function (req, res) {
    res.sendFile(__dirname + '/views/wearables.html');
});


var server = app.listen(port, function () {
    console.log('Server is running at localhost:' + port)
});