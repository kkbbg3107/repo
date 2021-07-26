using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace NetCORE_Api.Service.Nums
{
    public class Five :IFactory
    {
        public Calculate PostAll(string cal)
        {
            Record.Btn = cal;
           
            Calculate c = new Calculate();
            c.Button = Record.Btn;
            Record.TextBoxFirst += Record.Btn;
            c.TextboxFirst = Record.TextBoxFirst;
            c.Label = Record.Lbl;
            return c;
        }
    }
}
