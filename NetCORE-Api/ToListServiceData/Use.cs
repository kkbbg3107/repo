using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    public class Use
    {
        // 判斷實作哪個按鈕條件
        public int GetEnum(Data data)
        {
            if (data.Text == "(")
            {
                return 1;
            }

            if (data.Text == ")" && data.Stack.Count != 0)
            {
                return 2;
            }

            if (data.Text == ")" && data.Str != string.Empty)
            {
                return 3;
            }

            if (data.Text == "+" || data.Text == "*" || data.Text == "/" && data.Str != string.Empty)
            {
                return 4;
            }
            
            if (data.Text == "+" || data.Text == "*" || data.Text == "/")
            {
                return 5;
            }

            if ((data.Text == "-" && data.List.Count != 0 && data.List[data.List.Count - 1].ToString() == "(" &&
                data.Str != string.Empty))
            {
                return 6;
            }

            if (data.Text == "-" && data.List.Count != 0 && data.List[data.List.Count - 1].ToString() == "(")
            {
                return 7;
            }

            if (data.Text == "-" && data.List.Count != 0 && data.List[data.List.Count - 1].ToString() == ")")
            {
                return 8;
            }

            if (data.Text == "-" && data.List.Count == 0)
            {
                return 9;
            }

            if (data.Text == "-")
            {
                return 10;
            }

            if (data.Text == ")")
            {
                return 11;
            }

            if (data.Text == "0" || data.Text == "1" || data.Text == "2" || data.Text == "3" || data.Text == "4" || data.Text == "5" ||
                data.Text == "6" || data.Text == "7" || data.Text == "8" || data.Text == "9" || data.Text == ".")
            {
                return 0;
            }

            return 100;
        }
    }
}
