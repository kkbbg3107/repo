using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api.ToListServiceData
{
    public class Use
    {
        public int GetEnum(Data data)
        {
            if (data.c == "(")
            {
                return 1;
            }

            if (data.c == ")" && data.stack.Count != 0)
            {
                return 2;
            }

            if (data.c == ")" && data.str != string.Empty)
            {
                return 3;
            }

            if (data.c == ")")
            {
                return 11;
            }

            if (data.c == "+" || data.c == "*" || data.c == "/" && data.str != string.Empty)
            {
                return 4;
            }

            if (data.c == "+" || data.c == "*" || data.c == "/")
            {
                return 5;
            }

            if (data.c == "-" && data.list.Count != 0 && data.list[data.list.Count - 1].ToString() == "(" &&
                data.str != string.Empty)
            {
                return 6;
            }

            if (data.c == "-" && data.list.Count != 0 && data.list[data.list.Count - 1].ToString() == "(")
            {
                return 7;
            }

            if (data.c == "-" && data.list.Count != 0 && data.list[data.list.Count - 1].ToString() == ")")
            {
                return 8;
            }

            if (data.c == "-" && data.list.Count == 0)
            {
                return 9;
            }

            if (data.c == "-")
            {
                return 10;
            }

            if (data.c == "0" || data.c == "1" || data.c == "2" || data.c == "3" || data.c == "4" || data.c == "5" ||
                data.c == "6" || data.c == "7" || data.c == "8" || data.c == "9" || data.c == ".")
            {
                return 0;
            }

            return 100;
        }
    }
}
