using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratejiaKata08.Fastest
{
    public class Trie
    {
        private readonly TrieNode Root = new TrieNode();

        public void AddWord(string word)
        {
            var currentNode = Root;

            foreach(char c in word)
            {
                if (!currentNode.Children.ContainsKey(c))
                {
                    currentNode.Children[c] = new TrieNode();
                }

                currentNode = currentNode.Children[c];
            }

            currentNode.IsTerminal = true;
        }

        public bool CompoundOfWordExsits(string word, HashSet<string> allWords)
        {
            var currentNode = Root;
            var i = 0;

            foreach(char c in word)
            {
                if (!currentNode.Children.ContainsKey(c))
                    return false;

                currentNode = currentNode.Children[c];

                if (allWords.Contains(word.Substring(i + 1)))
                        return true;

                if(currentNode.IsTerminal)
                {
                    return WordExists(word.Substring(i + 1));
                }

                i++;
            }

            return false;
        }
    }
}
