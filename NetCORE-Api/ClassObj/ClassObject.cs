using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ClassObj
{
    /// <summary>
    /// 建立物件給 APiService的 IsOperator方法使用
    /// </summary>
    public class ClassObject
    {
        public  Stack<string> Stack { get; set; } // 後序表達式使用的stack
        public List<string> PostList { get; set; } // 後序表達式的集合
        public int Prior { get; set; } // 優先權大小
        public string Text { get; set; } //按鈕文字
        public string Str { get; set; } // stack頂端的值
        public  List<string> List { get; set; } // 中序表達式的集合
        public int Times { get; set; } //遍立後序的回圈次數
        public string Container { get; set; } // 提供非功能符號的暫存

    }
}
