using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class LeftMark : IFactory
    {
        /// <summary>
        /// 實作左括號
        /// </summary>
        /// <param name="cal">按鈕 text = "("</param>
        /// <returns>控制項成員</returns>
        public Calculate PostAll(string cal)
        {
            Record.Btn = cal;
            Calculate c = new Calculate();

            c.Label = Record.Lbl;
            c.Button = Record.Btn;

            c.Label += c.Button;


            Record.Lbl = c.Label;
         
            return c;
        }
    }
}
