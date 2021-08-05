using System;
using System.Collections;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.RenderTree;
using NetCORE_Api.NewModel;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;
using NetCORE_Api.Service;

namespace NetCORE_Api
{
    public class Model
    {
        /// <summary>
        /// 公用屬性
        /// </summary>
        public static ClassObj classobj = new ClassObj();

        /// <summary>
        /// 靜態字典
        /// </summary>
        public static Dictionary<string, IAll> dict = new Dictionary<string, IAll>()
        {
            {"+", new NewPlus(classobj)},
            {"-", new NewSub(classobj)},
            {"*", new NewMulti(classobj)},
            {"/", new NewDiv(classobj)},
            {"(", new LeftClass(classobj)},
            {")", new RightClass(classobj)},

        };

        /// <summary>
        /// 優先權判定
        /// </summary>
        /// <param name="priority">優先權大小</param>
        /// <param name="Text">待分析的數字</param>
        /// <returns>infix字串</returns>
        public int Priority(string Text)
        {
      
            var result = 0;
            IAll p = dict[Text];
            if (p is IPrior prior)
            {
                result = prior.Priority;
            }

            return result;
        }

        /// <summary>
        /// 後序轉前序
        /// </summary>
        /// <param name="postfix">後序表達式</param>
        /// <returns>前序表達式</returns>
        public string PostfixToPrefix(List<string> postfix)
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
                    
                    if (!IsOperator(postfix[i]))
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
        public static bool IsOperator(string x)
        {
           
            if (IsBoolOperatorTrue(x))
            {
                IAll boolOperator = dict[x];
                if (boolOperator is IOperator opera)
                {
                    opera.IsOperator();
                }
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
        /// 判斷是否為以下字串
        /// </summary>
        /// <param name="x">傳入的值</param>
        /// <returns>為運算子回傳true</returns>
        public static bool IsBoolTrue(string x)
        {
            return x == "+" || x == "-" || x == "/" || x == "*" || x == "(" || x == ")";
        }

        /// <summary>
        /// 後序轉運算結果
        /// </summary>
        /// <param name="postfix">後序表達式</param>
        /// <returns>結果數值</returns>
        public string PostfixToNum(List<string> postfix)
        {
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

                    if (IsBoolOperatorTrue(text))
                    {
                        IAll postNum = dict[text];
                        if (postNum is IPostfixToNum postnum)
                        {
                            postnum.GetNum();
                        }
                    }
                    
                    if (!IsBoolOperatorTrue(text))
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
        public List<string> ToListService(string infix) // 切分成字元集合
        {

            classobj.PostList = new List<string>();
            classobj.Stack = new Stack<string>();
            classobj.Str = string.Empty;

            try
            {
                for (int i = 0; i < infix.Length; i++)
                {
                    classobj.Text = infix[i].ToString();
                    if (IsBoolTrue(classobj.Text))
                    {
                        IAll ListService = dict[classobj.Text];
                        if (ListService is IToListService toListService)
                        {
                            toListService.GetList();
                        }
                    }
                    
                    if (!IsBoolTrue(classobj.Text))
                    {
                        classobj.Str += classobj.Text;
                    }
                }

                if (classobj.Str != string.Empty)
                {
                    classobj.PostList.Add(classobj.Str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return classobj.PostList;
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
        public List<string> ToPostfix(List<string> infix) // 到這邊在做字元重組 與 運算
        {
            ClassObj data = new ClassObj();
            data.Stack = new Stack<string>();
            data.PostList = new List<string>(); // 後序表達示
            data.Str = string.Empty;
            var str = data.Str;

            try
            {
                for (int i = 0; i < infix.Count; i++)
                {
                    data.Stack.TryPeek(out str);
                    data.Str = str;
                    data.Text = infix[i];

                    if (IsBoolTrue(data.Text))
                    {
                        IAll toPostfix = dict[data.Text];
                        if (toPostfix is IToPostfix postfix)
                        {
                            postfix.GetPostfix(data);
                        }
                    }
                    
                    if (!IsBoolTrue(data.Text))
                    {
                        data.PostList.Add(data.Text);
                    }
                }

                while (data.Stack.Count != 0)
                {
                   data.PostList.Add(data.Stack.Pop());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            var res = data.PostList.Where(x => x != null).Select(x => x).ToList();
            return res;
        }
    }
}
