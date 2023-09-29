using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Enums;
using StratejiaKata08.Extendible.Interfaces;

namespace StratejiaKata08.Extendible
{
    public class ExtendibleCompoundWordsKata : ICompoundWordsKata
    {
        private readonly ICompoundWordsStrategyFactory _strategyFactory;

        public ExtendibleCompoundWordsKata(ICompoundWordsStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        public Task<List<string>> ExecuteAsync(CompoundWordsKataInput input, CompoundWordStrategyType strategyType)
        {
            var strategy = _strategyFactory.Create(strategyType);

            return strategy.FindCompoundWordsFromListAsync(input);
        }

    }
}
