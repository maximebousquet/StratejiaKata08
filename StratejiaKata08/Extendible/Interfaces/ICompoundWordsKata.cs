using StratejiaKata08.Extendible.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratejiaKata08.Extendible.Interfaces
{
    internal interface ICompoundWordsKata
    {
        public Task<List<string>> Execute(CompoundWordsKataInput input, CompoundWordStrategyType strategyType);
    }
}
