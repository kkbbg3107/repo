using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.PostfixToNumOperator
{
    public class SubClass : IObject
    {

        private ClassObj _obj;

        public SubClass(ClassObj obj)
        {
            _obj = obj;
        }


        public void GetNum(ClassObj Obj)
        {

            Obj.num1 = Convert.ToDouble(Obj.stack.Pop());
            Obj.num2 = Convert.ToDouble(Obj.stack.Pop());

            Obj.ans = Obj.num2 - Obj.num1;
            Obj.stack.Push(Obj.ans.ToString());
        }
    }
}
