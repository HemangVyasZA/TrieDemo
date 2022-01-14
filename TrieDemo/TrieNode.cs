using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TrieDemo
{
    public class TrieNode
    {
      
        public Dictionary<char,TrieNode> Children { get; set; }
        public bool IsEndOfWord { get; set; }
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            IsEndOfWord = false;
        }
    }

    public class Trie
    {
        readonly TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            // Always start from root node. 
            TrieNode current = root;

            foreach (var character in word)
            {
                current.Children.TryGetValue(character, out TrieNode child);
                if (child == null)
                {
                    child = new TrieNode();
                    current.Children.Add(character, child);
                }
                current = child;
            }
            current.IsEndOfWord = true;
        }

        public bool IsMatch(string word)
        {
            // Always start from root node. 
            TrieNode current = root;
            foreach (var character in word)
            {
                current.Children.TryGetValue(character, out TrieNode child);
                if (child == null)
                {
                    return false;
                }
                current = child;
            }
            return current.IsEndOfWord;
        }
       
        public List<string> GetAllWordsStartWithPrefix(string prefix)
        {
            TrieNode current = root;
 
            foreach (var character in prefix)
            {
                current.Children.TryGetValue(character, out TrieNode child);
                if (child == null)
                {
                    return new List<string>();
                }
                current = child;
            }

          return  GetAllWordsStartWithPrefix(current, prefix);
           
        }

        private List<string> GetAllWordsStartWithPrefix(TrieNode node, string prefix)
        {
            List<string> matchingWords = new List<string>();

            Stack<KeyValuePair<char, TrieNode>> stackToTrackCurrentNode = new Stack<KeyValuePair<char, TrieNode>>();
            
            List<KeyValuePair<TrieNode, string>> prefixes = new List<KeyValuePair<TrieNode, string>>();

            foreach (var child in node.Children)
            {
                prefixes.Add(new KeyValuePair<TrieNode, string>(child.Value, prefix));
                stackToTrackCurrentNode.Push(child);
            }
          

            while (stackToTrackCurrentNode.Any())
            {
                var childNode = stackToTrackCurrentNode.Pop();
                
                var currentNodePrefix = prefixes.FirstOrDefault(item => item.Key == childNode.Value);
                var word = $"{currentNodePrefix.Value}{childNode.Key}";

                prefixes.Remove(currentNodePrefix);

                if (childNode.Value.IsEndOfWord)
                {
                    if (!matchingWords.Contains(word))
                    {
                        matchingWords.Add(word);
                    }
                }

                foreach (var child in childNode.Value.Children)
                {
                    prefixes.Add(new KeyValuePair<TrieNode, string>(child.Value, word));
                    stackToTrackCurrentNode.Push(child);
                }

            }

            return matchingWords;
        }

        //public static void main(String[] args)
        //{
        //    Trie trie = new Trie();
        //    trie.Insert("cat");
        //    trie.Insert("car");
        //    trie.Insert("dog");
        //    trie.Insert("pick");
        //    trie.Insert("pickle");
        //    bool isPresent = trie.Search("cat");
        //    Console.WriteLine();
        //    Console.WriteLine(isPresent);
        //    isPresent = trie.Search("picky");
        //    Console.WriteLine(isPresent);
        //    isPresent = trie.StartsWith("ca");
        //    Console.WriteLine(isPresent);
        //    isPresent = trie.StartsWith("pen");
        //    Console.WriteLine(isPresent);

        //}
    }
}
