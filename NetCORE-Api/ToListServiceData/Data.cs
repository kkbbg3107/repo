using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    /// <summary>
    /// ToListService方法使用之物件
    /// </summary>
    public class Data
    {
        public string Container { get; set; }
        public List<string> List { get; set; }
        public Stack<string> Stack { get; set; }
        public  string Text { get; set; }
    }
}
