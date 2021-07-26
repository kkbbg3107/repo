using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace NetCORE_Api.Service
{
    public class Plus : IFactory
    {
        /// <summary>
        /// 實作加法
        /// </summary>
        /// <param name="c">按鈕 text = "+"</param>
        /// <returns>控制項成員</returns>
        public Calculate PostAll(string c)
        {
            Calculate cal = new Calculate();
            try
            {
                Record.Btn = c;
                cal.Button = Record.Btn;
                cal.Label = Record.Lbl;

                cal.Label += Record.TextBoxFirst;
                
                if (IsLastMark(cal))
                {
                    cal.Label = cal.Label.Substring(0, cal.Label.Length - 1);
                    cal.Label += cal.Button;
                }
                else
                {
                    cal.Label += cal.Button;
                    cal.TextboxFirst = string.Empty;
                }
                Record.Lbl = cal.Label;
                Record.TextBoxFirst = string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"運算子不能再最前方+{ex}");
            }

            return cal;
        }

        /// <summary>
        /// 最後的符號是否為運算子
        /// </summary>
        /// <param name="cal">按鈕text = 運算子</param>
        /// <returns>是否為運算子</returns>
        public bool IsLastMark(Calculate cal)
        {
            var first = cal.Label.Substring(cal.Label.Length - 1);
            return first == "+" || first == "-" || first == "*" || first == "/";
        }
    }
}
