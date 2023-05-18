using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Markup;

namespace Task;
class Task1
{
	static void Main()
	{
		/*
		// 1.1
		System.Console.WriteLine("Hello, World!");

		//1.2
		string name;
		int age;
		System.Console.WriteLine("Enter name: ");
		name = Console.ReadLine();
		System.Console.WriteLine("Enter age: ");
		age = Console.ReadLine();
		System.Console.WriteLine("Name is {0}, age is {1}",name, age);
		*/
		//1.3

		List<int> numbers = new List<int>();

		double total = 0;
		double median;
		List<int> possibleModes = new List<int>();

		//user input numbers + ignore non integer inputs + tally up the total sum
		while (true)
		{
			System.Console.WriteLine("Please enter numbers or / to stop: ");
			var input = Console.ReadLine();
			if (input == "/" && numbers.Count != 0) break;
			if (int.TryParse(input, out int input_numeric))
			{
				total += input_numeric;
				numbers.Add(input_numeric);

			}
			else
				continue;
		}


		//sort the list of numbers for finding median and mode
		numbers.Sort();

		//calculate Mean
		System.Console.WriteLine("Mean : {0}", (total / numbers.Count));


		//median lands on between 2 numbers
		if (numbers.Count % 2 == 0) {
			int midPoint = numbers.Count() / 2;
			
			median = ((double)(numbers[midPoint-1] + numbers[midPoint]))/2; 
		}
		//median lands right on middle number of the sequence
		else {
			//int midPoint = numbers.Count() / 2;
			median = (int)numbers[(numbers.Count / 2)]; 
		}
		Console.WriteLine("Median: "+median);


		//mode 
		//keep count of occurances of numbers and the number itself in dict pair 
		Dictionary<int,int> existed = new Dictionary<int,int>();
		foreach (int number in numbers) {
			if (!existed.ContainsKey(number))
			{
				existed.Add(number, 1);
			}
			else { 
				existed[number]++;
			}
		}
		try{
			//sort the dict by value(occurences of the each number) in descending order
			existed.OrderByDescending(x => x.Value);

			//select the highest occurence's key for mode
			//var maxValueKey = existed.First().Key;

			//since there can be same number of occurence by multiple numbers
			var temp_mode = existed.First().Value;
			//keep track of keys which have the same about higest occurence
			foreach (KeyValuePair<int,int> pair in existed) {
				if (pair.Value == temp_mode) {
					possibleModes.Add(pair.Key);
				}
			}
		
				
        }
		catch(Exception e){
			Console.WriteLine($"Exception Thrown: {e.Message}");
        }

		foreach(int mode in possibleModes) {
			Console.WriteLine("Mode: " + mode);
		}
		Console.ReadKey();
	}
}