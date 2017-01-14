//  function solve() {

//  function isValidID(ID) {
//         var x;
//         if (isNaN(ID)) {
//             return false;
//         }
//         x = parseFloat(ID);
//         return (x | 0) === x;
//     }

//     function isValidNameTitleAuthor(value) {
//         if (!(typeof value == "string")) {
//             return false
//         };
//         if (!(value.length >= 3 && value.length <= 25)) {
//             return false;
//         };
//         return true;
//     }

//     var Player = (function() {
//         function Player(name) {
//             if (isValidNameTitleAuthor(name) == false) {
//                 throw new Error();
//                 return;
//             };
//             this.name = name;
//             this.playLists = [];
//         }

//         Player.prototype.addPlaylist = function(playlistToAdd) {
//             if (!(playlistToAdd instanceof Playlist)) {
//                 throw new Error();
//                 return;
//             };
//             this.playLists.push(playlistToAdd);
//         }

//         Player.prototype.getPlaylistById = function(id) {
//             for (var i = 0; i < this.playLists.length; i++) {
//                 if (this.playLists[i].id === id) {
//                     return this.playLists[i];
//                 };
//             };
//             return null;
//         }

//         Player.prototype.removePlaylist = function(value) {

//             var id = value;

//             if ((!isValidID(value))) {
//                 if (!(value instanceof Playlist)) {
//                     throw new Error();
//                     return;
//                 };
//                 id = value.id;
//             }

//             for (var i = 0; i < this.playLists.length; i++) {
//                 if (this.playLists[i].id === id) {
//                     this.playLists.splice(i, 1);
//                     return;
//                 };
//             };
//             throw new Error();
//         }


//         return Player;
//     }());

//     var Playlist = (function() {
//         var id = 1;

//         function Playlist(name) {
//             if (isValidNameTitleAuthor(name) == false) {
//                 throw new Error();
//                 return;
//             };
//             this.name = name;
//             this.id = id;
//             id++;
//         }
//         return Playlist;

//     }());

// var module = {

//     getPlayer: function(name) {
//             return new Player(name);
//             // returns a new player instance with the provided name
//         },
//         getPlaylist: function(name) {
//             return new Playlist(name);
//         },
//         getAudio: function(title, author, length) {
//             //returns a new audio instance with the provided title, author and length
//         },
//         getVideo: function(title, author, imdbRating) {
//             //returns a new video instance with the provided title, author and imdbRating
//         }
// };
// return module;
//  }
// solve();

function isValidID(ID) {
    var x;
    if (isNaN(ID)) {
        return false;
    }
    x = parseFloat(ID);
    return (x | 0) === x;
}

function isValidNameTitleAuthor(value) {
    if (!(typeof value == "string")) {
        return false
    };
    if (!(value.length >= 3 && value.length <= 25)) {
        return false;
    };
    return true;
}

var Player = (function() {
    function Player(name) {
        if (isValidNameTitleAuthor(name) == false) {
            throw new Error();
            return;
        };
        this.name = name;
        this.playLists = [];
    }

    Player.prototype.addPlaylist = function(playlistToAdd) {
        if (!(playlistToAdd instanceof Playlist)) {
            throw new Error();
            return;
        };
        this.playLists.push(playlistToAdd);
    }

    Player.prototype.getPlaylistById = function(id) {
        for (var i = 0; i < this.playLists.length; i++) {
            if (this.playLists[i].id === id) {
                return this.playLists[i];
            };
        };
        return null;
    }

    Player.prototype.removePlaylist = function(value) {
        var id = value;

        if ((!isValidID(value))) {
            if (!(value instanceof Playlist)) {
                throw new Error();
                return;
            };
            id = value.id;
        }

        for (var i = 0; i < this.playLists.length; i++) {
            if (this.playLists[i].id === id) {
                this.playLists.splice(i, 1);
                return;
            };
        };
        throw new Error();
    }
    return Player;
}());


var Playlist = (function() {
    var id = 1;

    function Playlist(name) {
        if (isValidNameTitleAuthor(name) == false) {
            throw new Error();
            return;
        };
        this.name = name;
        this.id = id;
        id++;
    }
    return Playlist;
}());


var Playable = (function() {
    var id = 1;

    function Playable(title, author) {
        if (isValidNameTitleAuthor(title) == false) {
            throw new Error();
            return;
        };
        if (isValidNameTitleAuthor(author) == false) {
            throw new Error();
            return;
        };
        this.title = title;
        this.author = author;
        this.id = id;
        id++;
    }
    Playable.prototype.play = function() {
        return this.id + '. ' + this.title + ' - ' + this.author;
    };
    return Playable;
}());


var Audio = (function(parent) {
    function Audio(title, author, len) {
        if (isNaN(len) || len < 0) {
            throw new Error();
            return;
        };
        parent.call(this, title, author);
        this.len = len;
    }
    Audio.prototype = parent.prototype;
    
    Audio.prototype.play = function() {
        //var baseResult = parent.prototype.play.call(this);
        return this.id + '. ' + this.title + ' - ' + this.author + ' - ' + this.len;
        //return baseResult +' - '  + this.len;
    }
    
    return Audio;
}(Playable));


var myPlayer = new Player("asdasd");
var myPlaylist = new Playlist("playlist1");
var myPlaylist1 = new Playlist("playlist2");

myPlayer.addPlaylist(myPlaylist);


console.log(myPlayer.getPlaylistById(1));
console.log(myPlayer.getPlaylistById(-2));
console.log(myPlayer.removePlaylist(myPlaylist));

// var enterSandman = new Playable("enterSandman","Metallica");
// console.log(enterSandman.id);
// console.log(enterSandman.author);
// console.log(enterSandman.play());

// var forWhom = new Playable("forWhomTheBellTolls","Metallica");
// console.log(forWhom.id);
// console.log(forWhom.author);
// console.log(forWhom.play());

var myAudio = new Audio("For whom the bell tolls", "Metallica", 3);
//console.log(myAudio.play());
console.log(myAudio.play());