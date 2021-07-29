using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    /// <summary>
    /// 實作轉為後序
    /// </summary>
    public interface IToPostfix
    {
        /// <summary>
        /// 轉後序方法
        /// </summary>
        void GetPostfix();
    }
}
