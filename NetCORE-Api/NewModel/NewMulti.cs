using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.ClassObj;
using NetCORE_Api.NewPattern;

namespace NetCORE_Api.NewModel
{
    /// <summary>
    /// 乘法實作方法
    /// </summary>
    public class NewMulti : IPrior, IPostfixToNum, IOperator, IToPostfix
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
            set { _priority = 9; }
        }

        public int GetPriority(string text)
        {
            return 9;
        }

        /// <summary>
        /// 取得數值
        /// </summary>
        public void GetNum(ResultData resultData)
        {
            resultData.Num2 = Convert.ToDouble(resultData.Stack.Pop());
            resultData.Num1 = Convert.ToDouble(resultData.Stack.Pop());
            resultData.Ans = resultData.Num1* resultData.Num2;
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
            data.Prior = GetPriority(data.Text);
            data.PostList.Add(data.Container);
            data.Container = string.Empty;
            data.PostList.Remove("");
            data.Stack.Push(data.Text);
        }
    }
}
