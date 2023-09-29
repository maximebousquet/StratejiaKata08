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

            currentNode.IsWord = true;
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

                if (currentNode.IsWord && allWords.Contains(word.Substring(i + 1)))
                    return true;

                i++;
            }

            return false;
        }
    }
}
