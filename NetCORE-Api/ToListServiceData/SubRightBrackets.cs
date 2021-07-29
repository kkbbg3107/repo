using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    public class SubRightBrackets : IToList
    {
        private Data _data;

        public SubRightBrackets(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.list.Add(_data.c);
        }
    }
}
