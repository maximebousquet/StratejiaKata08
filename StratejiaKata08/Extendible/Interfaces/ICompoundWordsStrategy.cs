using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Enums;

namespace StratejiaKata08.Extendible.Interfaces
{
    public interface ICompoundWordsStrategy
    {
        public Task<List<string>> FindCompoundWordsFromListAsync(CompoundWordsKataInput kataInput);

        public CompoundWordStrategyType Supports { get; }
    }
}
