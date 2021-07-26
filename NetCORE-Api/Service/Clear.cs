using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class Clear :IFactory
    {

        public Calculate PostAll(string cal)
        {
            Record.Btn = cal;
            Record.Lbl = string.Empty;
            Record.TextBoxFirst = string.Empty;
            Record.TextBoxResult = string.Empty;
            Calculate c = new Calculate();

            c.Label = Record.Lbl;
            c.TextboxFirst = Record.TextBoxFirst;
            c.Button = Record.Btn;
            return c;
        }
    }
}
