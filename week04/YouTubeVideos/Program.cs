using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create video objects
        Video video1 = new Video("Understanding OOP in C#", "Tech Explained", 600);
        Video video2 = new Video("C# Design Patterns", "Code Academy", 720);
        Video video3 = new Video("ASP.NET Core Tutorial", "Web Dev Guru", 900);
        Video video4 = new Video("C# Async & Await Explained", "Dev Simplified", 480);

        // Add comments to videos
        video1.AddComment(new Comment("Alice", "Great explanation, very clear!"));
        video1.AddComment(new Comment("Bob", "Loved the examples, helped a lot."));
        video1.AddComment(new Comment("Charlie", "Can you make a video on LINQ?"));

        video2.AddComment(new Comment("David", "Finally, I understand design patterns!"));
        video2.AddComment(new Comment("Emma", "Very well structured tutorial."));
        video2.AddComment(new Comment("Frank", "This should be a paid course!"));

        video3.AddComment(new Comment("Grace", "Awesome ASP.NET tutorial."));
        video3.AddComment(new Comment("Hank", "Looking forward to the next part!"));
        video3.AddComment(new Comment("Ivy", "This was exactly what I needed."));

        video4.AddComment(new Comment("Jack", "Async/Await finally makes sense!"));
        video4.AddComment(new Comment("Karen", "Super helpful, thanks a ton!"));
        video4.AddComment(new Comment("Leo", "Can you cover multithreading next?"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display video details and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Commenter}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40)); // Separator line
        }
    }
}

// Video class
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    public List<Comment> Comments { get; private set; } // List of comments

    // Constructor
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Method to return the number of comments
    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

// Comment class
class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }

    // Constructor
    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
    }
}
