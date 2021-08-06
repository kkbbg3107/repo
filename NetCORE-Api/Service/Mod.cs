using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace NetCORE_Api.Service
{
    public class Mod : IFactory
    {
        public Calculate PostAll(string c)
        {
            Calculate cal = new Calculate();
            try
            {
                Record.Btn = c;
                cal.Button = Record.Btn;
                cal.Label = Record.Lbl;

                cal.Label += Record.TextBoxFirst;

                //cal = (IsLastMark(cal)) ? Repeat(cal) : FirstMark(cal);

                Record.Lbl = cal.Label;
                Record.TextBoxFirst = string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"運算子不能再最前方+{ex}");
            }

            return cal;
        }
    }
}
