/* Task description */
/*
    Write a function that finds all the prime numbers in a range
        1) it should return the prime numbers in an array
        2) it must throw an Error if any on the range params is not convertible to `Number`
        3) it must throw an Error if any of the range params is missing
*/

// function() {

//     return function findPrimes(a, b) {
//         var n,
//             isPrime,
//             divisor,
//             maxDivisor,
//             primes = [];

//         if (typeof(a) === 'undefined' || typeof(b) === 'undefined') {
//             throw new Error();
//         };

//         a = parseInt(a);
//         b = parseInt(b);

//         for (var n = a; n <= b; n = n + 1) {
//             maxDivisor = Math.sqrt(n);
//             //console.log(maxDivisor)
//             isPrime = true;
//             for (divisor = 2; divisor <= maxDivisor; divisor += 1) {
//                 if (n % divisor == 0) {
//                     isPrime = false;
//                     //console.log(isPrime)
//                     break;
//                 }
//             }

//             if (n > 1 && isPrime) {
//                 primes.push(n);
//             }

//         };
//         return primes;
//     }

// }


function findPrimes(a, b) {
        var n,
            isPrime,
            divisor,
            maxDivisor,
            primes = [];

        if (typeof(a) === 'undefined' || typeof(b) === 'undefined') {
            throw new Error();
        };

        a = parseInt(a);
        b = parseInt(b);

        for (var n = a; n <= b; n = n + 1) {
            maxDivisor = Math.sqrt(n);
            //console.log(maxDivisor)
            isPrime = true;
            for (divisor = 2; divisor <= maxDivisor; divisor += 1) {
                if (n % divisor == 0) {
                    isPrime = false;
                    //console.log(isPrime)
                    break;
                }
            }

            if (n > 1 && isPrime) {
                primes.push(n);
            }

        };
        return primes;
    }


module.exports = findPrimes;

//console.log(findPrimes(1, 5));
