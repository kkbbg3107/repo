﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.Priority
{
    /// <summary>
    /// 右括號優先權
    /// </summary>
    public class RightMarkPriority :IPriority
    {
        public int GetPriority(string c)
        {
            return -100;
        }
    }
}