using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Service
{
    public class Api : IFactory
    {
        /// <summary>
        /// 實作api按鈕方法
        /// </summary>
        /// <param name="cal">api按鈕</param>
        /// <returns>前中後序+結果值</returns>
        public Calculate PostAll(string cal)
        {
            Model model = new Model();
            Record.Btn = cal;
            Calculate c = new Calculate();
            c.Label = Record.Lbl;

            var postList = model.ToPostfix(c.Label); // 後序表達式

            Response data = new Response();
            
            data.Prefix = model.PostfixToPrefix(postList); 
            data.Formula = c.Label;
            data.Postfix = string.Join(",", postList.ToArray());
            data.Result = model.PostfixToNum(postList); // 運算結果

            c.Button = Record.Btn;
            c.TextboxResult = $"PostFix : {data.Postfix}, Formula : {data.Formula}, Prefix : {data.Prefix}, Result : {data.Result}";
            return c;
        }
    }
}
