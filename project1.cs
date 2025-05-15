using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        // Lists 
        List<string> names = new List<string>();
        List<int> marks = new List<int>();

        InputStudentData(names, marks);
            
        if (marks.Count == 0) // If User not Enter the Data   
        {
            Console.WriteLine("No Data Entered !! ): ");
            return;
        }

        double average = CalculateAverage(marks);
        int highest = FindHighest(marks);
        int lowest = FindLowest(marks);

        DisplayResults(names, marks, average, highest, lowest);
    }



    static void InputStudentData(List<string> names, List<int> marks)
    {
        Console.WriteLine("Enter The Students Details. Type 'done'  as name to finish.");

        while (true)
        {
            string name = "";

            do
            {
                Console.Write("Enter student name: ");
                name = Console.ReadLine().Trim();

                if (name.ToLower() == "done")
                    break;

                if (!IsValidName(name))
                {
                    Console.WriteLine("Invalid name. Please use only letters and spaces.");
                }
            } while (name.ToLower() != "done" && !IsValidName(name));

            if (name.ToLower() == "done")
                break;



            int mark = 0;
            bool validMark = false;




            do
            {
                Console.Write($"Enter mark for {name} (0-100): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out mark))
                {
                    if (mark >= 0 && mark <= 100)
                    {
                        validMark = true;
                    }
                    else
                    {
                        Console.WriteLine("Mark must be between 0 - 100.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }

            } while (!validMark);

            names.Add(name);
            marks.Add(mark);
        }
    }

    static bool IsValidName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
    }

    static double CalculateAverage(List<int> marks)
    {
        return Math.Round(marks.Average(), 2);
    }

    static int FindHighest(List<int> marks)
    {
        return marks.Max();
    }

    static int FindLowest(List<int> marks)
    {
        return marks.Min();
    }

    static void DisplayResults(List<string> names, List<int> marks, double average, int highest, int lowest)
    {
        Console.WriteLine("\n=== Student Results ===");
        Console.WriteLine("{0,-20} {1,5}", "Name", "Mark");
        Console.WriteLine("-----------------------------");

        for (int i = 0; i < names.Count; i++)
        {
            Console.WriteLine("{0,-20} {1,5}", names[i], marks[i]);
        }

        Console.WriteLine("\n=== Summary ===");
        Console.WriteLine($"Average Score: {average:F2}");
        Console.WriteLine($"Highest Score: {highest}");
        Console.WriteLine($"Lowest Score : {lowest}");
    }
}
