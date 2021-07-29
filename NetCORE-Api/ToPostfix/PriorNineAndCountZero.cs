using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    public class PriorNineAndCountZero : IToPostfix
    {
        private ToPostfixData _postdata;

        public PriorNineAndCountZero(ToPostfixData postfixData)
        {
            _postdata = postfixData;
        }
        public void GetPostfix()
        {
            _postdata.Stack.Push(_postdata.Text);
        }
    }
}
