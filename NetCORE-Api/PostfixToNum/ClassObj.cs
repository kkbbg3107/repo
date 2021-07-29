using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.PostfixToNum
{
    /// <summary>
    /// 建立物件給 APiService的 IsOperator方法使用
    /// </summary>
    public class ClassObj
    {
        public string answer { get; set; }
        public  double num1 { get; set; }
        public  double num2 { get; set; }
        public  double ans { get; set; }
        public  Stack<string>? stack { get; set; }
    }
}
