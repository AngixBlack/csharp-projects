using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    private const string BalanceFilePath = "balance.txt";
    private const string HistoryFilePath = "history.txt";

    static void Main()
    {
        decimal balance = LoadBalance();

        while (true)
        {
            Console.WriteLine("\n--- Simple Budget Tracker ---");
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. View Balance");
            Console.WriteLine("4. View History");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    balance = AddIncome(balance);
                    SaveBalance(balance);
                    break;
                case "2":
                    balance = AddExpense(balance);
                    SaveBalance(balance);
                    break;
                case "3":
                    ViewBalance(balance);
                    break;
                case "4":
                    ViewHistory();
                    break;
                case "5":
                    SaveBalance(balance);
                    Console.WriteLine("Data saved. Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static decimal LoadBalance()
    {
        if (File.Exists(BalanceFilePath))
        {
            string content = File.ReadAllText(BalanceFilePath);
            if (decimal.TryParse(content, out decimal balance))
            {
                Console.WriteLine($"Loaded previous balance: {balance:C}");
                return balance;
            }
        }

        Console.WriteLine("No balance found. Starting from 0.");
        return 0;
    }

    static void SaveBalance(decimal balance)
    {
        File.WriteAllText(BalanceFilePath, balance.ToString("F2"));
    }

    static decimal AddIncome(decimal balance)
    {
        decimal amount = GetValidDecimalInput("Enter income amount: ");
        balance += amount;
        string entry = $"{DateTime.Now}|Income|+{amount:F2}|{balance:F2}";
        AppendHistory(entry);
        Console.WriteLine($"Added income: {amount:C}. New balance: {balance:C}");
        return balance;
    }

    static decimal AddExpense(decimal balance)
    {
        decimal amount = GetValidDecimalInput("Enter expense amount: ");

        if (amount > balance)
        {
            Console.WriteLine("Not enough balance to cover this expense.");
            return balance;
        }

        balance -= amount;
        string entry = $"{DateTime.Now}|Expense|-{amount:F2}|{balance:F2}";
        AppendHistory(entry);
        Console.WriteLine($"Expense of {amount:C} deducted. New balance: {balance:C}");
        return balance;
    }

    static void AppendHistory(string entry)
    {
        File.AppendAllText(HistoryFilePath, entry + Environment.NewLine);
    }

    static void ViewBalance(decimal balance)
    {
        Console.WriteLine($"\nCurrent Balance: {balance:C}");
    }

    static void ViewHistory()
    {
        if (!File.Exists(HistoryFilePath))
        {
            Console.WriteLine("No transaction history found.");
            return;
        }

        List<string> history = new List<string>(File.ReadAllLines(HistoryFilePath));

        if (history.Count == 0)
        {
            Console.WriteLine("No transaction history found.");
            return;
        }

        Console.WriteLine("\n--- Transaction History ---");
        Console.WriteLine("{0,-20} | {1,-7} | {2,-10} | {3,-10}", "Date", "Type", "Amount", "Balance");
        Console.WriteLine(new string('-', 60));

        foreach (string line in history)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 4)
            {
                string date = DateTime.Parse(parts[0]).ToString("yyyy-MM-dd hh:mm tt");
                string type = parts[1];
                string amount = parts[2];
                string balance = parts[3];

                Console.WriteLine("{0,-20} | {1,-7} | {2,-10} | {3,-10}",
                    date, type, amount, "$" + decimal.Parse(balance).ToString("F2"));
            }
        }
    }

    static decimal GetValidDecimalInput(string prompt)
    {
        decimal value = 0;
        bool isValid = false;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (decimal.TryParse(input, out value) && value >= 0)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
            }

        } while (!isValid);

        return value;
    }
}
