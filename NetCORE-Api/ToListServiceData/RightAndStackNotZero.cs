using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    /// <summary>
    /// 按鈕為")" stack不為空
    /// </summary>
    public class RightAndStackNotZero : IToList

    {
        private Data _data;

        public RightAndStackNotZero(Data data)
        {
            _data = data;
        }
        public void GetResult()
        {
            _data.Container += _data.Stack.Pop();
            _data.Container += _data.Str;
            _data.List.Add(_data.Container); // 把負數加到list
            _data.Container = string.Empty; // 清空字串容器
            _data.Str = string.Empty;

            _data.List.Add(_data.Text);
        }
    }
}
