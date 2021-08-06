using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ClassObj
{
    public class ResultData
    {
        /// <summary>
        /// 完整數值
        /// </summary>
        public string Answer { get; set; }
        
        /// <summary>
        /// 第一個運算元組
        /// </summary>
        public double Num1 { get; set; }

        /// <summary>
        /// 第二個運算元組
        /// </summary>
        public double Num2 { get; set; }

        /// <summary>
        /// 兩數組相加之值
        /// </summary>
        public double Ans { get; set; }

        /// <summary>
        /// 排序使用stack
        /// </summary>
        public Stack<string> Stack { get; set; }

        /// <summary>
        /// 傳進GetNum方法的參數
        /// </summary>
        public string TmpObj { get; set; }
    }
}
