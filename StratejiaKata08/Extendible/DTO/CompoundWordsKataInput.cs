using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratejiaKata08.Extendible.DTO
{
    public record CompoundWordsKataInput : ICompoundWordsKataInput
    {
        public List<string> Words { get; init; }

        public int WordLength { get; init; }

        public CompoundWordsKataInput(List<string> words, int wordLength)
        {
            Words = words;
            WordLength = wordLength;
        }
    }
}
