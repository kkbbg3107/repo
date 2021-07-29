using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    /// <summary>
    /// 條件為 優先權:9 stack頂端為 "*" 或 "/"
    /// </summary>
    public class PriorNineMulAndDiv : IToPostfix
    {
        /// <summary>
        /// 外部物件私有欄位
        /// </summary>
        private ToPostfixData _postdata;

        /// <summary>
        /// 建構子帶入外部物件
        /// </summary>
        /// <param name="postfixData"></param>
        public PriorNineMulAndDiv(ToPostfixData postfixData)
        {
            _postdata = postfixData;
        }

        /// <summary>
        /// 條件成立後實作
        /// </summary>
        public void GetPostfix()
        {
            _postdata.PostList.Add(_postdata.Stack.Pop().ToString());
            _postdata.Stack.Push(_postdata.Text);
        }
    }
}
