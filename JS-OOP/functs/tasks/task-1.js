/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

// function() {

//     return function sum(numbers) {
//         if (numbers.length === 0) {
//             return null;
//         }

//         return numbers.reduce(function(s, n) {
//                 n = +n;
//                 if (n != n) {
//                     throw new Error();
//                 }
//                 return s + n;
//             },
//             0);
//     }
// }
function sum(numbers) {
    if (numbers.length === 0) {
        return null;
    }

    return numbers.reduce(function(s, n) {
            n = +n;
            if (n != n) {
                throw new Error();
            }
            return s + n;
        },
        0);
}


module.exports = sum;
