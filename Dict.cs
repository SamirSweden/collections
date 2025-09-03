using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.Write("write ...");
        string choice = Console.ReadLine();

        if (string.IsNullOrEmpty(choice))
        {
            Console.WriteLine("empty");
            return;
        }

        string word = choice.ToLower();
        var dict = new Dictionary<char, int>();
        foreach (char ch in word)
        {
            if (char.IsLetter(ch))
            {
                if (dict.ContainsKey(ch))
                {
                    dict[ch]++;
                }
                else
                {
                    dict[ch] = 1;
                }
            }
        }
        Console.WriteLine($" частота слов {choice} ");
        foreach (var pair in dict.OrderBy(p => p.Key))
        {
            Console.WriteLine($"{pair.Key} : {pair.Value}");
        }
        
    }
}


