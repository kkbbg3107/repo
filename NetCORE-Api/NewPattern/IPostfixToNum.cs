﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.ClassObj;

namespace NetCORE_Api.NewPattern
{
    /// <summary>
    /// 取得數值的方法
    /// </summary>
    public interface IPostfixToNum : IAll
    {
        void GetNum(ResultData resultData);
    }
}
