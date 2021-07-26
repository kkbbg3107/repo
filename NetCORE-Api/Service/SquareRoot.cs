﻿using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class SquareRoot : IFactory
    {
        /// <summary>
        /// 實作開根號
        /// </summary>
        /// <param name="cal">按鈕text = "√"</param>
        /// <returns>控制項成員</returns>
        public Calculate PostAll(string cal)
        {
            Record.Btn = cal;
            Calculate c = new Calculate();

            c.TextboxFirst = Record.TextBoxFirst;

            if (double.TryParse(c.TextboxFirst, out var number))
            {
                c.TextboxFirst = Math.Sqrt(number).ToString();
                Record.TextBoxFirst = c.TextboxFirst;
            }

            c.Button = Record.Btn;
            c.Label = Record.Lbl;
            return c;
        }
    }
}
