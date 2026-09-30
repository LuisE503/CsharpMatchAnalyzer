# C# Match Probability Analyzer

C# console application for Module 2 of CSE 310. The program reads historical match records from a CSV file, creates `Team` and `Match` objects, calculates home-win, draw, and away-win probabilities, converts those probabilities into decimal odds, and writes a text report.

## Module Requirements Demonstrated

- C# console application created by the student.
- `Team` and `Match` classes model the domain.
- `MatchPrediction` is a custom `struct` used as a value type for calculated results.
- CSV input is read from `data/matches.csv`.
- Loops, collections, conditional logic, exception handling, and functions are used throughout the program.
- Match probability calculations use team ratings and home-field advantage.
- Decimal odds are calculated from the normalized probabilities.
- Results are written to `output/match-probabilities.txt`.
- Each public and private function has an explanatory comment.

## How to Run

Install the .NET 10 SDK, then run these commands from this folder:

```powershell
dotnet build
dotnet run
```

The console displays the number of processed matches and the most likely result for each match. The complete report is written to `output/match-probabilities.txt`.

## CSV Format

The input file uses this header:

```text
HomeTeam,AwayTeam,HomeGoals,AwayGoals,HomeRating,AwayRating
```

Add one match per line. Team ratings and goals must be numeric, and goals cannot be negative.

## How the Program Works

1. `CsvMatchReader.LoadMatches` reads every non-empty row after the CSV header.
2. `ParseMatch` validates the numeric columns and creates two `Team` objects and one `Match` object.
3. `PredictionCalculator.Calculate` compares team ratings, adds home advantage, calculates three positive scores, and normalizes them so the probabilities total 100%.
4. `MatchPrediction` stores the three probabilities and identifies the most likely result.
5. `ReportWriter.Write` creates the output directory and writes probabilities, odds, and the most likely result to a text file.
6. `Program.cs` coordinates the workflow and catches file and format errors.

## Video

Add the final 4-5 minute video link here before submission. The video must show the student's face, demonstrate `dotnet run`, show the generated report, and provide a detailed walkthrough of the classes, struct, CSV reader, probability calculation, exception handling, and report writer.

## Research Sources

- [Microsoft C# documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [Microsoft .NET console application documentation](https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code)
- [Microsoft File and Stream I/O documentation](https://learn.microsoft.com/en-us/dotnet/standard/io/)

## Learning Strategies

I used official Microsoft documentation to study classes, structs, collections, file input and output, exception handling, and C# project commands. I divided the project into models, input processing, calculations, and reporting so each part could be tested independently. I first tested a small CSV file, then added validation and error handling before producing the final report.

## Time Log

Record actual time spent on research, planning, implementation, troubleshooting, documentation, video production, and publishing in the Module Submission document. The course expectation is at least 20 hours for the module.
