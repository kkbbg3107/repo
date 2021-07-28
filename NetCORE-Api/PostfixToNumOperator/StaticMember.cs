using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.PostfixToNumOperator
{
    /// <summary>
    /// 提供給 API.cs的靜態類別成員
    /// </summary>
    public static class StaticMember
    {
        public static string answer { get; set; }

        public static Stack<string> stack { get; set; }

        public  static  double num1 { get; set; }

        public  static  double num2 { get; set; }

        public  static  double ans { get; set; }
    }
}
