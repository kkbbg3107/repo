using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.PostfixToNumOperator;
;

namespace NetCORE_Api.PostfixToNumOperator
{
    public class MulClass : IObject
    {
        private ClassObj _obj;

        public MulClass(ClassObj obj)
        {
            _obj = obj;
        }
        
        
        public void GetNum(ClassObj Obj)
        {

            Obj.num1 = Convert.ToDouble(Obj.stack.Pop());
            Obj.num2 = Convert.ToDouble(Obj.stack.Pop());

            Obj.ans = Obj.num2 * Obj.num1;
            Obj.stack.Push(Obj.ans.ToString());
        }
    }
}
