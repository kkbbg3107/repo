using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    public class NewPlus : IPrior, IPostfixToNum, IOperator, IToPostfix, IToListService
    {
        private ClassObj classObj;

        public NewPlus(ClassObj post)
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
            classObj.Ans = classObj.Num2 + classObj.Num1;
            classObj.Stack.Push((classObj.Ans.ToString()));
        }

        public bool IsOperator()
        {
            return true;
        }

        public void GetPostfix(ClassObj data)
        {
            Model m = new Model();
            data.Prior = GetPriority(data.Text);
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
            classObj.PostList.Add(classObj.Text);
        }
    }
}
