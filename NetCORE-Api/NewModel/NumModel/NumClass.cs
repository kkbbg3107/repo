using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.ClassObj;
using NetCORE_Api.NewPattern;

namespace NetCORE_Api.NewModel.NumModel
{
    public class NumClass : IPostfixToNum, IPrefix
    {
        public void GetNum(ResultData resultData)
        {
            resultData.Stack.Push(resultData.TmpObj);
        }

        public void GetPrefix(PrefixObj prefixObj)
        {
            prefixObj.Stack.Push(prefixObj.text + string.Empty);
        }
    }
}
