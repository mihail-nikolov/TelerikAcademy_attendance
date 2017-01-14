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
                url: "api/auth",
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
//=========================================================================================================
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
                    resolve(user);
                }
            });
        });
        return promise_reg;
    };
//=========================================================================================================
    function userLogout() {
        var prom_logout = new Promise(function (resolve, reject) {
            localStorage.removeItem(AUTH_KEY_STORAGE_KEY);
            localStorage.removeItem(USERNAME_STORAGE_KEY);
            console.log("logout")
            resolve();
        });

        return prom_logout;
    }
//=========================================================================================================
    function isUserLogged() {
        var username = localStorage.getItem(USERNAME_STORAGE_KEY);
        if (!username) {
            return false;
        }
        return true;
    }
//=========================================================================================================
    function getCookies() {
        var getCookie_prm = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/cookies',
                method: 'GET',
                contentType: 'application/json',
                success: function (resp) {
                    resolve(resp);
                }
            });
        });
        return getCookie_prm;
    }
//=========================================================================================================
    function getCookieById(id, cookies){
        for (var i = 0; i < cookies.length; i++) {
            if(id === cookies[i].id)
                return cookies[i];
        };
    }
//=========================================================================================================
  function getCookieByCategory(category, cookies) {
    var selectedCookies = [];
    for (var i = 0; i < cookies.length; i++) {
            if(category === cookies[i].category){
                selectedCookies.push(cookies[i]);
            }
    };
    return selectedCookies;
  }
//=========================================================================================================
    function addCookie(cookie) {
        var addCookie_prm = new Promise(function (resolve, reject) {
            var sendCookie = {
                text: cookie.text,
                category:cookie.category,
                img:cookie.img
            };
            var headers = {
                'x-auth-key': localStorage.getItem(AUTH_KEY_STORAGE_KEY)
            };
            $.ajax({
                url: 'api/cookies',
                method: 'POST',
                data: JSON.stringify(sendCookie),
                contentType: 'application/json',
                headers: headers,
                success: function (resp) {
                    resolve(resp);
                }
            });
        });
        return addCookie_prm;
    }
//=========================================================================================================
    function cookiesUpdate(id, info) {
        var updateCookie_promis = new Promise(function (resolve, reject) {
            var headers = {
                'x-auth-key': localStorage.getItem(AUTH_KEY_STORAGE_KEY)
            },
            url = "api/cookies/" + id;
            console.log("here1")
            console.log(info)
            $.ajax({
                url: url,
                method: "PUT",
                contentType: 'application/json',
                headers: headers,
                data: JSON.stringify(info),
                success: function (resp) {
                    console.log('updated')
                    resolve(resp);
                }
            });
        });
        return updateCookie_promis;
    }


    return {
        user: {
            login: userLogin,
            register: userRegister,
            logout: userLogout,
            isLogged: isUserLogged
        },
        cookies: {
            add: addCookie,
             get: getCookies,
            update: cookiesUpdate,
            getById: getCookieById,
            getByCat:getCookieByCategory
        }
    };
}());
