using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    public class PriorHundred : IToPostfix
    {
        private ToPostfixData _postdata;

        public PriorHundred(ToPostfixData postfixData)
        {
            _postdata = postfixData;
        }
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
