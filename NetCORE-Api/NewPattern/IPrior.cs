using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.NewPattern
{
    /// <summary>
    /// 優先權大小
    /// </summary>
    public interface IPrior : IAll
    {
        int Priority { get; set; }

        int GetPriority(string text);

    }
}
