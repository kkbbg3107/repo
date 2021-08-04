﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.ToListServiceData;

namespace NetCORE_Api.NewList
{
    public class NineToList : IToListService
    {
        private Data _data;

        public NineToList(Data data)
        {
            _data = data;
        }

        public void GetList()
        {
            _data.Container += _data.Text;
        }
    }
}
