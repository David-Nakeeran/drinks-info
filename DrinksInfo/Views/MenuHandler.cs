using Spectre.Console;
using DrinksInfo.Models;

namespace DrinksInfo.Views;

class MenuHandler
{
    internal void ShowCategoryMenu(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Categories Menu");

        // loop through add the rows
        foreach (var category in categories)
        {
            if (category.Name == null)
            {
                AnsiConsole.WriteLine("No categories");
                return;
            }
            else
            {
                table.AddRow(category.Name);
            }
        }
        AnsiConsole.Write(table);
    }
}