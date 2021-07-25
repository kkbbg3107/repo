using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Texts
{
    public class Dot : IFactory
    {
        public Calculate PostAll(Calculate cal)
        {
            if (!cal.TextboxFirst.Contains(".") && cal.Button == ".")
            {
                cal.TextboxFirst += cal.Button;
            }

            return cal;
        }
    }
}
