using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleTestingSystem.Utils
{
    public class Pair<L, R>
    {
        public L Left { get; set; }
        public R Right { get; set; }

        public Pair() { }

        public Pair(L left, R right)
        {
            Left = left;
            Right = right;
        }
    }
}
