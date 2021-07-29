using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    public class ClassJudge
    {
        public int GetToken(ToPostfixData postfixData)
        {
            if (postfixData.Prior == -1)
            {
                return 1;
            }

            if (postfixData.Prior == 5 && postfixData.Stack.Count == 0 || postfixData.Stack.Peek() == "(")
            {
                return 2;
            }

            if (postfixData.Stack.Peek() == "*" || postfixData.Stack.Peek() == "/" ||
                postfixData.Stack.Peek() == "+" || postfixData.Stack.Peek() == "-" && postfixData.Prior == 5)
            {
                return 3;
            }

            if (postfixData.Prior == -100)
            {
                return 4;
            }

            if (postfixData.Prior == 9 && postfixData.Stack.Count == 0)
            {
                return 5;
            }

            if (postfixData.Prior == 9 && postfixData.Stack.Peek().ToString() == "*" ||
                postfixData.Stack.Peek().ToString() == "/")
            {
                return 6;
            }

            if (postfixData.Prior == 9)
            {
                return 7;
            }

            return 0;
        }
    }
}
