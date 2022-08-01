
using CoffeeMachine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachine.DTOs
{
    public class DrinkRecipeDto 
    {
        public string Name { get; set; }
        public List<string> OrderOfOperations { get; set; } = new List<string>();
    }
}