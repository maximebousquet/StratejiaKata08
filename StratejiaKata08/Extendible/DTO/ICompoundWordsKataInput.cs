using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratejiaKata08.Extendible.DTO
{
    public interface ICompoundWordsKataInput
    {
        public List<string> Words { get; }

        public int WordLength { get; }
    }
}
