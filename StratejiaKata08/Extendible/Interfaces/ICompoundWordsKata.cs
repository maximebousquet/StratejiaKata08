using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Enums;

namespace StratejiaKata08.Extendible.Interfaces
{
    public interface ICompoundWordsKata
    {
        public Task<List<string>> ExecuteAsync(CompoundWordsKataInput input, CompoundWordStrategyType strategyType);
    }
}
