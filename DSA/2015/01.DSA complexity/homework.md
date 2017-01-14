##Data Structures, Algorithms and Complexity Homework##

**1. What is the expected running time of the following C# code?**

Explain why using Markdown.
Assume the array's size is n.


	long Compute(int[] arr)
	{
	    long count = 0;
	    for (int i=0; i<arr.Length; i++)
	    {
	        int start = 0, end = arr.Length-1;
	        while (start < end)
	            if (arr[start] < arr[end])
	                { start++; count++; }
	            else 
	                end--;
	    }
	    return count;
	}

for loop - n times.
while loop (arr.length - 1 = n) - n times - 1 (in the worst case - the biggest one is at the end of the array)

`n*(n - 1)` -> `O(n^2)`

**2. What is the expected running time of the following C# code?**


Explain why using Markdown.
Assume the input matrix has size of n * m.

	long CalcCount(int[,] matrix)
	{
	    long count = 0;
	    for (int row=0; row<matrix.GetLength(0); row++)
	        if (matrix[row, 0] % 2 == 0)
	            for (int col=0; col<matrix.GetLength(1); col++)
	                if (matrix[row,col] > 0)
	                    count++;
	    return count;
	}

first loop - n times.
second loop  - m times - 1

`n*(m)` -> `O(n*m)`

**3.** (*) **What is the expected running time of the following C# code?**
	
Explain why using Markdown.
Assume the input matrix has size of `n * m`.


	long CalcSum(int[,] matrix, int row)
	{
	    long sum = 0;
	    for (int col = 0; col < matrix.GetLength(0); col++) 
	        sum += matrix[row, col];
	    if (row + 1 < matrix.GetLength(1)) 
	        sum += CalcSum(matrix, row + 1);
	    return sum;
	}
	
	Console.WriteLine(CalcSum(matrix, 0));

worst case - n=m;
if case - the function will call itself m times => will call first loop n times
`n*(m)` -> `O(n*m)`