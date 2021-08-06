using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.ClassObj;
using NetCORE_Api.NewPattern;

namespace NetCORE_Api.NewModel
{
    /// <summary>
    /// 左括號實作方法
    /// </summary>
    public class LeftClass : IPrior, IToPostfix
    {
        ///// <summary>
        ///// 優先權私有欄位
        ///// </summary>
        //private int _priority;

        /// <summary>
        /// 封裝好優先權
        /// </summary>
        public int Priority
        {
            get { return -1; }
        }

        /// <summary>
        /// 取得後序表達式
        /// </summary>
        /// <param name="data">帶入的物件</param>
        public void GetPostfix(ClassObject data)
        {
            data.Stack.Push(data.Text);
        }
    }
}
