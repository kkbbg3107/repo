using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Texts
{
    public class Equal : IFactory
    {
        public Calculate PostAll(Calculate cal)
        {
            cal.Label += cal.TextboxFirst;
            cal.TextboxFirst = string.Empty;

            return cal;
        }
    }
}
