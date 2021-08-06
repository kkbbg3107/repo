using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;

namespace NetCORE_Api.ClassObj
{
    public class NumObj
    {
        /// <summary>
        /// 判斷任何不在 0~9 的數字於字典內的Key值
        /// </summary>
        private string _numobj;
        public NumObj(string text)
        {
            _numobj = text;
        }

        /// <summary>
        /// 不符合過濾方法 KEY就為"X"
        /// </summary>
        public string Key => IsNumber(_numobj) ? "X" : _numobj; 

        /// <summary>
        /// 判斷是否為數字
        /// </summary>
        /// <param name="text">傳入的字串</param>
        /// <returns>數字為true</returns>
        private bool IsNumber(string text)
        {
            return double.TryParse(text, out var number);
        }
    }
}
