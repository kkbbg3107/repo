using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    public class NewDiv : IPrior, IPostfixToNum, IOperator, IToPostfix, IToListService
    {
        private ClassObj classObj;

        public NewDiv(ClassObj post)
        {
            classObj = post;
        }

        private int _priority;
        public int Priority
        {
            get { return _priority;}
            set { _priority = 9; }
        }

        public void GetNum()
        {
            classObj.Num2 = Convert.ToDouble(classObj.Stack.Pop());
            classObj.Num1 = Convert.ToDouble(classObj.Stack.Pop());
            classObj.Ans = classObj.Num1 / classObj.Num2;
            classObj.Stack.Push((classObj.Ans.ToString()));
        }

        public bool IsOperator()
        {
            return true;
        }

        public void GetPostfix(ClassObj data)
        {
            data.Prior = Priority;
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
