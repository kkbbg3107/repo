using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace NetCORE_Api.Service.Nums
{
    public class Six:IFactory
    {
        public Calculate PostAll(string cal)
        {

            Record r = new Record();
            Calculate c = new Calculate(new Record());

            r.Btn += cal;
            return c; ;
        }
    }
}
