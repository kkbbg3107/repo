using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.PostfixToNum;
using NetCORE_Api.Priority;
using NetCORE_Api.ToListServiceData;

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
        private static int Priority(int priority, string c)
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

                        // concat the operands and operator
                        string temp = postfix[i] + op2 + op1;

                        // Push String temp back to stack
                        s.Push(temp);
                    }
                    else
                    {
                        // Push the operand to the stack
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
        private static Boolean IsOperator(string x)
        {
            switch (x)
            {
                case "+":
                case "-":
                case "/":
                case "*":
                    return true;
                default:
                    break;
            }

            return false;
        }

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



                    //var result = (dict.TryGetValue(c, out iobj)) ？ (iobj.GetNum(classobj)) : (classobj.stack.Push(c));

                    if (c.Equals("*") || c.Equals("/") || c.Equals("+") || c.Equals("-"))
                    {
                        var iobj = dict[c];
                        iobj.GetNum();
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

            Use use = new Use();
            Data data = new Data();
            data.list = list;
            data.stack = stack;
            data.container = container;
            data.str = str;

            try
            {
                for (int i = 0; i < infix.Length; i++)
                {
                    var c = infix[i].ToString();
                    data.c = c;

                    var result = use.GetEnum(data);

                    var dict_toList = new Dictionary<int, IToList>()
                    {
                        {1, new leftBrackets(data)},
                        {2, new RightAndStackNotZero(data)},
                        {3, new RightBracketAndStrNotNull(data)},
                        {11, new RightBrackets(data)},
                        {4, new PlusDivMulAndStrNotNull(data)},
                        {5, new PlusDivMul(data)},
                        {6, new SubAllFliter(data)},
                        {7, new SubLeftBrackets(data)},
                        {8, new SubRightBrackets(data)},
                        {9, new SubCountZero(data)},
                        {10, new SubMarks(data)},
                        {0, new NumInput(data)},
                    };


                    var iToList = dict_toList[result];
                    iToList.GetResult();
                }

                if (data.str != string.Empty)
                {
                    data.list.Add(data.str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return data.list;
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
            int priority = 0; // 權重

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
                        int prior = Priority(priority, c); // 賦予優先權

                        if (prior == -1)
                        {
                            if (temp != string.Empty)
                            {
                                postList.Add(temp);
                                temp = string.Empty;
                            }

                            stack.Push(c);
                        }
                        else if (prior == 5)
                        {
                            if (temp != string.Empty)
                            {
                                postList.Add(temp);
                                temp = string.Empty;
                            }

                            if (stack.Count == 0)
                            {
                                stack.Push(c);
                            }
                            else if (stack.Peek() == "(")
                            {
                                // '+' '-' 權重> '('
                                stack.Push(c);
                            }
                            else if (stack.Peek() == "*" || stack.Peek() == "/")
                            {
                                postList.Add(stack.Pop().ToString());
                                i--; // 重新回到這個運算子在run一次
                                recordLen++; // 記數也要加回去
                            }
                            else if (stack.Peek() == "+" || stack.Peek() == "-")
                            {
                                postList.Add(stack.Pop().ToString());
                                i--;
                                recordLen++;
                            }
                        }
                        else if (prior == -100)
                        {
                            if (temp != string.Empty)
                            {
                                postList.Add(temp);
                                temp = string.Empty;
                            }

                            while (stack.Peek() != "(")
                            {
                                // 直到stack裡遇到'('把上面的運算子都pop出來
                                postList.Add(stack.Pop().ToString());
                            }

                            stack.Pop(); // 遇到的'('也要移掉
                        }
                        else if (prior == 9)
                        {
                            // 遇到'*' '/'運算子
                            if (stack.Count == 0)
                            {
                                if (temp != string.Empty)
                                {
                                    postList.Add(temp);
                                    temp = string.Empty;
                                }

                                stack.Push(c);
                            }
                            else if (stack.Peek().ToString() == "*" || stack.Peek().ToString() == "/")
                            {
                                if (temp != string.Empty)
                                {
                                    postList.Add(temp);
                                    temp = string.Empty;
                                }

                                postList.Add(stack.Pop().ToString());
                                stack.Push(c);
                            }
                            else
                            {
                                if (temp != string.Empty)
                                {
                                    postList.Add(temp);
                                    temp = string.Empty;
                                }

                                stack.Push(c);
                            }
                        }
                    }
                    else
                    {
                        temp += c;
                        // postfix += c; 數值直接帶進postfix
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

        public Calculate PostAll(Calculate cal)
        {

            var p = ToListService(cal.Label);
            var postList = ToPostfix(p); // 後序表達式
            var result = PostfixToNum(postList); // 運算結果
            Response data = new Response();
            var postfix = string.Join(",", postList.ToArray());
            var prefix = PostfixToPrefix(postList);

            data.Prefix = prefix;
            data.Formula = cal.Label;
            data.Postfix = postfix;
            data.Result = result;

            cal.TextboxResult = $"PostFix : {data.Postfix}, Formula : {data.Formula}, Prefix : {data.Prefix}, Result : {data.Result}";
            return cal;
        }
    }
}
