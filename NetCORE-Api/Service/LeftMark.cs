using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class LeftMark
    {
        public Calculate PostAll(Calculate cal)
        {
            cal.Label += cal.Button;

            return cal;
        }
    }
}
