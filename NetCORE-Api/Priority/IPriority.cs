using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Priority
{
    public interface IPriority
    {
        /// <summary>
        /// 抽象取得優先權的方法
        /// </summary>
        /// <param name="c">輸入的值</param>
        /// <returns>優先權大小</returns>
        int GetPriority(string c);
    }
}
