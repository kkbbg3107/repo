using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace NetCORE_Api.Service.Nums
{
    public class Eight:IFactory
    {
        public Calculate PostAll(string cal)
        {
            Record r = new Record();

            r.Btn += cal;
            Calculate c = new Calculate(r);
            return c;
        }
    }
}
