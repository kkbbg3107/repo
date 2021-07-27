using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Priority
{
    public class MulDivPriority : IPriority
    {
        public int GetPriority(string c)
        {
            return 9;
        }
    }
}
