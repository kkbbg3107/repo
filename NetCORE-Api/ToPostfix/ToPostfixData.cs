using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToPostfix
{
    /// <summary>
    /// 外部物件 給ToPostfix方法使用
    /// </summary>
    public class ToPostfixData
    {
        public List<string> PostList { get; set; }
        public Stack<string> Stack { get; set; }
        public int RecordLen { get; set; }
        public string Temp { get; set; }
        public string Text { get; set; }
        public int Prior { get; set; }
        public int Times { get; set; }
    }
}
