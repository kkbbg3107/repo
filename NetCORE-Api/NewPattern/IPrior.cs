using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.NewPattern
{
    public interface IPrior : IAll
    {
        int Priority { get; set; }
    }
}
