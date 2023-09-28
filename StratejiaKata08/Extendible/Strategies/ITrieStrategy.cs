using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratejiaKata08.Extendible.Strategies
{
    public class TrieStrategy : ICompoundWordsStrategy
    {
        public CompoundWordStrategyType Supports => CompoundWordStrategyType.TRIE;

        public Task<List<string>> FindCompoundWordsFromList(ICompoundWordsKataInput kataInput)
        {
            throw new NotImplementedException();
        }
    }
}
