using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    public class PriorNineMulAndDiv : IToPostfix
    {
        private ToPostfixData _postdata;

        public PriorNineMulAndDiv(ToPostfixData postfixData)
        {
            _postdata = postfixData;
        }
        public void GetPostfix()
        {
            _postdata.PostList.Add(_postdata.Stack.Pop().ToString());
            _postdata.Stack.Push(_postdata.Text);
        }
    }
}
