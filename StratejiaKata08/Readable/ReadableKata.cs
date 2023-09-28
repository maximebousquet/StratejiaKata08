namespace StratejiaKata08.Readable
{
    public class ReadableKata
    {
        private List<string> AllWords = new List<string>();

        private List<string> SixLetterWords = new List<string>();

        public ReadableKata(List<string> words)
        {
            AllWords = words;
        }

        public async Task<List<string>> Execute()
        {
            if(AllWords.Count <= 0) 
                return new List<string>();

            SixLetterWords = AllWords.Where(w => w.Length == 6).ToList();

            AllWords.RemoveAll(w => w.Length >= 6);

            var wordsWithOneLetters = new HashSet<string>(AllWords.Where(w => w.Length == 1));
            var wordsWithTwoLetters = new HashSet<string>(AllWords.Where(w => w.Length == 2));
            var wordsWithThreeLetters = new HashSet<string>(AllWords.Where(w => w.Length == 3));
            var wordsWithFourLetters = new HashSet<string>(AllWords.Where(w => w.Length == 4));
            var wordsWithFiveLetters = new HashSet<string>(AllWords.Where(w => w.Length == 5));

            var tasks = new List<Task<List<string>>>
            {
                CompareCompoundWordCombinations(wordsWithOneLetters, wordsWithFiveLetters),
                CompareCompoundWordCombinations(wordsWithTwoLetters, wordsWithFourLetters),
                CompareCompoundWordCombinations(wordsWithThreeLetters, wordsWithThreeLetters),
                CompareCompoundWordCombinations(wordsWithFourLetters, wordsWithTwoLetters),
                CompareCompoundWordCombinations(wordsWithFiveLetters, wordsWithOneLetters)
            };

            var results = await Task.WhenAll(tasks);

            return results.SelectMany(results => results).ToList();
        }

        private Task<List<string>> CompareCompoundWordCombinations(HashSet<string> prefixes, HashSet<string> suffixes)
        {
            var concatenatedWords = new List<string>();

            foreach (var wordToTest in SixLetterWords)
            {
                foreach (var prefix in prefixes)
                {
                    if (wordToTest.StartsWith(prefix))
                    {
                        var suffix = wordToTest.Substring(prefix.Length);

                        if (suffixes.Contains(suffix))
                        {
                            concatenatedWords.Add(wordToTest);
                        }
                    }

                }
            }

            return Task.FromResult(concatenatedWords);
        }
    }
}
