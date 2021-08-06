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
    public class NewPlus : IPrior, IPostfixToNum, IOperator, IToPostfix
    {
        /// <summary>
        /// 建立私有欄位
        /// </summary>
        private int _priority;

        /// <summary>
        /// 封裝成屬性
        /// </summary>
        public int Priority
        {
            get { return _priority; }
            set { _priority = 5; }
        }

        public int GetPriority(string text)
        {
            return 5;
        }
        /// <summary>
        /// 取得數值
        /// </summary>
        public void GetNum(ResultData resultData)
        {
            resultData.Num2 = Convert.ToDouble(resultData.Stack.Pop());
            resultData.Num1 = Convert.ToDouble(resultData.Stack.Pop());
            resultData.Ans = resultData.Num2 + resultData.Num1;
            resultData.Stack.Push((resultData.Ans.ToString()));
        }

        /// <summary>
        /// 判斷是否為運算子
        /// </summary>
        /// <returns>是回傳true</returns>
        public bool IsOperator()
        {
            return true;
        }

        /// <summary>
        /// 取得後序表達式
        /// </summary>
        /// <param name="data">外部物件為參數</param>
        public void GetPostfix(ClassObject data)
        {
            data.PostList.Add(data.Container);
            data.Container = string.Empty;
            data.PostList.Remove("");
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
    }
}
