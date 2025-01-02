

using System.Reflection.Metadata.Ecma335;
using DrinksInfo.Utilities;
using Spectre.Console;

namespace DrinksInfo.Controllers;

class DrinksControllers
{
    private readonly Validation _validation;
    internal DrinksControllers(Validation validation)
    {
        _validation = validation;
    }
    internal string? GetCategory()
    {
        var input = AnsiConsole.Ask<string>("Please enter the category of drinks you'd like to see");
        var inputValid = _validation.ValidateString("Please try again, enter the category of drinks you'd like to see", input);
        return inputValid;
    }
}