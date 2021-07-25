using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Texts
{
    public class Num : IFactory
    {
        public Calculate PostAll(Calculate cal)
        {
            cal.TextboxFirst += cal.Button;
            
            return cal;
        }
    }
}
