namespace StratejiaKata08.Readable
{
    public class ReadableKata
    {
        private const int LengthOfWordToFind = 6;

        private List<string> AllWords = new List<string>();

        public ReadableKata(List<string> words)
        {
            AllWords = words;
        }

        public async Task<List<string>> Execute()
        {
            if(AllWords.Count <= 0) 
                return new List<string>();

            var wordsToFind = AllWords.Where(w => w.Length == LengthOfWordToFind).ToList();

            AllWords.RemoveAll(w => w.Length >= LengthOfWordToFind);

            var wordsWithOneLetter = new HashSet<string>(AllWords.Where(w => w.Length == 1));
            var wordsWithTwoLetters = new HashSet<string>(AllWords.Where(w => w.Length == 2));
            var wordsWithThreeLetters = new HashSet<string>(AllWords.Where(w => w.Length == 3));
            var wordsWithFourLetters = new HashSet<string>(AllWords.Where(w => w.Length == 4));
            var wordsWithFiveLetters = new HashSet<string>(AllWords.Where(w => w.Length == 5));

            var tasksToExecute = new List<Task<List<string>>>
            {
                FindWordsThatAreConcatenationsOf(wordsToFind, wordsWithOneLetter, wordsWithFiveLetters),
                FindWordsThatAreConcatenationsOf(wordsToFind, wordsWithTwoLetters, wordsWithFourLetters),
                FindWordsThatAreConcatenationsOf(wordsToFind, wordsWithThreeLetters, wordsWithThreeLetters),
                FindWordsThatAreConcatenationsOf(wordsToFind, wordsWithFourLetters, wordsWithTwoLetters),
                FindWordsThatAreConcatenationsOf(wordsToFind, wordsWithFiveLetters, wordsWithOneLetter)
            };

            var results = await Task.WhenAll(tasksToExecute);

            return results.SelectMany(results => results).Distinct().ToList();
        }

        private Task<List<string>> FindWordsThatAreConcatenationsOf(List<string> sixLetterWords, HashSet<string> prefixes, HashSet<string> suffixes)
        {
            var concatenatedWords = new List<string>();

            foreach (var wordToTest in sixLetterWords)
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
