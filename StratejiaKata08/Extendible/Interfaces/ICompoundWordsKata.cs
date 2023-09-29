using StratejiaKata08.Extendible.DTO;
namespace StratejiaKata08.Extendible.Interfaces
{
    public interface ICompoundWordsKata
    {
        public Task<List<string>> ExecuteAsync(CompoundWordsKataInput input, CompoundWordStrategyType strategyType);
    }
}
