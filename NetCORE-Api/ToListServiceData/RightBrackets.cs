using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    /// <summary>
    /// 按鈕為")"
    /// </summary>
    public class RightBrackets : IToList
    {
        private Data _data;

        public RightBrackets(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.List.Add(_data.Text);
        }
    }
}
