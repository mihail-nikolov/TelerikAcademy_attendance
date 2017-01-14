(function () {

    var sammyApp = Sammy('#content', function () {
//-------------------------------------------------------------
        this.get('#/home', function () {
            console.log('---------Home');
            // if (data.users.current()) {
            templates.get('home')
                .then(function (template) {
                    $("#content").html(template());
                  });
        });
//-------------------------------------------------------------
        this.get('#/', function (context) {
            context.redirect("#/home");
        });
//-------------------------------------------------------------
        this.get("#/login", function (context) {
            templates.get('login')
                .then(function (template) {
                    $("#content").html(template());

                    $("#btn-register").on("click", function () {
                        var user = {
                            username: $('#tb-user').val(),
                            password: $('#tb-pass').val()
                        };
                        data.user.register(user)
                            .then(function () {
                                context.redirect('#/home');
                                document.location.reload(true);
                                
                            });
                        
                    });
                 
                    $("#btn-login").on("click", function () {
                        var user = {
                            username: $('#tb-user').val(),
                            password: $('#tb-pass').val()
                        };
                        data.user.login(user)
                            .then(function () {
                                context.redirect('#/home');
                                document.location.reload(true);
                            });
                        
                    });
                });
        });
//-------------------------------------------------------------
        this.get("#/todos", function () {
            var todos;
            data.todos.get()
              .then(function (res) {
                  todos = res.result;
                  return templates.get('todos');
              })
              .then(function (template) {
                  $("#content").html(template(todos));
                  $('.todo-box').on('change', function () {
                      console.log("here1");
                      var $checkbox = $(this).find('input');
                      var isChecked = $checkbox.prop('checked');
                      var id = $(this).attr('data-id');
                      console.log(id);
                      data.todos.update(id, {
                          state: isChecked
                      })
                        .then(function (todo) {
                            console.log("here");
                        });
                  });
              });
        });
//-------------------------------------------------------------
        this.get("#/todos/add", function (context) {
            templates.get('todo-add')
               .then(function (template) {
                   $("#content").html(template());
                   $("#btn-todo-add").on("click", function () {
                       var todo = {
                           text: $('#tb-todo-text').val(),
                           category: $('#tb-todo-category').val()
                       };
                       data.todos.add(todo)
                           .then(function () {
                              // console.log(todo);
                               context.redirect('#/todos');
                               document.location.reload(true);
                           });
                       
                   });
               });
        });
//-------------------------------------------------------------
        this.get('#/events', function () {;
            templates.get('events')
                .then(function (template) {
                    $("#content").html(template());
                });
        });
    });

    $(function () {
        sammyApp.run('#/home');
        if (data.user.isLogged()) {
            $('#login_reg_btn')
              .addClass('hidden');
        } else {
            $('#logout_btn')
              .addClass('hidden');
        }

        $('#logout_btn').on('click', function () {
            data.user.logout()
              .then(function () {
                  location = '#/';
                  document.location.reload(true);
              });
        });
    });
}());
