var auth = require('./auth'),
    controllers = require('../controllers'),
    multer = require('multer'),
    storage = multer.diskStorage({
        destination: function (req, file, cb) {
            cb(null, './public/files/')
        },
        filename: function (req, file, cb) {
            cb(null, file.originalname)
        }
    }),
    upload = multer({ storage: storage });

module.exports = function(app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.logout);

    app.get('/profile', controllers.users.getProfile);
    app.post('/profile', upload.single('avatar'), controllers.users.postAvatar);

    app.get('/games', controllers.games.getAll);
    app.post('/games', controllers.games.create);
    app.get('/games/:id/join', controllers.games.join);
    app.get('/games/:id', controllers.games.getById);
    app.post('/games/:id', controllers.games.play);

    app.get('/stats', controllers.users.getStats);

    app.get('/', function(req, res) {
        res.render('index', {currentUser: req.user});
    });

    app.get('*', function(req, res) {
        res.render('index', {currentUser: req.user});
    });
};