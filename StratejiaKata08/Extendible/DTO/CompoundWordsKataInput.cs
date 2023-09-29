using System;
namespace StratejiaKata08.Extendible.DTO
{
    public record CompoundWordsKataInput
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
