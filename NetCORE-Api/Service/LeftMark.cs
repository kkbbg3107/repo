using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class LeftMark : IFactory
    {
        public Calculate PostAll(string cal)
        {
            Record.Btn = cal;
            Calculate c = new Calculate();

            c.Label = Record.Lbl;

            c.Label += c.Button;

            c.Label = Record.Lbl;
            c.Button = Record.Btn;
            return c;
        }
    }
}
