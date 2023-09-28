using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratejiaKata08.Extendible.Interfaces
{
    public interface ICompoundWordsStrategyFactory
    {
        public ICompoundWordsStrategy Create(CompoundWordStrategyType strategyType);
    }
}
