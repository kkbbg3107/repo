using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class Dot : IFactory
    {
        public Calculate PostAll(string cal)
        {
            Calculate c = new Calculate();
            Record.Btn = cal;

            c.TextboxFirst = Record.TextBoxFirst;
            c.Button = Record.Btn;

            if (!c.TextboxFirst.Contains("."))
            {
                c.TextboxFirst += c.Button;
                Record.TextBoxFirst = c.TextboxFirst;
            }

            c.Label = Record.Lbl;

            return c;
        }
    }
}
