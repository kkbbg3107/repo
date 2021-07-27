using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Priority
{
    public class PriorityService
    {
        private readonly IPriority _priority;

        public PriorityService(IPriority priority)
        {
            _priority = priority;
        }

        public int PriorityLevel(string c)
        {
            return _priority.GetPriority(c);
        }
    }
}
