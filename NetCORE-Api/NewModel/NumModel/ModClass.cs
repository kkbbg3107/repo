using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.ClassObj;
using NetCORE_Api.NewPattern;

namespace NetCORE_Api.NewModel.NumModel
{
    public class ModClass : IPrior, IToPostfix, IPostfixToNum
    {
        public int Priority { get; } = 8;
        public void GetPostfix(ClassObject data)
        {
            data.PostList.Add(data.Container);
            data.Container = string.Empty;
            data.PostList.Remove("");
            Model m = new Model();
            data.Prior = Priority;

            if (data.Stack.Count != 0)
            {
                while (m.Priority(data.Str) >= data.Prior) 
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

                if (m.Priority(data.Str) < data.Prior)
                {
                    data.Stack.Push(data.Text);
                }
            }
        }

        public void GetNum(ResultData resultData)
        {
            resultData.Num2 = Convert.ToDouble(resultData.Stack.Pop());
            resultData.Num1 = Convert.ToDouble(resultData.Stack.Pop());
            resultData.Ans = resultData.Num2 % resultData.Num1;
            resultData.Stack.Push((resultData.Ans.ToString()));
        }
    }

}
