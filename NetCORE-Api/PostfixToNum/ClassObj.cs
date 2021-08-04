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
        public string Answer { get; set; }
        public  double Num1 { get; set; }
        public  double Num2 { get; set; }
        public  double Ans { get; set; }
        public  Stack<string> Stack { get; set; }
        public List<string> PostList { get; set; }
        public int Prior { get; set; }
        public string Text { get; set; }
        public string Str { get; set; }


    }
}
