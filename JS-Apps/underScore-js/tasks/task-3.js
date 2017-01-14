/* 
Create a function that:
*   Takes an array of students
    *   Each student has:
        *   `firstName`, `lastName`, `age` and `marks` properties
        *   `marks` is an array of decimal numbers representing the marks         
*   **finds** the student with highest average mark (there will be only one)
*   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

var _ = require("underscore");

function solve() {
    return function(students) {



        function isStudentMatchTheAge(student) {
            if (student.age >= 18 && student.age <= 24) {
                return true;
            } else {
                return false;
            }
        };

        function getAverageScore(marks) {
            return _.reduce(marks, function(a, b) {
                return a + b;
            }) /marks.length;
        };	
        

        var sortedStudents = _.sortBy(students,function(student){
        	var avgScore = getAverageScore(student.marks);
        	return avgScore;
        });
        var theAStudent = _.last(sortedStudents, 1);

        var theAstudentAvgScore = getAverageScore(theAStudent[0].marks);
        console.log(theAStudent[0].firstName + " " + theAStudent[0].lastName + " has an average score of " + theAstudentAvgScore);
    };
};

module.exports = solve;


// var students = [{
// 			firstName: 'Stanimir',
// 			lastName: 'Jakov',
// 			age: 24,
// 			marks: [6, 3]
// 		}, {
// 			firstName: 'Stanimir',
// 			lastName: 'Jakov',
// 			age: 17,
// 			marks: [5, 4]
// 		}, {
// 			firstName: 'Frederick',
// 			lastName: 'Jacob',
// 			age: 1,
// 			marks: [4.2]
// 		}, {
// 			firstName: 'Joukahainen',
// 			lastName: 'Valerian',
// 			age: 1,
// 			marks: [4]
// 		}, {
// 			firstName: 'Teodor',
// 			lastName: 'Mervyn',
// 			age: 8,
// 			marks: [6]
// 		}, {
// 			firstName: 'Kristaps',
// 			lastName: 'lfsige',
// 			age: 30,
// 			marks: [7.3]
// 		}, {
// 			firstName: 'Varnava',
// 			lastName: 'Peter',
// 			age: 42,
// 			marks: [3]
// 		}, {
// 			firstName: 'Aibek',
// 			lastName: 'Patricio',
// 			age: 9,
// 			marks: [7]
// 		}, {
// 			firstName: 'Lovre',
// 			lastName: 'Thoko',
// 			age: 11,
// 			marks: [2]
// 		}, {
// 			firstName: 'Ambrosius',
// 			lastName: 'Volos',
// 			age: 26,
// 			marks: [4]
// 		}];
// var myfunc = solve();
// myfunc(students);