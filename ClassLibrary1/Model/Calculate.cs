using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    /// <summary>
    /// 控制項物件存取
    /// </summary>
    public class Calculate
    {
        public string Button { get; set; }
        public string Label { get; set; }
        public string TextboxFirst { get; set; }
        public string TextboxResult { get; set; }

        public Calculate(Record r)
        {
            Button = r.Btn;
            Label = r.Lbl;
            TextboxFirst = r.Tbxt1;
            TextboxResult = r.Tbxt2;
        }
    }
}
