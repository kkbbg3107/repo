using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    public class NewMulti : IPrior, IPostfixToNum, IOperator, IToPostfix, IToListService
    {
        private ClassObj classObj;

        public NewMulti(ClassObj post)
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
            classObj.Ans = classObj.Num1 * classObj.Num2;
            classObj.Stack.Push((classObj.Ans.ToString()));
        }

        public bool IsOperator()
        {
            return true;
        }

        public void GetPostfix(ClassObj data)
        {
            data.Prior = GetPriority(data.Text);
            data.Stack.Push(data.Text);
        }

        public void GetList()
        {
            classObj.PostList.Add(classObj.Str);
            classObj.Str = string.Empty;
            classObj.PostList.Remove("");
            classObj.PostList.Add(classObj.Text);
        }
    }
}
