using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Priority
{
    /// <summary>
    /// 乘號優先權
    /// </summary>
    public class MulDivPriority : IPriority
    {
        public int GetPriority(string c)
        {
            return 9;
        }
    }
}
