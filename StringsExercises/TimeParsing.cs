using System;
using System.Text.RegularExpressions;

namespace StringsExercises
{
    public class TimeParsing
    {
        public static void Run()
        {
            string input = GetTime();

            bool isValidTime = ParseTime(input);

            Console.WriteLine(isValidTime ? "Ok." : "Invalid Time.");

            Run();
        }

        private static bool ParseTime(string input)
        {
            Regex timeRx = new Regex(@"^$|^((0?[0-9])|(1[0-9])|(2[0-3])):[0-5][0-9]$");
            return timeRx.IsMatch(input);
        }

        private static string GetTime()
        {
            while (true)
            {
                Console.Write("Enter time: ");
                string input = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(input))
                    continue;
                return input;
            }
        }
    }
}