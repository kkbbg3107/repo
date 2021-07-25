using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace NetCORE_Api.Service
{
    public class Div :IFactory
    {
        public Calculate PostAll(Calculate cal)
        {

            try
            {
                cal.Label += cal.TextboxFirst;

                if (IsFirstMark(cal))
                {
                    cal.Label = cal.Label.Substring(0, cal.Label.Length - 1);
                    cal.Label += cal.Button;
                }
                else
                {
                    cal.Label += cal.Button;
                    cal.TextboxFirst = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"運算子不能再最前方+{ex}");
            }

            return cal;
        }

        public bool IsFirstMark(Calculate cal)
        {
            var first = cal.Label.Substring(cal.Label.Length - 1);
            return first == "+" || first == "-" || first == "*" || first == "/";
        }
    }
}
