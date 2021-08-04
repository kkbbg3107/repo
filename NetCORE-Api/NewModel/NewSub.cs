using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    public class NewSub : IPrior, IPostfixToNum, IOperator, IToPostfix, IToListService
    {
        private ClassObj classObj;

        public NewSub(ClassObj post)
        {
            classObj = post;
        }

        private int _priority;
        public int Priority
        {
            get { return _priority; }
            set { _priority = 5; }
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

        public void GetPostfix(ClassObj data)
        {
            Model m = new Model();
            data.Prior = Priority;

            if (data.Stack.Count != 0)
            {
                while (m.Priority(data.Str) >= data.Prior) // 9 > 5
                {
                    if (data.Stack?.Count != 0)
                    {
                        data.PostList.Add(data.Stack.Pop());
                        data.Stack.TryPeek(out var mark);
                        data.Str = mark;
                        if (data.Str == null)
                        {
                            break;
                        }
                    }
                }
            }

            data.Stack.Push(data.Text);
        }

        public void GetList()
        {
            classObj.PostList.Add(classObj.Str);
            classObj.Str = string.Empty;
            classObj.PostList.Remove("");

            if (classObj.PostList[classObj.PostList.Count - 1] == "(")
            {
                classObj.Str += classObj.Text;
            }
            else
            {
                classObj.PostList.Add(classObj.Text);
            }
        }
    }
}
