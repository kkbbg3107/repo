﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.PostfixToNumOperator;
;

namespace NetCORE_Api.PostfixToNumOperator
{
    public class MulString : IObject
    {
        public void GetNum(string c)
        {
            StaticMember.num1 = Convert.ToDouble(StaticMember.stack.Pop());
            StaticMember.num2 = Convert.ToDouble(StaticMember.stack.Pop());

            StaticMember.ans = StaticMember.num2 * StaticMember.num1;
            StaticMember.stack.Push(StaticMember.ans.ToString());
        }
    }
}
