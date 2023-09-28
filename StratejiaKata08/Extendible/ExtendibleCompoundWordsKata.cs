using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratejiaKata08.Extendible
{
    public class ExtendibleCompoundWordsKata : ICompundWordsKata
    {
        private readonly IList<ICompoundWordsStrategy> _strategies;

        public ExtendibleCompoundWordsKata(IEnumerable<ICompoundWordsStrategy> strategies)
        {
            _strategies = strategies.ToList();
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
