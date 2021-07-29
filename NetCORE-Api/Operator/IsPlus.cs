using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.Operator;

namespace NetCORE_Api.Operator
{
    /// <summary>
    /// 判斷是否為加號
    /// </summary>
    public class IsPlus : IBoolenOperator
    {
        public bool IsOperator(string c)
        {
            return true;
        }
    }
}
