# Overview

C# Match Probability Analyzer is a console application that analyzes historical sports match data. It reads team names, goals, and ratings from a CSV file, calculates home-win, draw, and away-win probabilities, calculates decimal odds, and writes a complete report to a text file.

I wrote this software to strengthen my understanding of C# syntax and object-oriented programming. The project demonstrates variables, expressions, conditionals, loops, functions, classes, and a custom structure. It also demonstrates reading from and writing to files.

[Software Demo Video](https://youtu.be/lbu2GdiXbRg?si=hfne1UFCssr52DVD)

The video demonstrates the program running and walks through the C# code, including the `Team` and `Match` classes, the `MatchPrediction` struct, CSV parsing, probability calculations, exception handling, and report writing.

# Development Environment

I developed this software in Visual Studio Code using the .NET 10 SDK. The project is a C# console application and uses the standard .NET libraries for collections, file input and output, string formatting, exception handling, and LINQ operations. No external packages are required.

The application is organized into models and services. `Team` and `Match` are classes that represent the domain. `MatchPrediction` is a custom struct that stores calculated probabilities. `CsvMatchReader` reads and validates the input file, `PredictionCalculator` performs the calculations, and `ReportWriter` creates the text report.

To run the application:

```powershell
dotnet build
dotnet run
```

The program reads `data/matches.csv` and creates `output/match-probabilities.txt`.

The CSV file uses this format:

```text
HomeTeam,AwayTeam,HomeGoals,AwayGoals,HomeRating,AwayRating
```

# Useful Websites

- [Microsoft C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [C# Classes and Objects](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes)
- [C# Structures](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct)
- [Microsoft File and Stream I/O](https://learn.microsoft.com/en-us/dotnet/standard/io/)
- [Microsoft .NET Console Application Tutorial](https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code)

# Future Work

- Add an interactive console menu so users can enter new matches without editing the CSV file.
- Add more statistical models using historical team performance and goal averages.
- Add unit tests for CSV validation, probability normalization, and decimal odds calculations.
- Allow users to choose a different input file and output location from command-line arguments.
- Add a summary report that compares predictions with final match results.
