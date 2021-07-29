using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    /// <summary>
    /// 判斷各種情況該回傳哪個值作為key
    /// </summary>
    public class ClassJudge
    {
        public int GetToken(ToPostfixData postfixData)
        {
            if (postfixData.Prior == -1)
            {
                return 1;
            }

            if (IsPriorFive(postfixData))
            {
                return 2;
            }

            if (IsPriorFiveOperator(postfixData))
            {
                return 3;
            }

            if (IsPriorHundred(postfixData))
            {
                return 4;
            }

            if (IsPriorNineZero(postfixData))
            {
                return 5;
            }

            if (IsNineMulDiv(postfixData))
            {
                return 6;
            }

            if (IsPriorNine(postfixData))
            {
                return 7;
            }

            return 0;
        }

        /// <summary>
        /// 條件為 優先權:5 stack為空或stack最上面為")"
        /// </summary>
        /// <param name="d">該判斷式所需物件</param>
        /// <returns>是否符合條件</returns>
        public static bool IsPriorFive(ToPostfixData d)
        {
            return d.Prior == 5 && (d.Stack.Count == 0 || d.Stack.Peek() == "(");
        }

        /// <summary>
        /// 條件為 優先權:5 stack為運算子任意一個
        /// </summary>
        /// <param name="d">該判斷式所需物件</param>
        /// <returns>是否符合條件</returns>
        public static bool IsPriorFiveOperator(ToPostfixData postfixData)
        {
            return postfixData.Prior == 5 && (postfixData.Stack.Peek() == "*" || postfixData.Stack.Peek() == "/" ||
                   postfixData.Stack.Peek() == "+" || postfixData.Stack.Peek() == "-");
        }

        /// <summary>
        /// 條件為 優先權:-100
        /// </summary>
        /// <param name="d">該判斷式所需物件</param>
        /// <returns>是否符合條件</returns>
        public static bool IsPriorHundred(ToPostfixData postfixData)
        {
            return postfixData.Prior == -100;
        }

        /// <summary>
        /// 條件為 優先權:9 stack為空
        /// <param name="d">該判斷式所需物件</param>
        /// <returns>是否符合條件</returns>
        public static bool IsPriorNineZero(ToPostfixData postfixData)
        {
            return postfixData.Prior == 9 && postfixData.Stack.Count == 0;
        }

        /// <summary>
        /// 條件為 優先權:9 stack頂端為 "*" 或 "/"
        /// </summary>
        /// <param name="d">該判斷式所需物件</param>
        /// <returns>是否符合條件</returns>
        public static bool IsNineMulDiv(ToPostfixData postfixData)
        {
            return postfixData.Prior == 9 && (postfixData.Stack.Peek().ToString() == "*" ||
                   postfixData.Stack.Peek().ToString() == "/");
        }

        /// <summary>
        /// 條件為 優先權:9 
        /// </summary>
        /// <param name="d">該判斷式所需物件</param>
        /// <returns>是否符合條件</returns>
        public static bool IsPriorNine(ToPostfixData postfixData)
        {
            return postfixData.Prior == 9;
        } 
    }
}
