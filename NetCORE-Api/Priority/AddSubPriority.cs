using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Priority
{
    public class AddSubPriority : IPriority
    {
        public int GetPriority(string c)
        {
            return 5;
        }
    }
}
