using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratejiaKata08.Fastest
{
    public class TrieNode
    {
        public bool IsTerminal { get; set; }

        public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
    }
}
