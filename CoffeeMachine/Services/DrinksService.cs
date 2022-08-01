
using CoffeeMachine.DTOs;
using CoffeeMachine.Enums;
using CoffeeMachine.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMachine.Services
{
    public class DrinksService : IDrinksService
    {
        public DrinksService()
        {
        }

        public async Task<DrinkRecipeDto> GetDrinkRecipeResponse(DrinkEnum drinkType) 
        {
            //I'm using a DTO a little weird here, typically I'd only use a DTO for querying
            //a database then instatly map it to an actual entity that might have some
            //actual buisness logic
            var recipe = new DrinkRecipeDto();

            switch (drinkType)
            {
                case DrinkEnum.LemonTea:
                    recipe.Name = DrinkEnum.LemonTea.ToString();
                    recipe.OrderOfOperations = new List<string>()
                    {
                        "Boiling some water.",
                        "Steeping the tea in the water.",
                        "Pouring tea into the cup.",
                        "Adding lemon."
                    };
                    break;
                case DrinkEnum.Coffee:
                    recipe.Name = DrinkEnum.Coffee.ToString();
                    recipe.OrderOfOperations = new List<string>()
                    {
                        "Boiling some water.",
                        "Brewing the coffee grind.",
                        "Pouring coffee into the cup.",
                        "Adding sugar and milk."
                    };
                    break;
                case DrinkEnum.Chocolate:
                    recipe.Name = DrinkEnum.Chocolate.ToString();
                    recipe.OrderOfOperations = new List<string>()
                    {
                        "Boiling some water.",
                        "Adding powdered drinking chocolate to the water.",
                        "Pouring chocolate into the cup.",
                    };
                    break;
            }

            return recipe;
        }
    }
}