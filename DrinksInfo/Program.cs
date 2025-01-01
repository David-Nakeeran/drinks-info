using DrinksInfo.Utilities;
using DrinksInfo.Controllers;
using DrinksInfo.Views;

namespace DrinksInfo;

internal class Program
{
    static async Task Main(string[] args)
    {
        DrinksService drinksService = new DrinksService();
        MenuHandler menuHandler = new MenuHandler();
        Validation validation = new Validation();
        DrinksControllers drinksControllers = new DrinksControllers(validation);

        var categories = await drinksService.GetDrinksCategoriesAsync();
        menuHandler.ShowCategoryMenu(categories);

        string? drinkCategorySelected = drinksControllers.GetCategory();

        // validate string


        // loop through categories and match it to users selected category
        foreach (var category in categories)
        {
            if (category?.Name?.ToLower() == drinkCategorySelected)
            {
                Console.WriteLine($"{category?.Name} = {drinkCategorySelected}");
            }
        }

    }

    internal void
}

