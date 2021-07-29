using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    public class RightAndStackNotZero : IToList

    {
        private Data _data;

        public RightAndStackNotZero(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.container += _data.stack.Pop();
            _data.container += _data.str;
            _data.list.Add(_data.container); // 把負數加到list
            _data.container = string.Empty; // 清空字串容器
            _data.str = string.Empty;

            _data.list.Add(_data.c);
        }
    }
}
