/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {

    function titleCheck(aTitle) {
        if (!(aTitle instanceof String)) {
            throw new Error();
        }
        if (aTitle.length > 1 && aTitle[0] != " " && aTitle[aTitle.length - 1] != " " && aTitle.match(/\s{2}/) !== null) {
            return true;
        }
        return false;
    }

    function nameCheck(name) {
        if (!(name instanceof String)) {
            throw new Error();
        }
        if (/^[a-zA-Z]+$/.test(name)) {
            if (name[0] === name[0].toUpperCase()) {
                if (name.length == 1) {
                    return true;
                };
                var lastChars = name.substr(1);
                if (lastChars === lastChars.toLowerCase()) {
                    return true;
                };
            };
        };
        return false;
    }

    function isInteger(data) {
        if (!(typeof data === "number")) {
            return false;
        };
        if (!(data % 1 === 0)) {
            return false;
        };
        return true;
    }


    function uniqueCheck(array){
    	var unique = array.filter(function(item, i, ar){ return ar.indexOf(item) === i; });
    	if (unique.toString() == array.toString()) {
    		return true;
    	};
    	return false;
    }

    var Course = {

        init: function(aTitle, givenPresent) {
            this.presentations = [];
            this.students = [];
            this.homeworks = [];
            this.examResults = [];
            var title;
            idCounter = 0;
            if (titleCheck(aTitle)) {
                title = aTitle;
            } else {
                throw new Error();
            }

            if (givenPresent instanceof Array) {
                if (givenPresent.length > 0) {
                    for (var i = 0; i < givenPresent.length; i++) {
                        if (titleCheck(givenPresent[i]) == false) {
                            throw new Error();
                            return;
                        };
                    }
                    presentations = givenPresent;

                };
            } else {
                throw new Error();
            }
        },

        addStudent: function(name) {
            var namesArr = name.split(" ");
            if (namesArr.length == 1) {
                var fname = namesArr[0];
                var lname = namesArr[1];
                if (nameCheck(fname) && nameCheck(lname)) {
                    idCounter++;
                    students.push({
                        firstname: fname,
                        lastname: lname,
                        id: idCounter
                    })
                    return idCounter;
                };
            } else {
                throw new Error();
            }
        },

        getAllStudents: function() {
            return students;
        },

        submitHomework: function(studentID, homeworkID) {
            if (isInteger(studentID) == false || isInteger(homeworkID) == false) {
                throw new Error();
                return;
            }
            if (homeworkID < 0 || homeworkID >= this.presentations.length) {
                throw new Error();
                return;
            };
            if (studentID < 0 || studentID >= this.students.length) {
                throw new Error();
                return;
            };
            if (!(studentID in this.homeworks)) {
                this.homeworks.push({
                    studentID: []
                });
            }
            var homeworkIndex = this.homeworks.studentID.indexOf(homeworkID);
            if (homeworkIndex > -1) { //homework is already added
                this.homeworks.studentID[homeworkID] = homeworkID; //replace the old homework with the new one
            } else {
                this.homeworks.studentID.push(homeworkID);
            }

        },
        pushExamResults: function(results) {
        	if(!(givenPresent instanceof Array)){
        		throw new Error();
                return;
        	}
        	var inputStudentIDs = [];
            for (var i = 0; i < results.length; i++) {
            	var student = results[i];
            	inputStudentIDs.push(student.studentID);
            	if (isNaN(student.score)) {
            		throw new Error();
                    return;
            	};
            	if (isInteger(student.studentID) == false) {
                    throw new Error();
                    return;
                }
                if (student.studentID < 0 || student.studentID >= this.students.length) {
                    throw new Error();
                    return;
                };
            };
            if (uniqueCheck(inputStudentIDs) == false) {
            	throw new Error();
                return;
            };
            this.examResults = results;

            


        },
        getTopStudents: function() {}
    };

    return Course;
}


module.exports = solve;
