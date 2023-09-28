using StratejiaKata08.Extendible.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
