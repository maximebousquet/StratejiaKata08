using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratejiaKata08.Fastest
{
    public class FastestCompoundWordsKata : ICompoundWordsKata
    {
        private readonly ICompoundWordsStrategyFactory _strategyFactory;

        public FastestCompoundWordsKata(ICompoundWordsStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        public Task<List<string>> Execute(CompoundWordsKataInput input, CompoundWordStrategyType strategyType)
        {
            var strategy = _strategyFactory.Create(strategyType);

            return strategy.FindCompoundWordsFromList(input);
        }
    }
}
