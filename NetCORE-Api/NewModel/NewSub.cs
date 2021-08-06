using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.ClassObj;
using NetCORE_Api.NewPattern;

namespace NetCORE_Api.NewModel
{
    /// <summary>
    /// 加法實作方法
    /// </summary>
    public class NewSub : IPrior, IPostfixToNum, IToPostfix, IPrefix
    {
        ///// <summary>
        ///// 建立私有欄位
        ///// </summary>
        //private int _priority;

        /// <summary>
        /// 封裝成屬性
        /// </summary>
        public int Priority
        {
            get { return 5; }
        }

        /// <summary>
        /// 取得數值
        /// </summary>
        public void GetNum(ResultData resultData)
        {
            resultData.Num2 = Convert.ToDouble(resultData.Stack.Pop());
            resultData.Num1 = Convert.ToDouble(resultData.Stack.Pop());
            resultData.Ans = resultData.Num1 - resultData.Num2;
            resultData.Stack.Push((resultData.Ans.ToString()));
        }

        /// <summary>
        /// 取得後序表達式
        /// </summary>
        /// <param name="data">外部物件為參數</param>
        public void GetPostfix(ClassObject data)
        {
            Model m = new Model();
            data.Prior = Priority;

            if (data.List[data.Times - 1] == "(") // 負數
            {
                data.Container += data.Text;
            }
            else
            {
                data.PostList.Add(data.Container);
                data.Container = string.Empty;
                data.PostList.Remove("");

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
        }

        /// <summary>
        /// 取得前序排列的方法
        /// </summary>
        /// <param name="prefixObj"></param>
        public void GetPrefix(PrefixObj prefixObj)
        {
            prefixObj.op1 = (string)prefixObj.Stack.Peek();
            prefixObj.Stack.Pop();
            prefixObj.op2 = (string)prefixObj.Stack.Peek();
            prefixObj.Stack.Pop();

            prefixObj.temp = prefixObj.text + prefixObj.op2 + prefixObj.op1;

            prefixObj.Stack.Push(prefixObj.temp);
        }
    }
}
