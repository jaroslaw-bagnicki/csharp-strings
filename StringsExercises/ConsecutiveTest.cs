using System;
using System.Collections.Generic;
using System.Linq;

namespace StringsExercises
{
    public class ConsecutiveTest
    {
        public static void Run()
        {
            List<int> numbers = GetNumbers();
            Console.WriteLine("Numbers.Count: " + numbers.Count);

            var isConsecutive = CheckConsecutive(numbers);
        }

        private static bool CheckConsecutive(List<int> numbers)
        {
            return !numbers.Where((t, i) => numbers[i + 1] - t != 1).Any();
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