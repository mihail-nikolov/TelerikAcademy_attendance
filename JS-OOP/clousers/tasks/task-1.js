/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
    var library = (function() {
        var books = [];
        var categories = [];
        var category = [];

        function listBooks(property) {
            books = books.sort(function(a, b) {
                return a.ID - b.ID;
            });

            if (arguments.length > 0) {
                if (typeof property.category !== 'undefined') {
                    var booksToList = [];

                    for (var k = 0, len = books.length; k < len; k += 1) {
                        if (books[k].category === property.category) {
                            booksToList.push(books[k]);
                        }
                    }
                    return booksToList;
                }

                if (typeof property.author !== 'undefined') {

                    var booksToList = [];

                    for (var ind = 0, len = books.length; ind < len; ind += 1) {
                        if (books[ind].author === property.author) {
                            booksToList.push(books[ind]);
                        }
                    }
                    return booksToList;
                }
            }

            return books;
        }

        function addBook(book) {
            if (book.title.length < 3 || book.title.length > 100) {
                throw new Error();
            };

            for (var i = 0; i < books.length; i = i + 1) {
                if (books[i].title == book.title) {
                    throw new Error();
                };
            };

            if (book.author.length <= 0) {
                throw new Error();
            }

            if (book.isbn.length !== 10 && book.isbn.length !== 13) {
                throw new Error();
            }

            for (var i = 0; i < books.length; i = i + 1) {
                if (books[i].isbn == book.isbn) {
                    throw new Error();
                };
            };

            book.ID = books.length + 1;
            books.push(book);


            var newCategory = {
                category: book.category,
                ID: categories.length + 1
            }

            var newCategory = {
                category: book.category,
                ID: categories.length + 1
            }

            var counter = 0;
            for (var k = 0; k < categories.length; k = k + 1) {
                if (categories[k].category.toString() == newCategory.category.toString()) {
                    counter++;
                };
            };

            if (counter == 0) {
                categories.push(newCategory);
            }

            return book;
        }

        function listCategories() {
            categories = categories.sort(function(a, b) {
                return a.ID - b.ID;
            });

            return categories.map(function(element) {
                return element.category;
            })
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    }());
    return library;
}

module.exports = solve;
