using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Texts
{
    public class Clear : IFactory
    {

        public Calculate PostAll(Calculate cal)
        {
            cal.Label = string.Empty;
            cal.TextboxFirst = string.Empty;

            return cal;
        }
    }
}
