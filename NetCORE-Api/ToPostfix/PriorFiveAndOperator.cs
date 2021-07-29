using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    /// <summary>
    /// 條件為 優先權:5 stack頂端為任意運算子
    /// </summary>
    public class PriorFiveAndOperator : IToPostfix
    {
        /// <summary>
        /// 外部物件私有欄位
        /// </summary>
        private ToPostfixData _postdata;

        /// <summary>
        /// 建構子帶入外部物件
        /// </summary>
        /// <param name="postfixData"></param>
        public PriorFiveAndOperator(ToPostfixData postfixData)
        {
            _postdata = postfixData;
        }

        /// <summary>
        /// 條件成立後實作
        /// </summary>
        public void GetPostfix()
        {
            _postdata.PostList.Add(_postdata.Stack.Pop().ToString());
            _postdata.Times--; // 重新回到這個運算子在run一次
            _postdata.RecordLen++; // 記數也要加回去
        }
    }
}
