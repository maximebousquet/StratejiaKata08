using System;
namespace StratejiaKata08.Extendible.Interfaces
{
    public interface IWordsConcatenationValidator
    {
        public Task<List<string>> FindWordsThatAreConcatenationsOf(List<string> wordsToFind, HashSet<string> firstSet, HashSet<string> secondSet);
    }
}
