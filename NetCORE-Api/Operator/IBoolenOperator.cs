using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Operator
{
    /// <summary>
    /// 抽象判斷是否為運算子的方法
    /// </summary>
    public interface IBoolenOperator
    {
        bool IsOperator(string c);
    }
}
