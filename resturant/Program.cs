using System;
using System.Collections.Generic;

namespace RestaurantProgram
{
    struct RestaurantPosition
    {
        public string Title;
        public decimal ApproxWage;
    }

    struct MealCombo
    {
        public string ComboName;
        public List<string> Contents;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<RestaurantPosition> positions = new List<RestaurantPosition>
            {
                new RestaurantPosition { Title = "Server", ApproxWage = 10.50M },
                new RestaurantPosition { Title = "Chef", ApproxWage = 15.75M },
                new RestaurantPosition { Title = "Bartender", ApproxWage = 12.25M },
                new RestaurantPosition { Title = "Host/Hostess", ApproxWage = 9.75M },
                new RestaurantPosition { Title = "Busser", ApproxWage = 8.50M }
            };

            List<MealCombo> mealCombos = new List<MealCombo>
            {
                new MealCombo
                {
                    ComboName = "Classic Burger Combo",
                    Contents = new List<string> { "Cheeseburger", "Fries", "Soft Drink" }
                },
                new MealCombo
                {
                    ComboName = "Vegetarian Delight",
                    Contents = new List<string> { "Veggie Wrap", "Side Salad", "Iced Tea" }
                },
                new MealCombo
                {
                    ComboName = "Seafood Extravaganza",
                    Contents = new List<string> { "Grilled Salmon", "Garlic Mashed Potatoes", "Wine" }
                },
                new MealCombo
                {
                    ComboName = "Family Pizza Night",
                    Contents = new List<string> { "Large Pizza", "Garlic Breadsticks", "Soda" }
                }
            };

            List<string> afterDinnerOfferings = new List<string>
            {
                "Espresso",
                "Chocolate Lava Cake",
                "Affogato",
                "Cheesecake"
            };

            Dictionary<int, string> satisfactionScale = new Dictionary<int, string>
            {
                { 1, "Very Dissatisfied" },
                { 2, "Dissatisfied" },
                { 3, "Neutral" },
                { 4, "Satisfied" },
                { 5, "Very Satisfied" }
            };

            Console.WriteLine("Restaurant Positions:");
            foreach (var position in positions)
            {
                Console.WriteLine($"{position.Title} - Approx Wage: {position.ApproxWage:C}");
            }

            Console.WriteLine("\nMeal Combos:");
            foreach (var combo in mealCombos)
            {
                Console.WriteLine($"{combo.ComboName}: {string.Join(", ", combo.Contents)}");
            }

            Console.WriteLine("\nAfter-Dinner Offerings:");
            foreach (var offering in afterDinnerOfferings)
            {
                Console.WriteLine(offering);
            }

            Console.WriteLine("\nSatisfaction Scale:");
            foreach (var item in satisfactionScale)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
