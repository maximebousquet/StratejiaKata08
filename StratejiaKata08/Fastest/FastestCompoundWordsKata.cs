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
        private readonly IEnumerable<ICompoundWordsStrategy> _strategies;

        public FastestCompoundWordsKata(IEnumerable<ICompoundWordsStrategy> strategies)
        {
            _strategies = strategies;
        }

        public Task<List<string>> Execute(ICompoundWordsKataInput input, CompoundWordStrategyType strategyType)
        {
            var strategy = _strategies.FirstOrDefault(s => s.Supports == strategyType);

            if (strategy is null)
                return Task.FromResult(new List<string>());

            return strategy.FindCompoundWordsFromList(input);
        }
    }
}
