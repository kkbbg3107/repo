﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    public class PlusDivMul : IToList
    {
        private Data _data;

        public PlusDivMul(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.list.Add(_data.c);
        }
    }
}
