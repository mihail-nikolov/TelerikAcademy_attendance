using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		int num = int.Parse(Console.ReadLine());
		
		if (0 < num && num < 100000)
		{			
          	string jedisString = Console.ReadLine();		

          	string[] jedis = jedisString.Split(' ');          		
		
			var jedisSorted = jedis
				.OrderBy(j => GetSortNumber(j));				
			
			string result = string.Join(" ", jedisSorted);
				
		 	Console.WriteLine(result);			
		}						
	}
	
	public static int GetSortNumber(string j) 
	{
		string master = "m";
        string jediKnight = "k";
        string padawan = "p";	
		return j.StartsWith(master)? 1 : j.StartsWith(jediKnight)? 2 : j.StartsWith(padawan) ? 3 : 4;
	}
}