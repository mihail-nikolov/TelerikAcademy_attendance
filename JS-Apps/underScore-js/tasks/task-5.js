/* 
Create a function that:
*   **Takes** an array of animals
    *   Each animal has propeties `name`, `species` and `legsCount`
*   **finds** and **prints** the total number of legs to the console in the format:
    *   "Total number of legs: TOTAL_NUMBER_OF_LEGS"
*   **Use underscore.js for all operations**
*/

var _ = require("underscore")

function solve(){
  return function (animals) {
  	var totalNumOfLegs = 0;
  	_.each(animals, function(animal){
  		totalNumOfLegs += animal.legsCount;
  	});
  	console.log("Total number of legs: " + totalNumOfLegs);
  };
};

// var animals = [{
//             name: 'Minkov',
//             species: 'Mosquito',
//             legsCount: 2
//         }, {
//             name: 'Doncho',
//             species: 'Bogomolka',
//             legsCount: 2
//         }, {
//             name: 'Komara2',
//             species: 'Mosquito',
//             legsCount: 4
//         },{
//             name: 'Komara',
//             species: 'Dog',
//             legsCount: 4
//         },{
//             name: 'Komara1',
//             species: 'Mosquito',
//             legsCount: 4
//         }
//         ];
module.exports = solve;
// var myfunc = solve();
// myfunc(animals);
