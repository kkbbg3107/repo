using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    /// <summary>
    /// 條件為 優先權:9
    /// </summary>
    public class PriorNine : IToPostfix
    {
        /// <summary>
        /// 外部物件的私有欄位
        /// </summary>
        private ToPostfixData _postdata;

        /// <summary>
        /// 建構子帶入外部物件
        /// </summary>
        /// <param name="postfixData"></param>
        public PriorNine(ToPostfixData postfixData)
        {
            _postdata = postfixData;
        }

        /// <summary>
        /// 條件成立後實作
        /// </summary>
        public void GetPostfix()
        {
            _postdata.Stack.Push(_postdata.Text);
        }
    }
}
