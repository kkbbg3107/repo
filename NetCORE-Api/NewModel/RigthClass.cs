﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    public class RightClass : IPrior, IToPostfix
    {
        private ClassObj classObj;

        public RightClass(ClassObj post)
        {
            classObj = post;
        }
        public int GetPriority(string c)
        {
            return -100;
        }

        public void GetPostfix(ClassObj data)
        {
            while (data.Stack.Peek() != "(")
            {
                data.PostList.Add(data.Stack.Pop().ToString());
            }

            data.Stack.Pop();
        }
    }
}
