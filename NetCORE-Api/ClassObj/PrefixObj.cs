using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ClassObj
{
    /// <summary>
    /// 前序排列使用的物件
    /// </summary>
    public class PrefixObj
    {
        public Stack Stack { get; set; } // 給予前序排列的stack

        public string res { get; set; } // 提供迴圈結束後還在stack內的數的暫存空間

        public string op1 { get; set; } //被操作的數 (被加減乘除)

        public string op2 { get; set; } //操作的數 (加減乘除)

        public string temp { get; set; } // 每一次兩數運算的結果
        
        public string text { get; set; } // 從後序迭代進來的物件
    }
}
