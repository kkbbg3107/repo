using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Texts
{
    public class RightMark : IFactory
    {
        public Calculate PostAll(Calculate cal)
        {
            if (cal.Button == ")")
            {
                cal.Label += cal.TextboxFirst + cal.Button;
                cal.TextboxFirst = string.Empty;
            }

            return cal;
        }
    }
}
