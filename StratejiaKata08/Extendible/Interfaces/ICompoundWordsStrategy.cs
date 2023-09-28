﻿using StratejiaKata08.Extendible.DTO;

namespace StratejiaKata08.Extendible.Interfaces
{
    public interface ICompoundWordsStrategy
    {
        public Task<List<string>> FindCompoundWordsFromList(ICompoundWordsKataInput kataInput);

        public CompoundWordStrategyType Supports { get; }
    }
}