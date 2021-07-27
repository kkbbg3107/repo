using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Priority
{
    public interface IPriority
    {
        int GetPriority(string c);
    }
}
