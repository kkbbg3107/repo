using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.PostfixToNumOperator
{
    public class PostfixToNumObj
    {
        public double num1 { get; set; }
        public double num2 { get; set; }
        public double ans { get; set; }
        public string answer { get; set; }
        public Stack<string> stack { get; set; }
    }
}
