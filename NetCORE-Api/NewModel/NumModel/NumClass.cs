using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.ClassObj;
using NetCORE_Api.NewPattern;

namespace NetCORE_Api.NewModel.NumModel
{
    public class NumClass : IPostfixToNum
    {
        public void GetNum(ResultData resultData)
        {
            resultData.Stack.Push(resultData.TmpObj);
        }
    }
}
