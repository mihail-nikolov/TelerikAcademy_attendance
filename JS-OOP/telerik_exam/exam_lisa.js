function solve() {
    if (!Array.prototype.find) {
        Array.prototype.find = function(predicate) {
            if (this == null) {
                throw new TypeError('Array.prototype.find called on null or undefined');
            }
            if (typeof predicate !== 'function') {
                throw new TypeError('predicate must be a function');
            }
            var list = Object(this);
            var length = list.length >>> 0;
            var thisArg = arguments[1];
            var value;

            for (var i = 0; i < length; i++) {
                value = list[i];
                if (predicate.call(thisArg, value, i, list)) {
                    return value;
                }
            }
            return undefined;
        };
    }

    if (!Array.prototype.findIndex) {
        Array.prototype.findIndex = function(predicate) {
            if (this == null) {
                throw new TypeError('Array.prototype.findIndex called on null or undefined');
            }
            if (typeof predicate !== 'function') {
                throw new TypeError('predicate must be a function');
            }
            var list = Object(this);
            var length = list.length >>> 0;
            var thisArg = arguments[1];
            var value;

            for (var i = 0; i < length; i++) {
                value = list[i];
                if (predicate.call(thisArg, value, i, list)) {
                    return i;
                }
            }
            return -1;
        };
    }

    function isStringEmpty(str) {
        return str.length <= 0;
    }

    function isStringValid(str, minLength, maxLength) {
        return typeof(str) === 'string' &&
            str.length >= minLength &&
            str.length <= maxLength;
    }

    function isIsbnValid(str) {
        var digitsOnly = /^[0-9]+$/;
        return typeof(str) === 'string' &&
            str.match(digitsOnly) !== null &&
            (str.length === 10 || str.length === 13);
    }

    function isValidItem(item) {
        if (typeof(item) === 'undefined' || (item.type() !== 'Item')) {
            throw {
                name: 'Invalid item',
                message: 'Item is not defined or is not an Item or Item-like object'
            };
        }
    }

    function isValidBook(item) {
        if (typeof(item) === 'undefined' || (item.subtype() !== 'Book')) {
            throw {
                name: 'Invalid book',
                message: 'Item is not defined or is not an Book or Book-like object'
            };
        }
    }

    function isValidMedia(item) {
        if (typeof(item) === 'undefined' || (item.subtype() !== 'Media')) {
            throw {
                name: 'Invalid book',
                message: 'Item is not defined or is not an Book or Book-like object'
            };
        }
    }

    var Item = function() {
        var currentId = 0,
            Item = {
                init: function(description, name) {
                    this.id = currentId += 1;
                    this.description = description;
                    this.name = name;
                    return this;
                },

                get description() {
                    return this._description;
                },
                set description(newDescription) {
                    if (isStringEmpty(newDescription)) {
                        throw {
                            name: 'Invalid description',
                            message: 'String is empty'
                        };
                    }
                    this._description = newDescription;
                },

                get name() {
                    return this._name;
                },
                set name(newName) {
                    if (!isStringValid(newName, 2, 40)) {
                        throw {
                            name: 'Invalid name',
                            message: 'String is not valid'
                        };
                    }
                    this._name = newName;
                },

                type: function() {
                    return 'Item';
                }
            }
        return Item;
    }();

    var Book = function(parent) {
        var Book = Object.create(parent);

        Book.init = function(name, isbn, genre, description) {
            parent.init.call(this, description, name);
            this.isbn = isbn;
            this.genre = genre;
            return this;
        };
        Book.subtype = function() {
            return 'Book';
        }
        Object.defineProperty(Book, 'isbn', {
            get: function() {
                return this._isbn;
            },
            set: function(newIsbn) {
                if (!isIsbnValid(newIsbn)) {
                    throw {
                        name: 'InvalidISBN',
                        message: 'Not a valid isbn'
                    };
                }
                this._isbn = newIsbn;
            }
        });

        Object.defineProperty(Book, 'genre', {
            get: function() {
                return this._genre;
            },
            set: function(newGenre) {
                if (!isStringValid(newGenre, 2, 20)) {
                    throw {
                        name: 'InvalidGenre',
                        message: 'Not a valid genre'
                    };
                }
                this._genre = newGenre;
            }
        });

        return Book;
    }(Item);

    var Media = function(parent) {
        var Media = Object.create(parent);

        Media.init = function(name, rating, duration, description) {
            parent.init.call(this, description, name);
            this.rating = rating;
            this.duration = duration;
            return this;
        };

        Media.subtype = function() {
            return 'Media';
        }

        Object.defineProperty(Media, 'duration', {
            get: function() {
                return this._duration;
            },
            set: function(newDuration) {
                if (typeof(newDuration) !== 'number' ||
                    newLength <= 0) {
                    throw {
                        name: 'InvalidDuration',
                        message: 'Not a number or not > 0'
                    };
                }
                this._duration = newDuration;
            }
        });

        Object.defineProperty(Media, 'rating', {
            get: function() {
                return this._rating;
            },
            set: function(newRating) {
                if (typeof(newRating) !== 'number' ||
                    newRating < 1 || newRating > 5) {
                    throw {
                        name: 'InvalidRating',
                        message: 'Not a number or not between 1 and 5 inclusive'
                    };
                }
                this._rating = newRating;
            }
        });

        return Media;

    }(Item);

    var Catalog = function() {
        var currentId = 0,
            Catalog = {
                init: function(name) {
                    this.id = currentId += 1;
                    this.name = name;
                    this.items = [];

                    return this;
                },

                get name() {
                    return this._name;
                },
                set name(newName) {
                    if (!isStringValid(newName, 2, 40)) {
                        throw {
                            name: 'Invalid name',
                            message: 'String is not valid'
                        };
                    }
                    this._name = newName;
                },
                //Should we have get and set for this property?!
                // get items() {
                //     return this._items;
                // },
                // set items() {
                //     this.items = [];
                // }

                add: function(items) {
                    if (typeof(items) === 'undefined') {
                        throw {
                            name: 'Invalid Items',
                            message: 'Invalid Items'
                        };
                    }

                    var itemsArray = [];
                    if (!Array.isArray(items)) {
                        for (var i = 0; i < arguments.length; i = i + 1) {
                            itemsArray.push(arguments[i]);
                        };
                    } else {
                        itemsArray = items;
                    }

                    if (itemsArray.length === 0) {
                        throw new Error("Empty array!");
                    }
                    for (var k = 0; k < itemsArray.length; k = k + 1) {
                        isValidItem(itemsArray[k]);
                    };

                    for (k = 0; k < itemsArray.length; k = k + 1) {
                        this.items.push(itemsArray[k]);
                    };

                    return this;
                },

                find: function(value) {
                    // Argument can be id or options
                    var id = value;
                    if (typeof(value) === 'undefined') {
                        throw {
                            name: 'InvalidIdError',
                            message: 'InvalidIdError'
                        };
                    }

                    if (typeof(value) !== 'number') {
                        id = value.id;

                    }
                    var index = this.items.findIndex(function(item) {
                        return item.id === id;
                    });

                    if (typeof(id) === 'undefined') {
                        id = value.name;
                        var index = this.items.findIndex(function(item) {
                            return item.name === id;
                        });
                    }

                    if (index < 0) {
                        throw {
                            name: 'InvalidIdError',
                            message: 'InvalidIdError'
                        };
                    }
                    return this.items[index];
                },

                search: function(pattern) {
                    pattern = pattern.toLowerCase();
                    var filteredItems = [];
                    for (var p = 0; p < this.items.length; p = p + 1) {
                        var item = this.items[p];
                        var byDescription = item.description
                            .toLowerCase()
                            .indexOf(pattern) >= 0;

                        var byName = item.name
                            .toLowerCase()
                            .indexOf(pattern) >= 0;

                        if (byDescription || byName) {
                            filteredItems.push(item);
                        }
                    };

                    // var byDescription = this.items.filter(function(item) {
                    //     return item.description
                    //         .toLowerCase()
                    //         .indexOf(pattern) >= 0;
                    // });
                    // var byName = this.items.filter(function(item) {
                    //     return item.name
                    //         .toLowerCase()
                    //         .indexOf(pattern) >= 0;
                    // });
                    // var filteredItems = byDescription.concat(byName);
                    // return this.items.filter(function(item) {
                    //     return item.description 
                    //         .toLowerCase()
                    //         .indexOf(pattern) >= 0;
                    // });
                    return filteredItems;
                }
            }

        return Catalog;
    }();

    var BookCatalog = function(parent) {
        var BookCatalog = Object.create(parent);

        BookCatalog.init = function(name) {
            parent.init.call(this, name);
            return this;
        };

        BookCatalog.add = function(items) {
            if (typeof(items) === 'undefined') {
                throw {
                    name: 'Invalid Items',
                    message: 'Invalid Items'
                };
            }

            var itemsArray = [];
            if (!Array.isArray(items)) {
                for (var i = 0; i < arguments.length; i = i + 1) {
                    itemsArray.push(arguments[i]);
                };
            } else {
                itemsArray = items;
            }

            if (itemsArray.length === 0) {
                throw new Error("Empty array!");
            }
            for (var k = 0; k < itemsArray.length; k = k + 1) {
                isValidBook(itemsArray[k]);
            };

            for (k = 0; k < itemsArray.length; k = k + 1) {
                this.items.push(itemsArray[k]);
            };
            return this;
        };

        BookCatalog.getGenres = function() {
            var genres = [];
            for (var g = 0; g < this.items.length; g = g + 1) {
                var genre = this.items[g].genre.toLowerCase();
                if (genres.indexOf(genre) === -1) {
                    genres.push(genre);
                }
            };

            return genres;
        }

        return BookCatalog;

    }(Catalog);

    var MediaCatalog = function(parent) {
        var MediaCatalog = Object.create(parent);

        MediaCatalog.init = function(name) {
            parent.init.call(this, name);
            return this;
        };

        MediaCatalog.add = function(items) {
            if (typeof(items) === 'undefined') {
                throw {
                    name: 'Invalid Items',
                    message: 'Invalid Items'
                };
            }

            var itemsArray = [];
            if (!Array.isArray(items)) {
                for (var i = 0; i < arguments.length; i = i + 1) {
                    itemsArray.push(arguments[i]);
                };
            } else {
                itemsArray = items;
            }

            if (itemsArray.length === 0) {
                throw new Error("Empty array!");
            }
            for (var k = 0; k < itemsArray.length; k = k + 1) {
                isValidMedia(itemsArray[k]);
            };

            for (k = 0; k < itemsArray.length; k = k + 1) {
                this.items.push(itemsArray[k]);
            };
            return this;
        };

        MediaCatalog.getTop = function(count) {
            if (typeof(count) !== 'number' || count < 1) {
                throw new Error('Not a valid count!');
            }

            var topCount = this.items.sort(function(item1, item2) {
                return item2.rating - item1.rating;
            });

            return topCount.slice(0, count + 1);

        };

        MediaCatalog.getSortedByDuration = function() {
            this.items.sort(function(item1, item2) {
                return item2.duration - item1.duration;
            }).sort(function(item1, item2) {
                return item1.id - item2.id;
            });

            return this.items;
        };

        return MediaCatalog;

    }(Catalog);

    return {
        getBook: function(name, isbn, genre, description) {
            //return a book instance
            return Object.create(Book)
                .init(name, isbn, genre, description);
        },
        getMedia: function(name, rating, duration, description) {
            //return a media instance
            return Object.create(Media)
                .init(name, rating, duration, description);
        },
        getBookCatalog: function(name) {
            //return a book catalog instance
            return Object.create(BookCatalog)
                .init(name);
        },
        getMediaCatalog: function(name) {
            //return a media catalog instance
            return Object.create(MediaCatalog)
                .init(name);
        }
    };
}

var module = solve();
var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
var books = []
books.push(book1);
books.push(book2);


catalog.add(books);
//console.log(catalog.items);
//catalog.add(book2);

console.log(catalog.find(book1.id));
// //returns book1

console.log(catalog.find({
    id: book2.id,
    genre: 'IT'
}));
// //returns book2

console.log(catalog.find({
    name: 'JavaScript: The Good Parts'
}));

//console.log(catalog.search('js'));
// // returns book2

//console.log(catalog.search('javascript'));
// //returns book1 and book2

//console.log(catalog.search('Te sa zeleni'))
//     //returns []
//console.log(catalog.getGenres());
