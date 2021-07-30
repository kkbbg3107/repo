using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    /// <summary>
    /// 按鈕為"-" List不為空且list第一個元素為"("
    /// </summary>
    public class SubCountZero : IToList
    {
        private Data _data;

        public SubCountZero(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.List.Add(_data.Str);
            _data.Str = string.Empty;
            _data.List.Add(_data.Text);
        }
    }
}
