﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    public class PriorFiveAndCountZeroLeftBrackets : IToPostfix
    {
        private ToPostfixData _postdata;

        public PriorFiveAndCountZeroLeftBrackets(ToPostfixData postfixData)
        {
            _postdata = postfixData;
        }
        public void GetPostfix()
        {
            _postdata.Stack.Push(_postdata.Text);
        }
    }
}
