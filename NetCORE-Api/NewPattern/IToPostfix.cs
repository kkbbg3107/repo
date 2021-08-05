using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewPattern
{
    /// <summary>
    /// k取得後序表達式的方法
    /// </summary>
    public interface IToPostfix : IAll
    {
        void GetPostfix(ClassObj data);
    }
}
