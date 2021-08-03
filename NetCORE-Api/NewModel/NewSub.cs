using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    public class NewSub : IPrior
    {
        private ClassObj classObj;

        public NewSub(ClassObj post)
        {
            classObj = post;
        }
        public int GetPriority(string c)
        {
            return 5;
        }

        public void GetNum()
        {
            classObj.Num2 = Convert.ToDouble(classObj.Stack.Pop());
            classObj.Num1 = Convert.ToDouble(classObj.Stack.Pop());
            classObj.Ans = classObj.Num1 - classObj.Num2;
            classObj.Stack.Push((classObj.Ans.ToString()));
        }

        public bool IsOperator()
        {
            return true;
        }
    }
}
