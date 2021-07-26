using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class RightMark : IFactory
    {
        public Calculate PostAll(string cal)
        {
            Record.Btn = cal;
            Calculate c = new Calculate();

            c.Button = Record.Btn;
            c.TextboxFirst = Record.TextBoxFirst;
            c.Label = Record.Lbl;

            c.Label += c.TextboxFirst + c.Button;
            c.TextboxFirst = string.Empty;

            Record.TextBoxFirst = c.TextboxFirst;
            c.Label = Record.Lbl;
            return c;
        }
    }
}
