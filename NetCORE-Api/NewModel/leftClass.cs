using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    public class LeftClass : IPrior, IToPostfix, IToListService
    {
        private ClassObj classObj;

        public LeftClass(ClassObj post)
        {
            classObj = post;
        }

        private int _priority;
        public int Priority
        {
            get { return _priority; }
            set { _priority = -1; }
        }

        public int GetPriority(string c)
        {
            return -1;
        }

        public void GetPostfix(ClassObj data)
        {
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
