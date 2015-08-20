function solve() {

     var Item = (function (parent) {
         //var id = 1;
         var idInc = 1;
         var Item = Object.create(parent, {
            name:{
                get: function(){
                    return this._name;
                },
                set: function(name){
                    if (typeof name !== "string") {
                        throw new Error("not a string");
                        return;
                    };
                    if (name.length < 2 || name.length > 40) {
                        throw new Error("name [2;40]");
                        return;
                    };
                    this._name = name;
                }
            },
            description:{
                get: function(){
                    return this._description;
                },
                set: function(description){
                    if (typeof description !== "string") {
                        throw new Error("not a string");
                        //return;
                    };
                    if (description.length < 1) {
                        throw new Error("descr is empty str");
                        //return;
                    };
                    this._description = description;
                }

            }
        });
        Item.init = function (name, description) {
            this.id = idInc;
            idInc++;
            this.name = name;
            this.description = description;
            return this;
        };
        return Item;

     }({}));
     "---------------------------------------------------------------"
     var Book = (function (parent) {
        var Book = Object.create(parent, {
            isbn: {
                get: function () {
                    return this._isbn;
                },
                set: function (isbn) {
                    if (typeof isbn !== "string") {
                        throw new Error("not a string");
                    };
                    if (isbn.length !== 10 && isbn.length !== 13) {
                        throw new Error("isbn 10 || 13");
                    };
                    if (isbn.match(/^[0-9]+$/) == null) {
                        throw new Error("isbn only digits");
                    };
                    this._isbn = isbn;
                }
            },
            genre: {
                get: function () {
                    return this._genre;
                },
                set: function (genre) {
                    if (typeof genre !== "string") {
                        throw new Error("not a string");
                    };
                    if (genre.length < 2 || genre.length > 20) {
                        throw new Error("name [2;40]");
                    };
                    this._genre = genre;
                }
            }
        });

        Book.init = function (name, isbn, genre, description) {
            parent.init.call(this, name, description);
            this.isbn = isbn;
            this.genre = genre;
            return this;
        };

        return Book;
    }(Item));
     "---------------------------------------------------------------"
     var Media = (function (parent) {
        var Media = Object.create(parent, {
            rating: {
                get: function () {
                    return this._rating;
                },
                set: function (rating) {
                    if (isNaN(rating) == true) {
                        throw new Error("rating or duration NaN");
                    };
                    if (rating < 1 || rating > 5) {
                        throw new Error("ratin[1;5]");
                    };
                    this._rating = rating;
                }
            },
            duration: {
                get: function () {
                    return this._duration;
                },
                set: function (duration) {
                    if (isNaN(duration) == true) {
                        throw new Error("rating or duration NaN");
                    }
                    if (duration <= 0) {
                        throw new Error("duration > 0!");
                    };
                    this._duration = duration;
                }
            }
        });
        Media.init = function (name, rating, duration, description) {
            parent.init.call(this, name, description);
            this.rating = rating;
            this.duration = duration;
            return this;
        }
        return Media;
    }(Item));
     "---------------------------------------------------------------"
     "---------------------------------------------------------------"
     var Catalog = (function() {
         var id = 1;

         function Catalog(name) {
             if (!(typeof name === "string")) {
                 throw new Error("not a string");
                 return;
             };
             if (name.length < 2 || name.length > 40) {
                 throw new Error("name [2;40]");
                 return;
             };
             this.name = name;
             this.items = [];
             this.id = id;
             id++;
         }

         Catalog.prototype.add = function() {
             if (arguments.length === 0) {
                 throw new Error("0 args given");
                 return;
             };
             //case array
             for (var i = 0; i < arguments.length; i++) {
                 //case one given instance of item
                 if (arguments.length === 1 && arguments[i] instanceof Item) {
                     this.items.push(arguments[i]);
                     return;
                 } //case arr
                 else if (arguments.length === 1 && arguments[i] instanceof Array) {
                     var itemsToAdd = arguments[i];
                     if (itemsToAdd.length === 0) {
                         throw new Error("empty arr");
                         return;
                     };
                     for (var j = 0; j < itemsToAdd.length; j++) {
                         if (!(itemsToAdd[j] instanceof Item)) {
                             throw new Error("not Item instance");
                             return;
                         };
                     };
                     for (var k = 0; k < itemsToAdd.length; k++) {
                         this.items.push(itemsToAdd[k]);
                     };
                     return;
                 } else {
                     for (var l = 0; l < arguments.length; l++) {
                         if (!(arguments[l] instanceof Item)) {
                             throw new Error("not Item instance");
                             return;
                         };
                     };
                     for (var m = 0; m < arguments.mength; m++) {
                         this.items.push(arguments[m]);
                     };
                 }
             };

         };
         Catalog.prototype.find = function(type) {
             var arrToReturn = [];
             for (var i = 0; i < this.items.length; i++) {
                 if (this.items[i].id === type) {
                     arrToReturn.push(this.items[i]);
                 }
             };
             return arrToReturn;
         }
         Catalog.prototype.search = function(pattern) {}
         return Catalog;
     }());
     "---------------------------------------------------------------"
     var BookCatalog = (function(parent) {
         function BookCatalog(name) {
             parent.call(this, name);
         }

         //BookCatalog.prototype = parent.prototype;
         BookCatalog.prototype.add = function() {
             if (arguments.length === 0) {
                 throw new Error("0 args given");
                 return;
             };
             //case array
             for (var i = 0; i < arguments.length; i++) {
                 if (arguments.length === 1 && arguments[i] instanceof Array) {
                     var itemsToAdd = arguments[i];
                     if (itemsToAdd.length === 0) {
                         throw new Error("empty arr");
                         return;
                     } else {
                         for (var j = 0; j < itemsToAdd.length; j++) {
                             if (!(itemsToAdd[j] instanceof Book)) {
                                 throw new Error("not Book instance");
                                 return;
                             };
                         };
                         for (var k = 0; k < itemsToAdd.length; k++) {
                             this.items.push(itemsToAdd[k]);
                         };
                         return;
                     }
                 } else {
                     for (var l = 0; l < arguments.length; l++) {
                         if (!(arguments[l] instanceof Book)) {
                             throw new Error("not Book instance");
                             return;
                         }


                     };
                     for (var m = 0; m < arguments.length; m++) {
                         this.items.push(arguments[m]);
                     };
                 }
             };
         }
         BookCatalog.prototype.getGenres = function() {
             var arrToReturn = [];

             for (var i = 0; i < this.items.length; i++) {
                 if (arrToReturn.indexOf(this.items[i].genre) < 0) {
                     arrToReturn.push(this.items[i].genre.toLowerCase());
                 };
             };
             return arrToReturn;
         }

         BookCatalog.prototype.find = function(type) {
             var arrToReturn = [];
             for (var i = 0; i < this.items.length; i++) {
                 if (this.items[i].genre === type) {
                     arrToReturn.push(this.items[i]);
                 } else if (this.items[i].id === type) {
                     arrToReturn.push(this.items[i]);
                 } else if (this.items[i].name === type) {
                     arrToReturn.push(this.items[i]);
                 }
             };
             return arrToReturn;
         }
         return BookCatalog;
     }(Catalog));
     "---------------------------------------------------------------"
     var MediaCatalog = (function(parent) {
         function MediaCatalog(name) {
             parent.call(this, name);
         }

         // MediaCatalog.prototype = parent.prototype;
         MediaCatalog.prototype.add = function() {
             if (arguments.length === 0) {
                 throw new Error("0 args given");
                 return;
             };
             //case array
             for (var i = 0; i < arguments.length; i++) {
                 if (arguments.length === 1 && arguments[i] instanceof Array) {
                     var itemsToAdd = arguments[i];
                     if (itemsToAdd.length === 0) {
                         throw new Error("empty arr");
                         return;
                     } else {
                         for (var j = 0; j < itemsToAdd.length; j++) {
                             if (!(itemsToAdd[j] instanceof Media)) {
                                 throw new Error("not Media instance");
                                 return;
                             };
                         };
                         for (var k = 0; k < itemsToAdd.length; k++) {
                             this.items.push(itemsToAdd[k]);
                         };
                         return;
                     }
                 } else {
                     for (var l = 0; l < arguments.length; l++) {
                         if (!(arguments[l] instanceof Media)) {
                             throw new Error("not Media instance");
                             return;
                         }
                     };
                     for (var m = 0; m < arguments.length; m++) {
                         this.items.push(arguments[m]);
                     };
                 }
             };
         }
         MediaCatalog.prototype.getTop = function(count) {

         };
         MediaCatalog.prototype.getSortedByDuration = function() {

         };
         return MediaCatalog;
     }(Catalog));

     return {
         getBook: function (name, isbn, genre, description) {
            return Object.create(Book)
                .init(name, isbn, genre, description);
         },
         getMedia: function(name, rating, duration, description) {
             return Object.create(Media)
                .init(name, rating, duration, description);
         },
         getBookCatalog: function(name) {   
             return new BookCatalog(name);
         },
         getMediaCatalog: function(name) {
             return new MediaCatalog(name);
         }
     };
 }
module.exports = solve;
// var module = solve();



// var media = module.getMedia("asdas",2, 5, "asdasdas");

// var catalog = module.getBookCatalog('John\'s catalog');

//  var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
// var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
// catalog.add(book1);
// catalog.add(book2);

// console.log(catalog.find(book1.id));
// //returns book1

// console.log(catalog.find({id: book2.id, genre: 'IT'}));
// //returns book2

// console.log(catalog.search('js')); 
// // returns book2

// console.log(catalog.search('javascript'));
// //returns book1 and book2

// console.log(catalog.search('Te sa zeleni'))
// //returns []