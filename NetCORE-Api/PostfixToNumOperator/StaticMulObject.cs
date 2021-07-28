using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.PostfixToNumOperator;


namespace NetCORE_Api.PostfixToNumOperator
{
    public class StaticMulObject
    {
        public MulString ObjM { get; set; }

        public DivString ObjD { get; set; }

        public SubString ObjS { get; set; }

        public PlusString ObjP { get; set; }
    }
}
