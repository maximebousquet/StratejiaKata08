using System;
namespace StratejiaKata08.Fastest
{
    public class TrieNode
    {
        public bool IsWord { get; set; }

        public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
    }
}
