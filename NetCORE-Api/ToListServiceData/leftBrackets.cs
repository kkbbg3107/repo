using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    public class leftBrackets : IToList
    {
        private Data _data;

        public leftBrackets(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.list.Add(_data.c);
        }
    }
}
