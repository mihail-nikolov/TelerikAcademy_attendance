var data = (function () {
    const USERNAME_STORAGE_KEY = 'username-key',
        AUTH_KEY_STORAGE_KEY = 'auth-key-key';

    function userLogin(user) {
        var promise_login = new Promise(function (resolve, reject) {
            var reqUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            };
            $.ajax({
                url: "api/users/auth",
                method: "PUT",
                contentType: 'application/json',
                data: JSON.stringify(reqUser),
                success: function (resp) {
                    var user = resp.result;
                    localStorage.setItem(USERNAME_STORAGE_KEY, user.username);
                    localStorage.setItem(AUTH_KEY_STORAGE_KEY, user.authKey);
                    resolve(user);
                }
            });
        });
        return promise_login;
    };

    function userRegister(user) {
        var promise_reg = new Promise(function (resolve, reject) {
            var reqUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            };
            $.ajax({
                url: 'api/users',
                method: 'POST',
                data: JSON.stringify(reqUser),
                contentType: 'application/json',
                success: function (resp) {
                    var user = resp.result;
                    localStorage.setItem(USERNAME_STORAGE_KEY, user.username);
                    localStorage.setItem(AUTH_KEY_STORAGE_KEY, user.authKey);
                    resolve(user);
                }
            });
        });
        return promise_reg;
    };

    function userLogout() {
        var prom_logout = new Promise(function (resolve, reject) {
            localStorage.removeItem(AUTH_KEY_STORAGE_KEY);
            localStorage.removeItem(USERNAME_STORAGE_KEY);
            console.log("logout")
            resolve();
        });

        return prom_logout;
    }

    function isUserLogged() {
        var username = localStorage.getItem(USERNAME_STORAGE_KEY);
        if (!username) {
            return false;
        }
        return true;
    }

    function addTODO(todo) {
        var addTODO_prm = new Promise(function (resolve, reject) {
            var sendTODO = {
                text: todo.text,
                category:todo.category
            };
            var headers = {
                'x-auth-key': localStorage.getItem(AUTH_KEY_STORAGE_KEY)
            };
            $.ajax({
                url: 'api/todos',
                method: 'POST',
                data: JSON.stringify(sendTODO),
                contentType: 'application/json',
                headers: headers,
                success: function (resp) {
                    resolve(resp);
                }
            });
        });
        return addTODO_prm;
    }

    function getTODOs() {
        var getTODO_prm = new Promise(function (resolve, reject) {
            var headers = {
                'x-auth-key': localStorage.getItem(AUTH_KEY_STORAGE_KEY)
            };
            $.ajax({
                url: 'api/todos',
                method: 'GET',
                contentType: 'application/json',
                headers: headers,
                success: function (resp) {
                    resolve(resp);
                }
            });
        });
        return getTODO_prm;
    }

    function todosUpdate(id, todo) {
        var updateTODO_promis = new Promise(function (resolve, reject) {
            var headers = {
                'x-auth-key': localStorage.getItem(AUTH_KEY_STORAGE_KEY)
            },
            url = "api/todos/" + id;
            $.ajax({
                url: url,
                method: "PUT",
                contentType: 'application/json',
                headers: headers,
                data: JSON.stringify(todo),
                success: function (resp) {
                    console.log('update')
                    resolve(resp);
                }
            });
        });
        return updateTODO_promis;
    }


    return {
        user: {
            login: userLogin,
            register: userRegister,
            logout: userLogout,
            isLogged: isUserLogged
        },
        todos: {
            add: addTODO,
            get: getTODOs,
            update: todosUpdate
        },
        threads: {
            //get: threadsGet,
            //add: threadsAdd,
            //getById: threadById,
            //addMessage: threadsAddMessage
        }
    };
}());
