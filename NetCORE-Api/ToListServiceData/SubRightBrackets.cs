using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    /// <summary>
    /// 按鈕為"-" 且 list不為空 list第一個元素為")"
    /// </summary>
    public class SubRightBrackets : IToList
    {
        private Data _data;

        public SubRightBrackets(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.List.Add(_data.Text);
        }
    }
}
