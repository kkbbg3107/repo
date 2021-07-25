using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Texts
{
    public class Negative : IFactory
    {

        public Calculate PostAll(Calculate cal)
        {
            if (cal.Button == "+/-")
            {
                cal.TextboxFirst = "(" + cal.TextboxFirst.Insert(0, "-") + ")";
            }
            
            return cal;
        }
    }
}
