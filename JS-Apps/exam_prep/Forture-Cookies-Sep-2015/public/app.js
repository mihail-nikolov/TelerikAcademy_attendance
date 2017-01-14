(function() {

    var sammyApp = Sammy('#content', function() {
        //-------------------------------------------------------------
        this.get('#/', function(context) {
            context.redirect("#/home");
        });
        //-------------------------------------------------------------
        this.get("#/login", function(context) {
            templates.get('login')
                .then(function(template) {
                    $("#content").html(template());

                    $("#btn-register").on("click", function() {
                        var user = {
                            username: $('#tb-user').val(),
                            password: $('#tb-pass').val()
                        };
                        data.user.register(user)
                            .then(function() {
                                var message = "You are registered. Your username is " + user.username + " . You can login now!";
                                alert(message);
                                document.location.reload(true);
                            });

                    });
                    $("#btn-login").on("click", function() {
                        var user = {
                            username: $('#tb-user').val(),
                            password: $('#tb-pass').val()
                        };
                        data.user.login(user)
                            .then(function() {
                                context.redirect('#/home');
                                document.location.reload(true);
                            });
                    });
                });
        });
        //-------------------------------------------------------------
        this.get("#/home", function(context) {
            var categoryParameter = this.params.category || '';
            if (categoryParameter != '') {
                var cookies,
                    selectedCookies;
                    data.cookies.get()
                    .then(function(res) {
                        cookies = res.result;
                        selectedCookies = data.cookies.getByCat(categoryParameter, cookies);
                        console.log(selectedCookies)
                        return selectedCookies;
                    })
                    .then(function(selectedCookies) {

                       return templates.get('cookies');
                    })
                    .then(function(template) {
                       $("#content").html(template(selectedCookies));
                    });
            };

            var cookies;
            data.cookies.get()
                .then(function(res) {
                    cookies = res.result;
                    return templates.get('cookies');
                })
                .then(function(template) {
                    $("#content").html(template(cookies));
                    $('.btn-like').on('click', function() {
                        var id = $(this).attr('id');
                        data.cookies.update(id, {
                                type: 'like'
                            })
                            .then(function() {
                                document.location.reload(true);
                            });
                    });
                    $('.btn-dislike').on('click', function() {
                        var id = $(this).attr('id');
                        data.cookies.update(id, {
                                type: 'dislike'
                            })
                            .then(function() {
                                document.location.reload(true);
                            });
                    });
                    $('.btn-share').on('click', function() {
                        console.log("share cliked")
                        var id = $(this).attr('id');
                        // data.cookies.getById();
                        var cookies,
                            selectedCookie
                        data.cookies.get()
                            .then(function(res) {
                                cookies = res.result;
                                console.log("cookies get")
                                return cookies;
                            })
                            .then(function(cookies) {
                                selectedCookie = data.cookies.getById(id, cookies);
                                return selectedCookie;
                            })
                            .then(function(selectedCookie) {
                                data.cookies.add(selectedCookie)
                                    .then(function() {
                                        console.log("cookie added");
                                        context.redirect('#/home');
                                        document.location.reload(true);
                                    });
                            })



                    });
                    $('#category-filter').on('click', function() {
                        var catToFilter = $('#catToFilter').val();
                        console.log(catToFilter);
                        context.redirect(`#/home?category=${catToFilter}`);
                    });
                });
        });
        //-------------------------------------------------------------
        this.get("#/cookies/add", function(context) {
            templates.get('cookies-add')
                .then(function(template) {
                    $("#content").html(template());
                    $("#btn-cookie-add").on("click", function() {
                        var cookie = {
                            text: $('#tb-cookie-text').val(),
                            category: $('#tb-cookie-category').val(),
                            img: $('#tb-cookie-img').val()
                        };
                        console.log(cookie);
                        data.cookies.add(cookie)
                            .then(function() {
                                console.log("cookie added");
                                context.redirect('#/home');
                                document.location.reload(true);
                            });
                    });
                });
        });

        // this.get('#/items', function(){

        // })

        //-------------------------------------------------------------
    });

    $(function() {
        sammyApp.run('#/home');
        if (data.user.isLogged()) {
            $('#login_reg_btn')
                .addClass('hidden');
        } else {
            $('#logout_btn')
                .addClass('hidden');
        }

        $('#logout_btn').on('click', function() {
            data.user.logout()
                .then(function() {
                    location = '#/';
                    document.location.reload(true);
                });
        });
    });
}());
