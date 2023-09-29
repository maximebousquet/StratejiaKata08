using System;
using StratejiaKata08.Extendible.Enums;

namespace StratejiaKata08.Extendible.Interfaces
{
    public interface ICompoundWordsStrategyFactory
    {
        public ICompoundWordsStrategy Create(CompoundWordStrategyType strategyType);
    }
}
