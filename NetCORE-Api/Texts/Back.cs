using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Texts
{
    public class Back : IFactory
    {
        public Calculate PostAll(Calculate cal)
        {
            if (cal.Button == "Back" && cal.TextboxFirst != string.Empty)
            {
                cal.TextboxFirst = cal.TextboxFirst.Substring(0, cal.TextboxFirst.Length - 1);
            }

            return cal;
        }
    }
}
