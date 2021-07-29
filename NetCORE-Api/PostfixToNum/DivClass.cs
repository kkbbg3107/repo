using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.PostfixToNum
{
    public class DivClass : IObject
    {
        private ClassObj classObj;

        public DivClass(ClassObj post)
        {
            classObj = post;
        }

        public void GetNum()
        {
            classObj.num2 = Convert.ToDouble(classObj.stack.Pop());
            classObj.num1 = Convert.ToDouble(classObj.stack.Pop());
            classObj.ans = classObj.num2 / classObj.num1;
            classObj.stack.Push((classObj.ans.ToString()));
        }
    }
}
