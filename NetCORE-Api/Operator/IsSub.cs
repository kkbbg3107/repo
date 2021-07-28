using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Operator
{
    /// <summary>
    /// 判斷是否為減號
    /// </summary>
    public class IsSub : IBoolenOperator
    {
        public bool IsOperator(string c)
        {
            return true;
        }
    }
}
