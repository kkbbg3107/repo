using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewModel
{
    public class rightClass : IPrior
    {
        private ClassObj classObj;

        public rightClass(ClassObj post)
        {
            classObj = post;
        }
        public int GetPriority(string c)
        {
            return -100;
        }

        public void GetNum()
        {
        }
    }
}
