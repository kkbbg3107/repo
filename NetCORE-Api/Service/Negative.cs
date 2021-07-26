using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class Negative : IFactory
    {

        public Calculate PostAll(string cal)
        {
            Record.Btn = cal;
            Calculate c = new Calculate();

            c.TextboxFirst = Record.TextBoxFirst;

            c.TextboxFirst = "(" + c.TextboxFirst.Insert(0, "-") + ")";

            Record.TextBoxFirst = c.TextboxFirst;
            c.Button = Record.Btn;
            c.Label = Record.Lbl;

            return c;
        }
    }
}
