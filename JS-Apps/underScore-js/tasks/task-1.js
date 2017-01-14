
/* 
Create a function that:
*   Takes an array of students
    *   Each student has a `firstName` and `lastName` properties
*   **Finds** all students whose `firstName` is before their `lastName` alphabetically
*   Then **sorts** them in descending order by fullname
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   Then **prints** the fullname of founded students to the console
*   **Use underscore.js for all operations**
*/
var _ = require("underscore");

function solve(){
  return function (students) {
  	function isFirstNameBeforeLastNameAlpabetically(student){
  		return student.firstName < student.lastName;
  	}

  	var studentsWithFirstNameBeforeLastname = _.filter(students, isFirstNameBeforeLastNameAlpabetically);
  	var fullNamesOfStudents = _.map(studentsWithFirstNameBeforeLastname, function(student){
  		return student.firstName + " " + student.lastName;
  	});

  	var sortedFullNames = _.sortBy(fullNamesOfStudents, function(fullName){
  		return fullName;
  	}).reverse();
  	_.each(sortedFullNames, function(item) { console.log(item);
  	})

  };
};

module.exports = solve;