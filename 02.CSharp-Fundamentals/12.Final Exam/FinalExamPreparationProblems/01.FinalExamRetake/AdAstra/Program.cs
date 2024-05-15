using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string foodInformation = Console.ReadLine();

            //Dictionary<string, Dictionary<string, int>> foodItemsByExpDateAndCalories =
            //    new Dictionary<string, Dictionary<string, int>>();

            StringBuilder outputString = new StringBuilder();

            string regexPattern =
                @"(?<surround>[#|])(?<foodItem>[A-Za-z\s]+)\k<surround>(?<date>\d{2}[\/]\d{2}[\/]\d{2})\k<surround>(?<calories>\d+)\k<surround>";

            MatchCollection validFoodMatch = Regex.Matches(foodInformation, regexPattern);

            int totalCalories = 0;

            foreach (Match validMatch in validFoodMatch)
            {
                string foodItem = validMatch.Groups["foodItem"].Value;
                string expirationDate = validMatch.Groups["date"].Value;
                int calories = int.Parse(validMatch.Groups["calories"].Value);

                totalCalories += calories;
                outputString.Append($"Item: {foodItem}, Best before: {expirationDate}, Nutrition: {calories}\n");

                //foodItemsByExpDateAndCalories.Add(foodItem, new Dictionary<string, int>());
                //foodItemsByExpDateAndCalories[foodItem].Add(expirationDate, calories);
            }

            //foreach (var foodItems in foodItemsByExpDateAndCalories)
            //{
            //    totalCalories += foodItems.Value.Values.Sum();
            //}

            Console.WriteLine($"You have food to last you for: {totalCalories /= 2000} days!");

            Console.WriteLine(outputString);

            //foreach (var foodItems in foodItemsByExpDateAndCalories)
            //{
            //    Console.Write($"Item: {foodItems.Key}, ");
            //    Console.Write($"{string.Join("", foodItems.Value.Select(x => $"Best before: {x.Key}, Nutrition: {x.Value}"))}");

            //    Console.WriteLine();
            //}
        }
    }
}
