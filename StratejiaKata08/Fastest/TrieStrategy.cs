using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Enums;
using StratejiaKata08.Extendible.Interfaces;

namespace StratejiaKata08.Fastest
{
    public class TrieStrategy : ICompoundWordsStrategy
    {
        public CompoundWordStrategyType Supports => CompoundWordStrategyType.TRIE;

        public Task<List<string>> FindCompoundWordsFromListAsync(CompoundWordsKataInput kataInput)
        {
            if (kataInput.WordLength == 0 || kataInput.Words.Count <= 0)
                return Task.FromResult(new List<string>());

            var wordsOfRequiredLength = kataInput.Words.Where(w => w.Length == kataInput.WordLength).ToList();

            if (wordsOfRequiredLength.Count == 0)
                return Task.FromResult(new List<string>());

            kataInput.Words.RemoveAll(w => w.Length > kataInput.WordLength);

            var trie = new Trie();

            kataInput.Words
                .Where(w => w.Length < kataInput.WordLength).ToList()
                .ForEach(w => trie.AddWord(w));

            var allWordsHashSet = kataInput.Words.ToHashSet();

            return Task.FromResult(wordsOfRequiredLength
                .Where(w => trie.CompoundOfWordExsits(w, allWordsHashSet))
                .ToList());
        }
    }
}
