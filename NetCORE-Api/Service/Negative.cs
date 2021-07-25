using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class Negative : IFactory
    {

        public Calculate PostAll(Calculate cal)
        {
            cal.TextboxFirst = "(" + cal.TextboxFirst.Insert(0, "-") + ")";

            return cal;
        }
    }
}
