using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace NetCORE_Api.Service.Nums
{
    public class One :IFactory
    {
        public Calculate PostAll(Calculate cal)
        {

            cal.TextboxFirst += cal.Button;
            return cal;
        }
    }
}
