using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    /// <summary>
    /// 按鈕為加減除
    /// </summary>
    public class PlusDivMul : IToList
    {
        private Data _data;

        public PlusDivMul(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.List.Add(_data.Text);
        }
    }
}
