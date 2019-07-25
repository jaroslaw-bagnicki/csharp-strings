﻿using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;

namespace StringsExercises
{
    public class ConsecutiveTest
    {
        private static readonly Dictionary<int, string> directionDict = new Dictionary<int, string>()
        {
            { 1, "ascending" },
            { -1, "descending" },
        };

        public static void Run()
        {
            List<int> numbers = GetNumbers();
            Console.WriteLine($"You enter sequence of {numbers.Count} numbers.");
            Console.WriteLine("----");

            bool isConsecutive;

            int firstCompare = numbers[1] - numbers[0];

            switch (firstCompare)
            {
                case 1:
                case -1:
                    isConsecutive = CheckConsecutive(numbers.Skip(1), firstCompare);
                    break;
                default:
                    isConsecutive = false;
                    break;
            }

            Console.WriteLine($"Sequence { (isConsecutive ? "is " + directionDict[firstCompare] : "isn't consecutive") }.");
            //Console.ReadKey();
        }

        private static bool CheckConsecutive(IEnumerable<int> numbers, int direction)
        {
            return numbers
                        .Pairwise((a, b) => b - a)
                        //.ForEach(a => Console.WriteLine(a))
                        .All(a => a == direction);
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