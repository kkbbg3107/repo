using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace NetCORE_Api.Service.Nums
{
    public class One : IFactory
    {
        /// <summary>
        /// 點擊到該按鈕的實作
        /// </summary>
        /// <param name="cal">按鈕text = 8</param>
        /// <returns>控制項成員</returns>
        public Calculate PostAll(string cal)
        {
            Record.Btn = cal;

            Calculate c = new Calculate();
            c.Button = Record.Btn;
            Record.TextBoxFirst += Record.Btn;
            c.TextboxFirst = Record.TextBoxFirst;
            c.Label = Record.Lbl;
            return c;
        }
    }
}
