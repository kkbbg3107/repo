using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    public class SubCountZero : IToList
    {
        private Data _data;

        public SubCountZero(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.list.Add(_data.str);
            _data.str = string.Empty;
            _data.list.Add(_data.c);
        }
    }
}
