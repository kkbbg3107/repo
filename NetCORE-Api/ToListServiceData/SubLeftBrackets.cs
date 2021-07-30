using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    /// <summary>
    /// 按鈕為"-" 且list不為空list第一個元素為"("
    /// </summary>
    public class SubLeftBrackets : IToList
    {
        private Data _data;

        public SubLeftBrackets(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.Stack.Push(_data.Text);
        }
    }
}
