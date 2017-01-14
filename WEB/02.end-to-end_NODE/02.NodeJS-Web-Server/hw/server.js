(function() {
    'use strict';

    var formidable = require('formidable'),
        http = require('http'),
        port = 1234,
        uuid = require('uuid'),
        fs = require('fs-extra'),
        url = require('url'),
        filePath;

    http.createServer(function(req, res) {
        if (req.url == '/upload' && req.method.toLowerCase() == 'post') {

            // parse a file upload
            var form = new formidable.IncomingForm();
            form.keepExtensions = true;
            var guid = uuid.v1();

            form.parse(req, function(err, fields, files) {
                res.writeHead(200, {
                    'content-type': 'text/html'
                });
                res.write('<h4>Upload finished</h4>');
                res.write('<div><a href="/">Back</a></div><br>');
                res.write('<div><a href="/download">Download last uploaded file</a></div>');
                res.end();
            });


            form.on('end', function(fields, files) {

                var temp_path = this.openedFiles[0].path;
                var file_name = this.openedFiles[0].name;
                var new_location = 'files/' + guid;
                filePath = new_location + file_name;

                fs.copy(temp_path, new_location + file_name, function(err) {
                    if (err) {
                        console.error(err);
                    } else {
                        console.log("success!");
                    }
                });
            });

            return;
        }

        if (req.url === '/download') {
            fs.readFile(filePath, 'utf8',
                function(error, fileText) {
                    if (error) {
                        console.log('File cannot be read: ' + error);
                        return;
                    }
                    var fileName = filePath.substring(filePath.lastIndexOf('/') + 1);

                    var downloadsDir = './downloads/';
                    if (!fs.existsSync(downloadsDir)) {
                        fs.mkdirSync(downloadsDir);
                    }
                    fs.writeFile(downloadsDir + fileName, fileText, function(err) {
                        if (err) {
                            console.log('File cannot be write: ' + err);
                        } else {
                            console.log('File downloaded')
                        }
                    })
                });
        };

        // show a file upload form
        res.writeHead(200, {
            'content-type': 'text/html'
        });
        res.end(
            '<form action="/upload" enctype="multipart/form-data" method="post">' +
            '<input type="file" name="upload" multiple="multiple"><br>' +
            '<input type="submit" value="Upload">' +
            '</form>'
        );
    }).listen(port);

    console.log('Server running on port ' + port);
}());
