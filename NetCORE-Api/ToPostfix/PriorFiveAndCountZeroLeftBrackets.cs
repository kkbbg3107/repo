using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    /// <summary>
    /// 實作條件為 優先權:5 stack為空或stack頂為"("
    /// </summary>
    public class PriorFiveAndCountZeroLeftBrackets : IToPostfix
    {
        /// <summary>
        /// 外部物件私有欄位
        /// </summary>
        private ToPostfixData _postdata;

        /// <summary>
        /// 外部物件帶入建構式
        /// </summary>
        /// <param name="postfixData">公開屬性</param>
        public PriorFiveAndCountZeroLeftBrackets(ToPostfixData postfixData)
        {
            _postdata = postfixData;
        }

        /// <summary>
        /// 實作該條件方法
        /// </summary>
        public void GetPostfix()
        {
            _postdata.Stack.Push(_postdata.Text);
        }
    }
}
