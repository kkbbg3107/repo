﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;
using NetCORE_Api.InterFace;

namespace NetCORE_Api.InterFace
{
    /// <summary>
    /// 計算機邏輯介面
    /// </summary>
    public interface IPostAll
    {
        IFactory PostAll( Calculate cal);
    }
}
