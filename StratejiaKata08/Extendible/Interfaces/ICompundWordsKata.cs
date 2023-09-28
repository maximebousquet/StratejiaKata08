using StratejiaKata08.Extendible.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratejiaKata08.Extendible.Interfaces
{
    internal interface ICompundWordsKata
    {
        public Task<List<string>> Execute(ICompoundWordsKataInput input, CompoundWordStrategyType strategyType);
    }
}
