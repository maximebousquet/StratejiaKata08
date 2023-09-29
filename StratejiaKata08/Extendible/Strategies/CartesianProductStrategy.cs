using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Enums;
using StratejiaKata08.Extendible.Interfaces;

namespace StratejiaKata08.Extendible.Strategies
{
    public class CartesianProductStrategy : ICompoundWordsStrategy
    {
        private readonly IWordsConcatenationValidator _wordsConcatenationValidator;

        public CompoundWordStrategyType Supports => CompoundWordStrategyType.CROSSPRODUCT;

        public CartesianProductStrategy(IWordsConcatenationValidator wordsConcatenationValidator)
        {
            _wordsConcatenationValidator = wordsConcatenationValidator;
        }

        public async Task<List<string>> FindCompoundWordsFromListAsync(CompoundWordsKataInput kataInput)
        {
            var words = new List<string>(kataInput.Words);

            if (kataInput.WordLength == 0 || kataInput.Words.Count <= 0)
                return new List<string>();

            var wordsWithRequiredLength = words.Where(w => w.Length == kataInput.WordLength).ToList();

            if (wordsWithRequiredLength.Count == 0)
                return new List<string>();

            words.RemoveAll(w => w.Length >= kataInput.WordLength);

            var wordsSeparatedByTheirCharCount = new List<HashSet<string>>();

            for (int i = 1; i < kataInput.WordLength; i++)
            {
                wordsSeparatedByTheirCharCount.Add(new HashSet<string>(words.Where(w => w.Length == i)));
            }

            var tasks = new List<Task<List<string>>>();

            var y = 1;
            foreach (var collectionOfSameCharCountWords in wordsSeparatedByTheirCharCount)
            {
                // We make sure that we combine char collections that add up to the length of the word we are looking for.
                var oppositeCollection = wordsSeparatedByTheirCharCount.Count() - y;

                tasks.Add(
                    _wordsConcatenationValidator.FindWordsThatAreConcatenationsOf(wordsWithRequiredLength,
                        collectionOfSameCharCountWords,
                        wordsSeparatedByTheirCharCount.ElementAt(oppositeCollection)
                    ));

                y++;
            }

            var results = await Task.WhenAll(tasks);

            return results.SelectMany(results => results).Distinct().ToList();
        }
    }
}
