using DrinksInfo.Utilities;
using DrinksInfo.Controllers;
using DrinksInfo.Views;
using System.Globalization;

namespace DrinksInfo;

internal class Program
{
    static async Task Main(string[] args)
    {
        DrinksService drinksService = new DrinksService();
        MenuHandler menuHandler = new MenuHandler();
        Validation validation = new Validation();
        DrinksControllers drinksControllers = new DrinksControllers(validation);
        FindMatching findMatching = new FindMatching();

        // Get list from API
        var categories = await drinksService.GetDrinksCategoriesAsync();
        // Show list to user
        menuHandler.ShowCategoryMenu(categories);
        // Get users input and validate
        string? drinkCategorySelected = drinksControllers.GetCategory();

        bool isCategoryMatch = findMatching.FindMatchingCategory(categories, drinkCategorySelected);
        if (isCategoryMatch)
        {
            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;

            if (drinkCategorySelected == null) return;
            string? drink = textInfo.ToTitleCase(drinkCategorySelected);
            var drinks = await drinksService.GetDrinksAsync(drink);

            menuHandler.ShowDrinksMenu(drinks);
        }


    }
}

