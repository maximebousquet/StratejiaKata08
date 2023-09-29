using StratejiaKata08.Extendible.Interfaces;

namespace StratejiaKata08.Extendible.Factories
{
    public class CompoundWordsStrategyFactory : ICompoundWordsStrategyFactory
    {
        private readonly IEnumerable<ICompoundWordsStrategy> _strategies;

        public CompoundWordsStrategyFactory(IEnumerable<ICompoundWordsStrategy> strategies)
        {
            _strategies = strategies;
        }

        public ICompoundWordsStrategy Create(CompoundWordStrategyType strategyType)
        {
            var strategy = _strategies.FirstOrDefault(s => s.Supports == strategyType);

            if (strategy is null)
                throw new NotImplementedException();

            return strategy;
        }
    }
}
