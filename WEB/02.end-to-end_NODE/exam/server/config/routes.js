var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.logout);
    app.get('/profile', controllers.users.getInfo);
    app.post('/profile', controllers.users.postInfo);
    app.put('/profile', controllers.users.updateInfo);

    app.get('/playlists/create', auth.isAuthenticated, controllers.playlists.getCreate);
    app.post('/playlists/create', auth.isAuthenticated, controllers.playlists.postCreate);
    app.get('/playlists/public', controllers.playlists.getPublic);
    app.get('/playlists/private', controllers.playlists.getPrivate);
    app.get('/playlists/mine', controllers.playlists.getMine);
    app.get('/playlists/details/:id', auth.isAuthenticated, controllers.playlists.getById);
    //app.get('/playlists/details/:id/addComment', auth.isAuthenticated, controllers.playlists.getById);
    //app.get('/playlists/details/:id/addVideo', auth.isAuthenticated, controllers.playlists.getById);
    app.put('/playlists/details/:id/addAccessor', auth.isAuthenticated, controllers.playlists.addAccessor);
    //app.get('/playlists/details/:id/rate', auth.isAuthenticated, controllers.playlists.getById)

    app.get('/', function(req, res) {
        res.render('index');
    });

    app.get('*', function(req, res) {
        res.render('index');
    });
};