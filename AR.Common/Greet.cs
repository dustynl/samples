using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR.Common
{
    public class Greet
    {
        public Greet(string who)
        {
            Who = who;
        }
        public string Who { get; private set; }
    }
}
