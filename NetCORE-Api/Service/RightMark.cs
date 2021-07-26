using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class RightMark
    {
        public Calculate PostAll(Calculate cal)
        {
            cal.Label += cal.TextboxFirst + cal.Button;
            cal.TextboxFirst = string.Empty;

            return cal;
        }
    }
}
