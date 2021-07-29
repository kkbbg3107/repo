using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    /// <summary>
    /// 條件為 優先權:-100
    /// </summary>
    public class PriorHundred : IToPostfix
    {
        /// <summary>
        /// 外部物件私有欄位
        /// </summary>
        private ToPostfixData _postdata;

        /// <summary>
        /// 建構子帶入外部物件
        /// </summary>
        /// <param name="postfixData"></param>
        public PriorHundred(ToPostfixData postfixData)
        {
            _postdata = postfixData;
        }

        /// <summary>
        /// 條件成立後實作
        /// </summary>
        public void GetPostfix()
        {
            while (_postdata.Stack.Peek() != "(")
            {
                _postdata.PostList.Add(_postdata.Stack.Pop().ToString()); // 直到stack裡遇到'('把上面的運算子都pop出來
            }

            _postdata.Stack.Pop(); // 遇到的'('也要移掉
        }
    }
}
