/* 
Create a function that:
*   **Takes** an array of animals
    *   Each animal has propeties `name`, `species` and `legsCount`
*   **groups** the animals by `species`
    *   the groups are sorted by `species` descending
*   **sorts** them ascending by `legsCount`
	*	if two animals have the same number of legs sort them by name
*   **prints** them to the console in the format:

```
    ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
    GROUP_1_NAME:
    ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
    NAME has LEGS_COUNT legs //for the first animal in group 1
    NAME has LEGS_COUNT legs //for the second animal in group 1
    ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
    GROUP_2_NAME:
    ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
    NAME has LEGS_COUNT legs //for the first animal in the group 2
    NAME has LEGS_COUNT legs //for the second animal in the group 2
    NAME has LEGS_COUNT legs //for the third animal in the group 2
    NAME has LEGS_COUNT legs //for the fourth animal in the group 2
```
*   **Use underscore.js for all operations**
*/
var _ = require("underscore");

function solve(){
  return function (animals) {
    var sortedSpeciesDescending = _.sortBy(animals, "species").reverse();
    var groupedBySpecies = _.groupBy(sortedSpeciesDescending,'species');
    _.forEach(groupedBySpecies, function(value, key){
        var divider = function(len){
            var dashString = "";
            for (var i = 0; i < len + 1; i++) {
                dashString += "-";
            };
            return dashString;
        }(key.length);
        console.log(divider);
        console.log(key + ":");
        console.log(divider);
        var groupArr = groupedBySpecies[key];
        var sortedByLegsThenByName = _.chain(groupArr)
        .sortBy("name")
        .sortBy("legsCount")
        .value();
        _.each(sortedByLegsThenByName, function(animal){
            console.log(animal.name + " has " + animal.legsCount  + " legs");
        })
    })
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