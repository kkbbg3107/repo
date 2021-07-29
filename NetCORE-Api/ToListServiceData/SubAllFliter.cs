using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    public class SubAllFliter : IToList
    {
        private Data _data;

        public SubAllFliter(Data data)
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
