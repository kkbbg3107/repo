using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Texts
{
    public class Operator : IFactory
    {
        public Calculate PostAll(Calculate cal)
        {
            switch (cal.Button)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    try
                    {
                        cal.Label += cal.TextboxFirst;
                        if (cal.Label.Substring(cal.Label.Length - 1) == "+" || cal.Label.Substring(cal.Label.Length - 1) == "-" || cal.Label.Substring(cal.Label.Length - 1) == "*" || cal.Label.Substring(cal.Label.Length - 1) == "/")
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

                    break;
            }

            return cal;
        }
    }
}
