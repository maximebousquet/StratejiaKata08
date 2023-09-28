using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Interfaces;
using StratejiaKata08.Fastest;

namespace StratejiaKata08.Extendible.Strategies
{
    public class TrieStrategy : ICompoundWordsStrategy
    {
        public CompoundWordStrategyType Supports => CompoundWordStrategyType.TRIE;

        public Task<List<string>> FindCompoundWordsFromList(ICompoundWordsKataInput kataInput)
        {
            if(kataInput.WordLength == 0 || kataInput.Words.Count <= 0)
                return Task.FromResult(new List<string>());

            kataInput.Words.RemoveAll(w => w.Length > kataInput.WordLength);

            var trie = new Trie();

            kataInput.Words.Where(w => w.Length < kataInput.WordLength).ToList()
                .ForEach(w => trie.AddWord(w));

            var wordsOfRequiredLength = kataInput.Words.Where(w => w.Length == kataInput.WordLength);

            var compoundWords = new List<string>();

            return Task.FromResult(wordsOfRequiredLength.Where(w => trie.CompoundOfWordExsits(w)).ToList());
        }
    }
}
