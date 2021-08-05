using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.NewPattern
{
    /// <summary>
    /// 取得中序集合的方法
    /// </summary>
    public interface IToListService : IAll
    {
        void GetList();
    }
}
