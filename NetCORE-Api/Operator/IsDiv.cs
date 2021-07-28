using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Operator
{
    /// <summary>
    /// 判斷是否為除號
    /// </summary>
    public class IsDiv : IBoolenOperator
    {
        public bool IsOperator(string c)
        {
            return true;
        }
    }
}
