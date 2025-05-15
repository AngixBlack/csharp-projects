# C# Projects Collection

A collection of simple yet practical C# console applications built to practice core programming concepts such as user input validation, file handling, object-oriented programming, and basic scientific calculations.

> This repository currently contains **4 beginner-friendly C# console apps**, each demonstrating a different concept.

---

## 🧩 Projects

### 1. 📊 Student Marks Analyzer
> A program that allows users to enter student names and marks (0–100), then calculates and displays each student's score along with the average, highest, and lowest scores.

#### Features:
- Input validation for names (only letters and spaces allowed)
- Range check for marks (must be between 0–100)
- Formatted output using string alignment
- Uses `List<T>`, `LINQ`, and regular expressions

---

### 2. 💻 Simple Tech Quiz Game
> A console quiz game that loads questions from a text file (`questions.txt`), presents multiple-choice options, accepts user input, and displays final results.

#### Features:
- Reads and parses questions in `question|options|answer` format
- Supports multiple questions with A/B/C/D choices
- Validates user input (only A–D allowed)
- Displays final score and percentage with feedback message
- Uses custom classes (`Question`, `QuizGame`) for clean structure

---

### 3. 💰 Simple Budget Tracker
> A basic personal finance tool that lets users add income/expense entries, view their current balance, and review transaction history — all stored persistently in text files.

#### Features:
- Load and save balance from `balance.txt`
- Append transactions to `history.txt` with timestamp
- Prevents negative balance on expense entry
- Formatted table display for transaction history
- Input validation for positive decimal values

---

### 4. 🌡️ Temperature Converter
> A menu-driven console app that converts temperatures between Celsius, Fahrenheit, and Kelvin.

#### Features:
- 6 conversion options in one tool
- Input validation (numeric and range: -1000 to 1000)
- Clear formula-based conversions
- Formatted output showing units and 2 decimal places

---

## 🛠️ How to Run

Each project is a standalone C# console application. You can run them using:

- **Visual Studio**
- **.NET CLI** (`dotnet run`)
- Or any compatible C# IDE (e.g., Visual Studio Code + C# extension)

Some projects may require additional setup:
- For **Quiz Game**, ensure `questions.txt` is placed in the working directory.
- For **Budget Tracker**, it will auto-create `balance.txt` and `history.txt` if not found.

---

## 📚 Technologies Used

- C#
- .NET
- Console Application
- File I/O, LINQ, Regex, Collections

 
