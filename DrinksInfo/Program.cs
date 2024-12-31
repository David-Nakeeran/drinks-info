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
        // // Check if categories were returned
        // if (categories.Any())
        // {
        //     foreach (var category in categories)
        //     {
        //         Console.WriteLine(category.Name);
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("No categories found.");
        // }


    }
}

