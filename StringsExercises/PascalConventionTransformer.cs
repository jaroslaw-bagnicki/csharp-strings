using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LinqToDB.DataProvider.SapHana;

namespace StringsExercises
{
    public class PascalConventionTransformer
    {
        public static void Run()
        {
            string input = GetText();

            string transformedInput = TransformToPascal(input);

            Console.WriteLine(transformedInput);

            Run();
        }

        private static string GetText()
        {
            string input;

            while (true)
            {
                Console.Write("Enter couple words separate by spaces: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    continue;
                return input;

            }
        }

        private static string TransformToPascal(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            string[] words = input.Split(" ");

            return words
                .Select(word => textInfo.ToTitleCase(word.ToLower()))
                .Aggregate((acc, word) => acc += word);
        }
    }
}