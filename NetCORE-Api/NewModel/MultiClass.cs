using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    public class MultiClass : IPrior
    {
        private ClassObj classObj;

        public MultiClass(ClassObj post)
        {
            classObj = post;
        }
        public int GetPriority(string c)
        {
            return 9;
        }

        public void GetNum()
        {
            classObj.Num2 = Convert.ToDouble(classObj.Stack.Pop());
            classObj.Num1 = Convert.ToDouble(classObj.Stack.Pop());
            classObj.Ans = classObj.Num2 * classObj.Num1;
            classObj.Stack.Push((classObj.Ans.ToString()));
        }
    }
}
