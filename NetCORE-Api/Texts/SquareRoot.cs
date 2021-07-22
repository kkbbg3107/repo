using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Texts
{
    public class SquareRoot 
    {
        public Calculate PostAll(Calculate cal)
        {
            if (double.TryParse(cal.TextboxFirst, out var number))
            {
                cal.TextboxFirst = Math.Sqrt(number).ToString();
            }

            return cal;
        }
    }
}
