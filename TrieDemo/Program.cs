using System;
using System.Collections.Generic;
using System.Linq;
namespace TrieDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        //    TestATrie();
            TestATrieWithCityName();
        }

      
        static Trie CreateATrieWithCityNames()
        {
            Trie trie = new Trie();
            var cities = CityNames.AllCities();
            foreach (var city in cities)
            {
                trie.Insert(city);
            }
            return trie;
        }

        static void TestATrieWithCityName()
        {
            Trie trie = CreateATrieWithCityNames();

            var cityNamePrefix = "New B";

            List<string> matchingWords = trie.GetAllWordsStartWithPrefix(cityNamePrefix);
            Console.WriteLine($"All words that start with {cityNamePrefix}");

            foreach (var item in matchingWords)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.ReadLine();
        }
        static Trie CreateASampleTrie()
        {
            Trie trie = new Trie();
            trie.Insert("cat");
            trie.Insert("car");
            trie.Insert("dog");
            trie.Insert("pick");
            trie.Insert("pickle");
            trie.Insert("cart");
            trie.Insert("dodge");
            trie.Insert("pipe");
            trie.Insert("doll");
            trie.Insert("case");
            trie.Insert("picture");
            trie.Insert("casual");
            return trie;
        }
        static void TestATrie()
        {
            Trie trie = CreateASampleTrie();
            bool isPresent = trie.IsMatch("car");
            Console.WriteLine(isPresent);

            var prefix = "p";
            List<string> matchingWords = trie.GetAllWordsStartWithPrefix(prefix);
            Console.WriteLine($"All words that start with {prefix}");

            foreach (var item in matchingWords)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.ReadLine();
        }
    }

  
}
