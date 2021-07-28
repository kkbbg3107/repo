using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.PostfixToNum
{
    public class DivClass : IObject
    {
        private ClassObj _post;

        public DivClass(ClassObj post)
        {
            _post = post;
        }

        public void GetNum(ClassObj classObj)
        {
            classObj.num2 = Convert.ToDouble(classObj.stack.Pop());
            classObj.num1 = Convert.ToDouble(classObj.stack.Pop());
            classObj.ans = classObj.num2 / classObj.num1;
            classObj.stack.Push((classObj.ans.ToString()));
        }
    }
}
