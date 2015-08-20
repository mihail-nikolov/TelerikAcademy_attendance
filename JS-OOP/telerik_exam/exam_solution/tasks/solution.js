 function solve() {
 	
     var Item = (function() {
         var id = 1;

         function Item(name, description) {
             if (typeof description !== "string") {
                 throw new Error("not a string");
             };
             if (typeof name !== "string") {
                throw new Error("not a string");
             };
             if (description.length < 1) {
                 throw new Error("descr is empty str");
             };
             if (name.length < 2 || name.length > 40) {
                 throw new Error("name [2;40]");
             };

             this.description = description;
             this.name = name;
             this.id = id;
             id++;
         }
         return Item;
     }());
     "---------------------------------------------------------------"
     var Book = (function(parent) {
         function Book(name, isbn, genre, description) {
             if (!(typeof isbn === "string") || !(typeof genre === "string")) {
                 throw new Error("not a string");
             };
             if (isbn.length !== 10 && isbn.length !== 13) {
                 throw new Error("isbn 10 || 13");
             };
             if (isbn.match(/^[0-9]+$/) == null) {
                 throw new Error("isbn only digits");
             };
             if (genre.length < 2 || genre.length > 20) {
                 throw new Error("name [2;40]");
             };
             parent.call(this, name, description);
             this.isbn = isbn;
             this.genre = genre;
         }
         return Book;
     }(Item));
     "---------------------------------------------------------------"
     var Media = (function(parent) {
         function Media(name, rating, duration, description) {
             if (isNaN(duration) == true || isNaN(rating) == true) {
                 throw new Error("rating or duration NaN");
                 return;
             }
             if (duration <= 0) {
                 throw new Error("duration > 0!");
                 return;
             };
             if (rating < 1 || rating > 5) {
                 throw new Error("ratin[1;5]");
                 return;
             };
             parent.call(this, name, description);
             this.duration = duration;
             this.rating = rating;
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
         getBook: function(name, isbn, genre, description) {
             return new Book(name, isbn, genre, description)
         },
         getMedia: function(name, rating, duration, description) {
             return new Media(name, rating, duration, description);
         },
         getBookCatalog: function(name) {
             return new BookCatalog(name);
         },
         getMediaCatalog: function(name) {
             return new MediaCatalog(name);
         }
     };
 }

 "---------------------------------------------------------------"
 "---------------------------------------------------------------"
 "---------------------------------------------------------------"
module.exports = solve;
 // var module = solve();
 // var catalog = module.getBookCatalog('John\'s catalog');

 // var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
 // var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
 // var myMedia = module.getMedia("name", 2, 3, "description")
 // catalog.add(book1);
 // catalog.add(book2);
 // console.log(catalog.find(book1.id));
 // console.log(catalog.getGenres());
 // //returns book1

 // console.log(catalog.find({
 //     id: book2.id,
 //     genre: 'IT'
 // }));
 // //returns book2

 // console.log(catalog.search('js'));
 // // returns book2

 // console.log(catalog.search('javascript'));
 // //returns book1 and book2

 // console.log(catalog.search('Te sa zeleni'))
 //     //returns []
