using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace NetCORE_Api.Service.Nums
{
    public class Six :IFactory
    {
        public Calculate PostAll(string cal)
        {
            Record.Btn = cal;
            Record.TextBoxFirst = cal;
            Calculate c = new Calculate();
            c.Button = Record.Btn;
            c.TextboxFirst += Record.Btn;
            return c;
        }
    }
}
