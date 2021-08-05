using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    /// <summary>
    /// 加法實作方法
    /// </summary>
    public class NewSub : IPrior, IPostfixToNum, IOperator, IToPostfix, IToListService
    {
        /// <summary>
        /// 建立外部物件屬性
        /// </summary>
        private ClassObj classObj;

        /// <summary>
        /// 建立建構子
        /// </summary>
        /// <param name="post">帶入外部物件</param>
        public NewSub(ClassObj post)
        {
            classObj = post;
        }

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

        /// <summary>
        /// 取得數值
        /// </summary>
        public void GetNum()
        {
            classObj.Num2 = Convert.ToDouble(classObj.Stack.Pop());
            classObj.Num1 = Convert.ToDouble(classObj.Stack.Pop());
            classObj.Ans = classObj.Num1 - classObj.Num2;
            classObj.Stack.Push((classObj.Ans.ToString()));
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

        /// <summary>
        /// 取得中序集合
        /// </summary>
        public void GetList()
        {
            classObj.PostList.Add(classObj.Str);
            classObj.Str = string.Empty;
            classObj.PostList.Remove("");

            if (classObj.PostList[classObj.PostList.Count - 1] == "(") // 負號
            {
                classObj.Str += classObj.Text;
            }
            else
            {
                classObj.PostList.Add(classObj.Text); // 減號
            }
        }
    }
}
