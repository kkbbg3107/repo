﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    public class LeftClass : IPrior
    {
        private ClassObj classObj;

        public LeftClass(ClassObj post)
        {
            classObj = post;
        }
        public int GetPriority(string c)
        {
            return -1;
        }

        public void GetNum()
        {
        }

        public bool IsOperator()
        {
            throw new NotImplementedException();
        }
    }
}
