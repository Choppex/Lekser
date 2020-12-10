using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lekser
{
    class Token
    {
        public string Name { get; set; }
        public string Argument { get; set; }
        public int Index { get; set; }

        public Token(string name, string argument, int index)
        {
            this.Name = name;
            this.Argument = argument;
            this.Index = index;
        }
    }
}
