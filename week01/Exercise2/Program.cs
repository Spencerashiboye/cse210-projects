using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade precentage? ");
        string grade = Console.ReadLine();
        int precent = int.Parse(grade);

        string letter = "";

        if (precent >= 90)
        {
            letter = "A";
        }
        else if (precent >= 80)
        {
            letter = "B";
        }
        else if (precent >= 70)
        {
            letter = "C";
        }
        else if (precent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (precent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else 
        {
            Console.WriteLine("Better luck next time!");
        }
    
    }
}