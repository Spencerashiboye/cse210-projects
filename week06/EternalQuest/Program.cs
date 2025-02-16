using System;
using System.Collections.Generic;
using System.IO;

// Base Goal Class
abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string SaveFormat();
}

// Simple Goal
class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
        _completed = false;
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus() => _completed ? "[X]" : "[ ]";
    public override string SaveFormat() => $"Simple,{Name},{Points},{_completed}";
}

// Eternal Goal
class EternalGoal : Goal
{
    public EternalGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override int RecordEvent() => Points;
    public override string GetStatus() => "[∞]";
    public override string SaveFormat() => $"Eternal,{Name},{Points}";
}

// Checklist Goal
class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, int points, int target, int bonus)
    {
        Name = name;
        Points = points;
        _target = target;
        _bonus = bonus;
        _timesCompleted = 0;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        return _timesCompleted == _target ? Points + _bonus : Points;
    }

    public override string GetStatus() => _timesCompleted >= _target ? "[X]" : $"[{_timesCompleted}/{_target}]";
    public override string SaveFormat() => $"Checklist,{Name},{Points},{_timesCompleted},{_target},{_bonus}";
}

// Main Program
class GoalTracker
{
    private List<Goal> _goals = new();
    private int _score = 0;

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Score: {_score}\n");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Save & Exit");
            Console.Write("Choose an option: ");
            
            switch (Console.ReadLine())
            {
                case "1": CreateGoal(); break;
                case "2": RecordEvent(); break;
                case "3": ShowGoals(); Console.ReadLine(); break;
                case "4": SaveGoals(); return;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Choose Goal Type: 1. Simple  2. Eternal  3. Checklist");
        string choice = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1") _goals.Add(new SimpleGoal(name, points));
        else if (choice == "2") _goals.Add(new EternalGoal(name, points));
        else if (choice == "3")
        {
            Console.Write("Enter target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, points, target, bonus));
        }
    }

    private void RecordEvent()
    {
        ShowGoals();
        Console.Write("Select goal number to record progress: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _goals.Count)
        {
            _score += _goals[index].RecordEvent();
            Console.WriteLine("Event recorded! Press Enter to continue.");
            Console.ReadLine();
        }
    }

    private void ShowGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].Name}");
    }

    private void SaveGoals()
    {
        using StreamWriter writer = new("goals.txt");
        writer.WriteLine(_score);
        foreach (var goal in _goals)
            writer.WriteLine(goal.SaveFormat());
    }
}

class Program
{
    static void Main() => new GoalTracker().Run();
}
