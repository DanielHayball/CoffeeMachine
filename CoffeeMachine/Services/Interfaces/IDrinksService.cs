
using CoffeeMachine.DTOs;
using CoffeeMachine.Enums;
using System.Threading.Tasks;

namespace CoffeeMachine.Interfaces.Services
{
    public interface IDrinksService
    {
        Task<DrinkRecipeDto> GetDrinkRecipeResponse(DrinkEnum drinkType);
    }
}