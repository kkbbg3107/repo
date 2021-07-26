using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class Equal : IFactory
    {
        /// <summary>
        /// 實作 "="
        /// </summary>
        /// <param name="cal">按鈕 "="</param>
        /// <returns>控制項成員</returns>
        public Calculate PostAll(string cal)
        {
            Record.Btn = cal;
            Calculate c = new Calculate();

            c.Label = Record.Lbl;
            c.TextboxFirst = Record.TextBoxFirst;

            c.Label += c.TextboxFirst;
            c.TextboxFirst = string.Empty;

            Record.TextBoxFirst = c.TextboxFirst;
            Record.Lbl = c.Label;
            c.Button = Record.Btn;

            return c;
        }
    }
}
