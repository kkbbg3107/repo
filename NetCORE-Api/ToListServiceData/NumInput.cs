using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    /// <summary>
    /// 按鈕為數字時
    /// </summary>
    public class NumInput : IToList
    {
        private Data _data;

        public NumInput(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.Str += _data.Text;
        }
    }
}
