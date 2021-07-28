using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.PostfixToNumOperator;
;

namespace NetCORE_Api.PostfixToNumOperator
{
    public class MulString : IObject
    {
        private PostfixToNumObj _obj;

        public MulString(PostfixToNumObj obj)
        {
            _obj = obj;
        }
        
        
        public void GetNum(string c)
        {
            
            _obj.num1 = Convert.ToDouble(_obj.stack.Pop()); 
            _obj.num2 = Convert.ToDouble(_obj.stack.Pop());

            _obj.ans = _obj.num2 * _obj.num1;
            _obj.stack.Push(_obj.ans.ToString());
        }
    }
}
