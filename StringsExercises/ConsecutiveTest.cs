using System;
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


            int direct = numbers[1] - numbers[0];

            bool isConsecutive = Math.Abs(direct) == 1 && numbers
                         .Skip(1)
                         .Pipe(t => Console.WriteLine("Pipe1: " + t))
                         .Lag(1, (curr, prev) => (curr, prev, direct))
                         .Skip(1)
                         .All(a => a.curr - a.prev == a.direct);


            //switch (direct)
            //{
            //    case 1:
            //    case -1:
            //        isConsecutive = CheckConsecutive(numbers.Skip(1), direct);
            //        break;
            //    default:
            //        isConsecutive = false;
            //        break;
            //}

            Console.WriteLine($"Sequence { (isConsecutive ? "is " + directionDict[direct] : "isn't consecutive") }.");
        }

        private static bool CheckConsecutive(List<int> numbers, int direction)
        {
            int direct = numbers[1] - numbers[0];

            return Math.Abs(direct) == 1 && numbers
                       .Pipe(a => Console.WriteLine("Pipe1: " + a))
                       //.Pairwise((curr, prev) => curr - prev)
                       .Lag(1, (curr, prev) => (curr, prev))
                       .Skip(1)
                       .Pipe(t => Console.WriteLine("Pipe2: " + t))
                       //.Select(a => 1)
                       .All(t => t.curr - t.prev == direction);
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