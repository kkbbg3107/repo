using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    /// <summary>
    /// 右括號實作方法
    /// </summary>
    public class RightClass : IPrior, IToPostfix, IToListService
    {
        /// <summary>
        /// 建立屬性
        /// </summary>
        private ClassObj classObj;

        /// <summary>
        /// 建立建構子
        /// </summary>
        /// <param name="post">帶入的物件</param>
        public RightClass(ClassObj post)
        {
            classObj = post;
        }

        /// <summary>
        /// 優先權私有欄位
        /// </summary>
        private int _priority;

        /// <summary>
        /// 封裝好優先權
        /// </summary>
        public int Priority
        {
            get { return _priority; }
            set { _priority = -100; }
        }

        /// <summary>
        /// 取得後序表達式
        /// </summary>
        /// <param name="data">帶入的物件</param>
        public void GetPostfix(ClassObj data)
        {
            while (data.Stack.Peek() != "(")
            {
                data.PostList.Add(data.Stack.Pop().ToString());
            }

            data.Stack.Pop();
        }

        /// <summary>
        /// 取得中序集合
        /// </summary>
        public void GetList()
        {
            classObj.PostList.Add(classObj.Str);
            classObj.Str = string.Empty;
            classObj.PostList.Remove("");
            classObj.PostList.Add(classObj.Text);
        }
    }
}
