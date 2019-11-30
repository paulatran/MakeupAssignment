using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_2
{
    class insults
    {
        public int number { get; set; }
        public string insult { get; set; }
        public override string ToString()
        {
            return insult;
        }
    }
}
