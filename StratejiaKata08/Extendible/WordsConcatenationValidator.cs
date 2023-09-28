using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratejiaKata08.Extendible.Interfaces;

namespace StratejiaKata08.Extendible
{
    public class WordsConcatenationValidator : IWordsConcatenationValidator
    {
        public Task<List<string>> FindConcatenatedWordsFromHashSetsInList(List<string> wordsToFind, HashSet<string> prefixes, HashSet<string> suffixes)
        {
            var concatenatedWords = new List<string>();

            foreach (var wordToTest in wordsToFind)
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
