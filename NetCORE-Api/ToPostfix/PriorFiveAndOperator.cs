using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    public class PriorFiveAndOperator : IToPostfix
    {
        private ToPostfixData _postdata;

        public PriorFiveAndOperator(ToPostfixData postfixData)
        {
            _postdata = postfixData;
        }
        public void GetPostfix()
        {
            _postdata.PostList.Add(_postdata.Stack.Pop().ToString());
            _postdata.Times--; // 重新回到這個運算子在run一次
            _postdata.RecordLen++; // 記數也要加回去
        }
    }
}
