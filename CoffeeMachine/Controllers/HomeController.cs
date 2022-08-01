using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeMachine.Models;
using CoffeeMachine.Interfaces.Services;
using CoffeeMachine.Enums;
using CoffeeMachine.DTOs;

namespace CoffeeMachine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDrinksService _drinksService;

        public HomeController(ILogger<HomeController> logger, 
            IDrinksService drinksService)
        {
            _logger = logger;
            _drinksService = drinksService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDrinkRecipe(string drinkType)
        {
            var drinkTypeEnum = DrinkEnum.NoDrink;

            switch (drinkType)
            {
                case "tea":
                    drinkTypeEnum = DrinkEnum.LemonTea;
                    break;
                case "coffee":
                    drinkTypeEnum = DrinkEnum.Coffee;
                    break;
                case "chocolate":
                    drinkTypeEnum = DrinkEnum.Chocolate;
                    break;
            }

            if(drinkTypeEnum == DrinkEnum.NoDrink)
            {
                throw new Exception("No drink recipe for drink of type: " + drinkType);
            }

            var recipe = Json(await _drinksService.GetDrinkRecipeResponse(drinkTypeEnum));

            return recipe;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
