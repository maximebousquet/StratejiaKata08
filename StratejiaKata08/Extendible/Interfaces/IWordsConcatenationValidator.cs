using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratejiaKata08.Extendible.Interfaces
{
    public interface IWordsConcatenationValidator
    {
        public Task<List<string>> FindConcatenatedWordsFromHashSetsInList(List<string> wordsToFind, HashSet<string> firstSet, HashSet<string> secondSet);
    }
}
