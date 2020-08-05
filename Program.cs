using System;
using System.Collections.Generic;
using System.Linq;

namespace frequency_counter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text: ");

            String[] words = Console.ReadLine().ToLower().Split(' ');
            Dictionary<string, int> dictionary = countFrequency(words);

            foreach (var entry in dictionary) {
                Console.WriteLine("The word \"{0}\" was repeated {1} times", entry.Key, entry.Value);
            }
        }

        private static Dictionary<string, int> countFrequency(String[] words)
        {
            return words
                .GroupBy(w => w)
                .Select(g => new {Word = g.Key, Count = g.Count() })
                .OrderByDescending(global => global.Count)
                .ThenBy(g => g.Word).ToDictionary(d => d.Word, d => d.Count);
        }
    }
}
