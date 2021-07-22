using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;
using NetCORE_Api.interFace;
using WebApi;
using NetCORE_Api.Texts;
namespace NetCORE_Api
{
    public class SimpleFactory : IFactory
    {
        //private readonly IFactory _factory;
        //public SimpleFactory(IFactory factory)
        //{
        //    this._factory = factory;
        //}

        /// <summary>
        /// 找出當下的按鈕
        /// </summary>
        /// <param name="butonnType"></param>
        //Calculate ITest.Get(string buttonType)
        //{
        //Calculate c = new Calculate();
        //bool IsNumber = double.TryParse(buttonType, out var num);
        //if (IsNumber)
        //{

        //}
        //if( c is IFactory)
        //{

        //}
        //c.Button = buttonType;
        //var result = _factory.PostAll(c);
        //return result;
        //}

        public Calculate PostAll(Calculate cal)
        {
            if (cal.Button == "api")
            {
                var api = new Api();
                api.PostAll(cal);
                return cal;
            }
            if (cal.Button == "C")
            {
                var clear = new Clear();
                clear.PostAll(cal);
                return cal;
            }
            if (cal.Button == "√")
            {
                var squareRoot = new SquareRoot();
                squareRoot.PostAll(cal);
                return cal;
            }
            if (cal.Button == "+/-")
            {
                var negative = new Negative();
                negative.PostAll(cal);
                return cal;
            }
            if (cal.Button == "+" || cal.Button == "-" || cal.Button == "*" || cal.Button == "/")
            {
                var operator1 = new Operator();
                operator1.PostAll(cal);
                return cal;
            }
            if (cal.Button == "Back")
            {
                var back = new Back();
                back.PostAll(cal);
                return cal;
            }
            if (cal.Button == "(")
            {
                var left = new LeftMark();
                left.PostAll(cal);
                return cal;
            }
            if (cal.Button == ")")
            {
                var right = new RightMark();
                right.PostAll(cal);
                return cal;
            }
            if (cal.Button == "=")
            {
                var equal = new Equal();
                equal.PostAll(cal);
                return cal;
            }
            if (cal.Button == ".")
            {
                var dot = new Dot();
                dot.PostAll(cal);
                return cal;
            }
            else
            {
                Num num = new Num();
                num.PostAll(cal);
                return cal;
            }
        }
    }
}
