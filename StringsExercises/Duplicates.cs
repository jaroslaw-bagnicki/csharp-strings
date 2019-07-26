using System;
using System.Collections.Generic;
using System.Linq;

namespace StringsExercises
{
    public class Duplicates
    {
        public static void Run()
        {
            List<int> numbers = GetNumbers();

            if (numbers.Count == 0)
                return;

            bool hasDupicates = CheckDuplicates(numbers);

            Console.WriteLine($"Passed numbers sequence { (hasDupicates ? "has" : "doesn't have") } duplicates.");
        }

        private static bool CheckDuplicates(List<int> numbers)
        {
            return numbers
                .GroupBy(num => num)
                .Any(group => group.Count() > 1);
        }

        private static List<int> GetNumbers()
        {
            while (true)
            {
                Console.Write("Enter couples numbers separated by hyphen: ");
                string input = Console.ReadLine();

                string[] numbersStrings = input.Split('-');

                var numbers = new List<int>();
                var isValid = false;

                foreach (var str in numbersStrings)
                {
                    if (int.TryParse(str, out int num))
                    {
                        numbers.Add(num);
                        continue;
                    }

                    Console.WriteLine("Invalid input at step: " + (string.IsNullOrWhiteSpace(str) ? "<empty string>" : str));
                    isValid = true;
                    break;
                }

                if (isValid)
                    continue;

                return numbers;
            }

        }

    }
}