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
        public Task<List<string>> FindConcatenatedWordsFromHashSetsInList(List<string> wordsToFind, HashSet<string> firstSet, HashSet<string> secondSet)
        {
            var concatenatedWords = new List<string>();

            foreach (var wordWithRequiredLength in wordsToFind)
            {
                foreach (var wordInFirstSet in firstSet)
                {
                    if (wordWithRequiredLength.StartsWith(wordInFirstSet))
                    {
                        var restOfWordMissing = wordWithRequiredLength.Substring(wordInFirstSet.Length);

                        if (secondSet.Contains(restOfWordMissing))
                        {
                            concatenatedWords.Add(wordWithRequiredLength);
                        }
                    }

                }
            }

            return Task.FromResult(concatenatedWords);
        }
    }
}
