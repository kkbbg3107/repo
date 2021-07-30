using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.PostfixToNum
{
    /// <summary>
    /// 乘法類
    /// </summary>
    public class MulClass : IObject
    {
        /// <summary>
        /// IsOperator需要使用的物件私有欄位
        /// </summary>
        private ClassObj classObj;

        /// <summary>
        /// 建構子帶入外部物件
        /// </summary>
        /// <param name="post">外部物件</param>
        public MulClass(ClassObj post)
        {
            classObj = post;
        }

        /// <summary>
        /// 實作乘法方法
        /// </summary>
        public void GetNum()
        {
            classObj.Num2 = Convert.ToDouble(classObj.Stack.Pop());
            classObj.Num1 = Convert.ToDouble(classObj.Stack.Pop());
            classObj.Ans = classObj.Num2 * classObj.Num1;
            classObj.Stack.Push((classObj.Ans.ToString()));
        }
    }
}
