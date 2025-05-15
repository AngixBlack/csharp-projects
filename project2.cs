using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string currentDirectory = Environment.CurrentDirectory;
        string filePath = Path.Combine(currentDirectory, "questions.txt");

        Console.WriteLine("Looking for file at: " + filePath);

        if (!File.Exists(filePath))
        {
            Console.WriteLine(" Error: The file 'questions.txt' was not found.");
            Console.WriteLine("Make sure it is placed in the same folder as the .exe file.");
            return;
        }

        var quiz = new QuizGame(filePath);
        quiz.Run();
    }
}

class Question
{
    public string Text { get; set; }
    public List<string> Options { get; set; }
    public string Answer { get; set; }

    public Question(string text, List<string> options, string answer)
    {
        Text = text;
        Options = options;
        Answer = answer.ToUpper();    
    }
}

class QuizGame
{
    private List<Question> questions = new List<Question>();
    private int score = 0;
    private string filePath;

    public QuizGame(string path)
    {
        filePath = path;
        LoadQuestionsFromFile();
    }

    private void LoadQuestionsFromFile()
    {
        try
        {
            foreach (var line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split('|');
                if (parts.Length != 3) continue;

                string questionText = parts[0];
                List<string> options = new List<string>(parts[1].Split(','));
                string answer = parts[2];

                
                for (int i = 0; i < options.Count; i++)
                {
                    options[i] = ((char)('A' + i)) + ". " + options[i].Trim();
                }

                questions.Add(new Question(questionText, options, answer));
            }

            Console.WriteLine($" Loaded {questions.Count} questions.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Error loading file: {ex.Message}");
        }
    }

    public void Run()
    {
        Console.WriteLine(" Welcome to the Simple Tech Quiz Game!\n");

        foreach (var question in questions)
        {
            DisplayQuestion(question);
        }

        ShowResults();
    }

    private void DisplayQuestion(Question q)
    {
        Console.WriteLine(q.Text);
        foreach (var option in q.Options)
        {
            Console.WriteLine(option);
        }

        string answer = "";

        while (true)
        {
            Console.Write("Your answer (A, B, C, D): ");
            answer = Console.ReadLine().Trim().ToUpper();

            if (answer == "A" || answer == "B" || answer == "C" || answer == "D")
            {
                break;
            }
            else
            {
                Console.WriteLine("\n Invalid input. Please enter A, B, C, or D.");
            }
        }

        if (answer == q.Answer)
        {
            Console.WriteLine(" \n Correct!\n");
        }
        else
        {
            Console.WriteLine($"\n Wrong! The correct answer was: {q.Answer}\n");
        }
    }

    private void ShowResults()
    {
        Console.WriteLine($" Quiz Complete! Your score: {score} out of {questions.Count}");
        double percentage = (double)score / questions.Count * 100;
        Console.WriteLine($"You scored {percentage:F2}%");

        if (percentage >= 75)
            Console.WriteLine(" Great job!");
        else if (percentage >= 50)
            Console.WriteLine(" Good effort.");
        else
            Console.WriteLine(" Better luck next time!");

        Console.WriteLine("Thanks for playing!");
    }
}
