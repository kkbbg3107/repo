﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.ToListServiceData;

namespace NetCORE_Api.NewList
{
    public class RightToList : IToListService
    {
        private Data _data;

        public RightToList(Data data)
        {
            _data = data;
        }

        public void GetList()
        {
            
            _data.List.Add(_data.Container);
            _data.Container = string.Empty;
            _data.List.Remove("");
            _data.List.Add(_data.Text);
        }
    }
}
