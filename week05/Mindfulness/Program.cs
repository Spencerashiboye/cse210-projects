using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Activities!");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option (1-4): ");
            
            string choice = Console.ReadLine();
            
            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (activity == null)
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            activity.StartActivity();
        }
    }
}

abstract class Activity
{
    protected int Duration;

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Starting {GetType().Name}...");
        Console.WriteLine(GetDescription());
        Console.Write("Enter the duration (in seconds): ");
        
        while (!int.TryParse(Console.ReadLine(), out Duration) || Duration <= 0)
        {
            Console.Write("Please enter a valid duration (in seconds): ");
        }

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        RunActivity();
        EndActivity();
    }

    protected abstract string GetDescription();
    protected abstract void RunActivity();

    protected void EndActivity()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"You completed {GetType().Name} for {Duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rStarting in {i}...   ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class BreathingActivity : Activity
{
    protected override string GetDescription()
    {
        return "This activity will help you relax by guiding you through slow breathing exercises.";
    }

    protected override void RunActivity()
    {
        int elapsedTime = 0;
        while (elapsedTime < Duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);
            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
            elapsedTime += 6;
        }
    }
}

class ReflectionActivity : Activity
{
    private static readonly List<string> Prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> Questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    protected override string GetDescription()
    {
        return "This activity will help you reflect on moments of strength and resilience in your life.";
    }

    protected override void RunActivity()
    {
        Random rand = new();
        Console.WriteLine($"Prompt: {Prompts[rand.Next(Prompts.Count)]}");
        ShowSpinner(3);

        int elapsedTime = 0;
        while (elapsedTime < Duration)
        {
            Console.WriteLine($"Question: {Questions[rand.Next(Questions.Count)]}");
            ShowSpinner(5);
            elapsedTime += 5;
        }
    }
}

class ListingActivity : Activity
{
    private static readonly List<string> Prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    protected override string GetDescription()
    {
        return "This activity will help you reflect on the good things in your life by listing them.";
    }

    protected override void RunActivity()
    {
        Random rand = new();
        Console.WriteLine($"Prompt: {Prompts[rand.Next(Prompts.Count)]}");
        ShowCountdown(3);
        
        Console.WriteLine("Start listing items (press Enter after each one). Type 'done' to finish.");
        
        int count = 0;
        int elapsedTime = 0;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            string input = Console.ReadLine();
            if (input?.ToLower() == "done") break;
            count++;
        }

        Console.WriteLine($"You listed {count} items.");
    }
}
