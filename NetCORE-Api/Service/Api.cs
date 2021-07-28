using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.InterFace;
using NetCORE_Api.Operator;
using NetCORE_Api.PostfixToNumOperator;
using NetCORE_Api.Priority;

namespace NetCORE_Api.Service
{
    public class Api : IFactory
    {
        /// <summary>
        /// 優先權判定
        /// </summary>
        /// <param name="priority">優先權大小</param>
        /// <param name="c">待分析的數字</param>
        /// <returns>infix字串</returns>
        private static int Priority(string c)
        {
            var dictPriority = new Dictionary<string, IPriority>()
            {
                { ")", new RightMarkPriority()},
                { "+", new AddSubPriority()},
                { "-", new AddSubPriority()},
                { "*", new MulDivPriority()},
                { "/", new MulDivPriority()},
                { "(", new LeftPriority()}
            };

            IPriority _prior = dictPriority[c];
            var result = _prior.GetPriority(c);

            return result;
        }

        /// <summary>
        /// 後序轉前序
        /// </summary>
        /// <param name="postfix">後序表達式</param>
        /// <returns>前序表達式</returns>
        private static string PostfixToPrefix(List<string> postfix)
        {
            Stack s = new Stack();
            string res;
            try
            {
                for (int i = 0; i < postfix.Count; i++)
                {
                    if (IsOperator(postfix[i]))
                    {
                        string op1 = (string)s.Peek();
                        s.Pop();
                        string op2 = (string)s.Peek();
                        s.Pop();

                        string temp = postfix[i] + op2 + op1;

                        s.Push(temp);
                    }
                    else
                    {
                        
                        s.Push(postfix[i] + string.Empty);
                    }
                }

                string ans = string.Empty;
                while (s.Count > 0)
                {
                    ans += s.Pop();
                }

                res = ans;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return res;
        }

        /// <summary>
        /// 判別運算子
        /// </summary>
        /// <param name="x">輸入的數</param>
        /// <returns>運算子回傳true</returns>
        private static bool IsOperator(string x)
        {
            var dictionaryOperator = new Dictionary<string, IBoolenOperator>()
            {
                {"+", new IsPlus()},
                {"-", new IsSub()},
                {"*", new IsMul()},
                {"/", new IsDiv()}
            };

            if (IsBoolOperatorTrue(x))
            {
                IBoolenOperator boolOperator = dictionaryOperator[x];
                boolOperator.IsOperator(x);
            }

            return false;
        }

        /// <summary>
        /// 判斷是否為運算子
        /// </summary>
        /// <param name="x">傳入的值</param>
        /// <returns>為運算子回傳true</returns>
        public static bool IsBoolOperatorTrue(string x)
        {
            return x == "+" || x == "-" || x == "/" || x == "*";
        }

        //private static Dictionary<string, IObject> dictionary;

        /// <summary>
        /// 後序轉運算結果
        /// </summary>
        /// <param name="postfix">後序表達式</param>
        /// <returns>結果數值</returns>
        private static string PostfixToNum(List<string> postfix)
        {
            ClassObj classobj = new ClassObj();
            string answer = string.Empty;
            double num1 = 0;
            double num2 = 0;
            double ans = 0;
            Stack<string> stack = new Stack<string>();

            classobj.stack = stack;
            classobj.ans = ans;
            classobj.num1 = num1;
            classobj.num2 = num2;
            classobj.answer = answer;

            try
            {
                for (int j = 0; j < postfix.Count; j++)
                {
                    string c = postfix[j]; // 可支援轉型

                    var dict = new Dictionary<string, IObject>()
                    {
                        {"+", new PlusClass(classobj)},
                        {"-", new SubClass(classobj)},
                        {"*", new MulClass(classobj)},
                        {"/", new DivClass(classobj)},
                    };

                    if (c.Equals("*") || c.Equals("/") || c.Equals("+") || c.Equals("-"))
                    {
                        var iobj = dict[c];
                        iobj.GetNum(classobj);
                        ;
                    }
                    else
                    {
                        classobj.stack.Push(c);
                    }
                }

                classobj.answer = (string)classobj.stack.Pop();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return classobj.answer;
        }

        /// <summary>
        /// 理解操作排序前先生成列表
        /// </summary>
        /// <param name="infix">計算機輸入的算式</param>
        /// <returns>依照每個符號定義的列表</returns>
        public List<string> ToListService(string infix)
        {
            var str = string.Empty;
            var container = string.Empty;
            List<string> list = new List<string>();
            Stack<string> stack = new Stack<string>();
            try
            {
                for (int i = 0; i < infix.Length; i++)
                {
                    var c = infix[i].ToString();
                    if (c == "(")
                    {
                        list.Add(c);
                    }
                    else if (c == ")")
                    {
                        if (stack.Count != 0) // 負號的右括號
                        {
                            container += stack.Pop();
                            container += str;
                            list.Add(container); // 把負數加到list
                            container = string.Empty; // 清空字串容器
                            str = string.Empty;
                        }
                        else if (str != string.Empty)
                        {
                            list.Add(str);
                            str = string.Empty;
                        }

                        list.Add(c);
                    }
                    else if (c == "+" || c == "*" || c == "/")
                    {
                        if (str != string.Empty)
                        {
                            list.Add(str);
                            str = string.Empty;
                        }

                        list.Add(c);
                    }
                    else if (c == "-") // "減號"&"負號"的判別
                    {
                        if (IsLeftBracketAndCountNotZero(list) && str == string.Empty) // 負數
                        {
                            stack.Push(c);
                        }
                        else if (IsRightBracketAndCountNotZero(list)) // 減號前面右括號時
                        {
                            list.Add(c);
                        }
                        else
                        {
                            list.Add(str);
                            str = string.Empty;
                            list.Add(c);
                        }
                    }
                    else // 數字
                    {
                        str += c;
                    }
                }

                if (str != string.Empty)
                {
                    list.Add(str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return list;
        }

        /// <summary>
        /// 判斷當下是"-"時 集合是否不為零且 集合最後一個元素為左括號
        /// </summary>
        /// <param name="list">需要計算的算式</param>
        /// <returns>是否為符合的算式</returns>
        public static bool IsLeftBracketAndCountNotZero(List<string> list)
        {
            return list.Count != 0 && list[list.Count - 1].ToString() == "(";
        }

        /// <summary>
        /// 判斷當下是"-"時 集合是否不為零且 集合最後一個元素為右括號
        /// </summary>
        /// <param name="list">需要計算的算式</param>
        /// <returns>是否為符合的算式</returns>
        public static bool IsRightBracketAndCountNotZero(List<string> list)
        {
            return list.Count != 0 && list[list.Count - 1].ToString() == ")";
        } 
        /// <summary>
        /// step1 : '(' pusg至stack
        /// step2 : ')':一直pop並將pop出的值放入postfix 直到stack中碰到 '('為止
        /// step3 : 運算元 0~9 直接放進postfix
        /// p.s 運算子有權重之分
        /// 使用堆疊處理 運算子權重比較:( => -1 , +- => 5 , */ => 9  權重大的壓得住小的 => push進stack
        /// </summary>
        /// <param name="infix"></param>
        /// <returns>後序表達式集合</returns>
        private static List<string> ToPostfix(List<string> infix)
        {
            List<string> postList = new List<string>(); // 後序表達示

            Stack<string> stack = new Stack<string>();

            int recordLen = infix.Count; // 紀錄中序長度

            string temp = string.Empty; // 臨時變數 => 為了區分數字>10 和 是否有小數點  一碰到運算子就把前面的數字合併 塞進postfix 

            try
            {
                for (int i = 0; i < infix.Count; i++)
                {
                    var c = infix[i];
                    if (c == "+" || c == "-" || c == "*" || c == "/" || c == "(" || c == ")")
                    {
                        int prior = Priority(c); // 賦予優先權

                        if (temp != string.Empty)
                        {
                            postList.Add(temp);
                            temp = string.Empty;
                        }

                        if (prior == -1)
                        {
                            stack.Push(c);
                        }
                        else if (prior == 5)
                        {
                            if (stack.Count == 0 || stack.Peek() == "(")
                            {
                                stack.Push(c);
                            }
                            else if (stack.Peek() == "*" || stack.Peek() == "/" || stack.Peek() == "+" || stack.Peek() == "-")
                            {
                                postList.Add(stack.Pop().ToString());
                                i--; // 重新回到這個運算子在run一次
                                recordLen++; // 記數也要加回去
                            }
                        }
                        else if (prior == -100)
                        {
                            while (stack.Peek() != "(")
                            {
                                postList.Add(stack.Pop().ToString()); // 直到stack裡遇到'('把上面的運算子都pop出來
                            }

                            stack.Pop(); // 遇到的'('也要移掉
                        }
                        else if (prior == 9)
                        {
                            if (stack.Count == 0) // 遇到'*' '/'運算子
                            {
                                stack.Push(c);
                            }
                            else if (stack.Peek().ToString() == "*" || stack.Peek().ToString() == "/")
                            {
                                postList.Add(stack.Pop().ToString());
                                stack.Push(c);
                            }
                            else
                            {
                                stack.Push(c);
                            }
                        }
                    }
                    else
                    {
                        temp += c;
                    }

                    recordLen--; // 每循環一次 記數-1 

                    if (recordLen == 0)
                    {
                        while (stack.Count != 0)
                        {
                            if (temp != string.Empty)
                            {
                                postList.Add(temp);
                                temp = string.Empty;
                            }

                            postList.Add(stack.Pop().ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return postList;
        }

        /// <summary>
        /// 實作api按鈕
        /// </summary>
        /// <param name="cal">按鈕text = api</param>
        /// <returns>控制項結果</returns>
        public Calculate PostAll(string cal)
        {
            Record.Btn = cal;
            Calculate c = new Calculate();
            c.Label = Record.Lbl;

            var p = ToListService(c.Label);
            var postList = ToPostfix(p); // 後序表達式
            var result = PostfixToNum(postList); // 運算結果
            Response data = new Response();
            var postfix = string.Join(",", postList.ToArray());
            var prefix = PostfixToPrefix(postList);

            data.Prefix = prefix;
            data.Formula = c.Label;
            data.Postfix = postfix;
            data.Result = result;

            c.Button = Record.Btn;
            c.TextboxResult = $"PostFix : {data.Postfix}, Formula : {data.Formula}, Prefix : {data.Prefix}, Result : {data.Result}";
            return c;
        }
    }
}
