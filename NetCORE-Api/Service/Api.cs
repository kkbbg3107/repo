using ClassLibrary1.Model;
using NetCORE_Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.Operator;
using NetCORE_Api.PostfixToNum;
using NetCORE_Api.Priority;
using NetCORE_Api.ToListServiceData;
using NetCORE_Api.ToPostfix;

namespace NetCORE_Api.Service
{
    public class Api : IFactory
    {

        /// <summary>
        /// 優先權判定
        /// </summary>
        /// <param name="priority">優先權大小</param>
        /// <param name="Text">待分析的數字</param>
        /// <returns>infix字串</returns>
        private static int Priority(string Text)
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

            IPriority _prior = dictPriority[Text];
            var result = _prior.GetPriority(Text);

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
            string res = string.Empty;
            string op1 = string.Empty;
            string op2 = string.Empty;
            string temp = string.Empty;
            try
            {
                for (int i = 0; i < postfix.Count; i++)
                {
                    string text = postfix[i];

                    if (IsOperator(postfix[i]))
                    { 
                        op1 = (string)s.Peek();
                        s.Pop();
                        op2 = (string)s.Peek();
                        s.Pop();

                        temp = postfix[i] + op2 + op1;

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
                return true;
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

        /// <summary>
        /// 後序轉運算結果
        /// </summary>
        /// <param name="postfix">後序表達式</param>
        /// <returns>結果數值</returns>
        private static string PostfixToNum(List<string> postfix)
        {
            ClassObj classobj = new ClassObj();
            classobj.Stack = new Stack<string>();
            classobj.Ans = 0;
            classobj.Num1 = 0;
            classobj.Num2 = 0;
            classobj.Answer = string.Empty;
            try
            {
                for (int j = 0; j < postfix.Count; j++)
                {
                    string text = postfix[j]; // 可支援轉型

                    var dict = new Dictionary<string, IObject>()
                    {
                        {"+", new PlusClass(classobj)},
                        {"-", new SubClass(classobj)},
                        {"*", new MulClass(classobj)},
                        {"/", new DivClass(classobj)},
                    };

                    if (IsBoolOperatorTrue(text))
                    {
                        dict[text].GetNum();
                    }
                    else
                    {
                        classobj.Stack.Push(text);
                    }
                }

                classobj.Answer = (string)classobj.Stack.Pop();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return classobj.Answer;
        }

        /// <summary>
        /// 理解操作排序前先生成列表
        /// </summary>
        /// <param name="infix">計算機輸入的算式</param>
        /// <returns>依照每個符號定義的列表</returns>
        public List<string> ToListService(string infix)
        {
            Use use = new Use();
            Data data = new Data();
            data.List = new List<string>();
            data.Stack = new Stack<string>();
            data.Container = string.Empty;
            data.Str = string.Empty;

            try
            {
                for (int i = 0; i < infix.Length; i++)
                {
                    data.Text = infix[i].ToString();

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

                if (data.Str != string.Empty)
                {
                    data.List.Add(data.Str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return data.List;
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
            ToPostfixData data = new ToPostfixData();
            ClassJudge judge = new ClassJudge();
            data.Stack = new Stack<string>();
            data.Temp = string.Empty;  // 臨時變數 => 為了區分數字>10 和 是否有小數點  一碰到運算子就把前面的數字合併 塞進postfix 
            data.PostList = new List<string>(); // 後序表達示
            data.RecordLen = infix.Count; // 紀錄中序長度

            try
            {
                for (data.Times = 0; data.Times < infix.Count; data.Times++)
                {

                    var Text = infix[data.Times];
                    data.Text = Text;
                    if (Text == "+" || Text == "-" || Text == "*" || Text == "/" || Text == "(" || Text == ")")
                    {
                        int prior = Priority(Text); // 賦予優先權
                        data.Prior = prior;

                        if (data.Temp != string.Empty)
                        {
                            data.PostList.Add(data.Temp);
                            data.Temp = string.Empty;
                        }
                        var result = judge.GetToken(data);

                        var dict_ToPotfix = new Dictionary<int, IToPostfix>()
                        {
                            {1, new PriorNegativeOne(data)},
                            {2, new PriorFiveAndCountZeroLeftBrackets(data)},
                            {3, new PriorFiveAndOperator(data)},
                            {4, new PriorHundred(data)},
                            {5, new PriorNineAndCountZero(data)},
                            {6, new PriorNineMulAndDiv(data)},
                            {7, new PriorNine(data)},
                        };

                        var iToPostfix = dict_ToPotfix[result];
                        iToPostfix.GetPostfix();
                    }
                    else
                    {
                        data.Temp += data.Text;
                    }

                    data.RecordLen--; // 每循環一次 記數-1 

                    if (data.RecordLen == 0)
                    {
                        while (data.Stack.Count != 0)
                        {
                            if (data.Temp != string.Empty)
                            {
                                data.PostList.Add(data.Temp);
                                data.Temp = string.Empty;
                            }

                            data.PostList.Add(data.Stack.Pop().ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return data.PostList;
        }

        /// <summary>
        /// 實作api按鈕方法
        /// </summary>
        /// <param name="cal">api按鈕</param>
        /// <returns>前中後序+結果值</returns>
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
