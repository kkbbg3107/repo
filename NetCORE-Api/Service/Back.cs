﻿using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class Back : IFactory
    {
        /// <summary>
        /// 實作按鈕 Back
        /// </summary>
        /// <param name="cal">按鈕text = Back</param>
        /// <returns>控制項成員</returns>
        public Calculate PostAll(string cal)
        {
            Calculate c = new Calculate();
            c.TextboxFirst = Record.TextBoxFirst;

            if (c.TextboxFirst != string.Empty)
            {
                c.TextboxFirst = c.TextboxFirst.Substring(0, c.TextboxFirst.Length - 1);
                Record.TextBoxFirst = c.TextboxFirst;
            }

            Record.Btn = cal;
            c.Button = Record.Btn;
            c.Label = Record.Lbl;

            return c;
        }
    }
}
