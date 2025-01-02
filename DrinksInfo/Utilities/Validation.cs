using Spectre.Console;

namespace DrinksInfo.Utilities;

class Validation
{
    internal string CheckInputNullOrWhitespace(string message, string input)
    {
        while (string.IsNullOrWhiteSpace(input))
        {
            input = AnsiConsole.Ask<string>(message);
        }
        return input;
    }

    internal bool IsCharValid(string input)
    {
        foreach (char c in input)
        {
            if (!Char.IsLetter(c) && c != '/' && c != ' ') return false;
        }
        return true;
    }

    internal string? ValidateString(string message, string input)
    {
        input = CheckInputNullOrWhitespace(message, input);
        while (!IsCharValid(input))
        {
            AnsiConsole.WriteLine("Invalid category, please press any key to continue.....");
            Console.ReadKey(true);
            input = AnsiConsole.Ask<string>(message);
            input = CheckInputNullOrWhitespace(message, input);
        }
        return input;
    }
}