using System;
using System.Collections;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.ClassObj;
using NetCORE_Api.NewModel;
using NetCORE_Api.NewModel.NumModel;
using NetCORE_Api.NewPattern;
using NetCORE_Api.Service;

namespace NetCORE_Api
{
    public class Model
    {
        /// <summary>
        /// 靜態字典
        /// </summary>
        public static Dictionary<string, IAll> dict_button = new Dictionary<string, IAll>()
        {
            {"%", new ModClass()},
            {"+", new NewPlus()},
            {"-", new NewSub()},
            {"*", new NewMulti()},
            {"/", new NewDiv()},
            {"(", new LeftClass()},
            {")", new RightClass()},
            {"0", new ZeroClass()},
            {"1", new OneClass()},
            {"2", new TwoClass()},
            {"3", new ThreeClass()},
            {"4", new FourClass()},
            {"5", new FiveClass()},
            {"6", new SixClass()},
            {"7", new SevenClass()},
            {"8", new EightClass()},
            {"9", new NineClass()},
            {".", new DotClass()},
            {"X", new NumClass()},
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
            IAll p = dict_button[Text];
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
            PrefixObj prefixObj = new PrefixObj();
            prefixObj.Stack = new Stack();
            prefixObj.res = string.Empty;
            prefixObj.op1 = string.Empty;
            prefixObj.op2 = string.Empty;
            prefixObj.temp = string.Empty;

            try
            {
                for (int i = 0; i < postfix.Count; i++)
                {
                    prefixObj.text = postfix[i];
                    NumObj numObj = new NumObj(postfix[i]);
                    IAll prefix = dict_button[numObj.Key];
                    if (prefix is IPrefix getPrefix)
                    {
                        getPrefix.GetPrefix(prefixObj);
                    }
                }

                string ans = string.Empty;
                while (prefixObj.Stack.Count > 0)
                {
                    ans += prefixObj.Stack.Pop();
                }

                prefixObj.res = ans;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return prefixObj.res;
        }

        /// <summary>
        /// 後序轉運算結果
        /// </summary>
        /// <param name="postfix">後序表達式</param>
        /// <returns>結果數值</returns>
        public string PostfixToNum(List<string> postfix)
        {
            ResultData resultData = new ResultData();
            resultData.Stack = new Stack<string>();
            resultData.Ans = 0;
            resultData.Num1 = 0;
            resultData.Num2 = 0;
            resultData.Answer = string.Empty;

            try
            {
                for (int j = 0; j < postfix.Count; j++)
                {
                    string text = postfix[j]; // 可支援轉型
                    resultData.TmpObj = text;
                    NumObj numObj = new NumObj(text);

                    IAll postNum = dict_button[numObj.Key];
                    if (postNum is IPostfixToNum postnum)
                    {
                        postnum.GetNum(resultData);
                    }
                }

                resultData.Answer = (string)resultData.Stack.Pop();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return resultData.Answer;
        }

        /// <summary>
        /// step1 : '(' push至stack
        /// step2 : ')':一直pop並將pop出的值放入postfix 直到stack中碰到 '('為止
        /// step3 : 運算元 0~9 直接放進postfix
        /// p.s 運算子有權重之分
        /// 使用堆疊處理 運算子權重比較:( => -1 , +- => 5 , */ => 9  權重大的壓得住小的 => push進stack
        /// </summary>
        /// <param name="infix"></param>
        /// <returns>後序表達式集合</returns>
        public List<string> ToPostfix(string infix) // 到這邊在做字元重組 與 運算
        {
            ClassObject data = new ClassObject();
            data.Stack = new Stack<string>();
            data.List = new List<string>(); //中序的集合
            data.PostList = new List<string>(); // 後序表達示
            
            var str = string.Empty;
            data.Container = string.Empty;
            data.Times = 0;
            try
            {
                // 字元集合完成
                for (int i = 0; i < infix.Length; i++)
                {
                    data.Text = infix[i].ToString();

                    data.List.Add(data.Text);
                }

                // 產生後序表達式
                for (data.Times = 0; data.Times < data.List.Count; data.Times++)
                {
                    data.Stack.TryPeek(out str);
                    data.Str = str;
                    data.Text = data.List[data.Times];

                    IAll toPostfix = dict_button[data.Text];
                    if (toPostfix is IToPostfix postfix)
                    {
                        postfix.GetPostfix(data);
                    }
                }

                data.PostList.Add(data.Container);
                data.Container = string.Empty;
                data.PostList.Remove("");
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
