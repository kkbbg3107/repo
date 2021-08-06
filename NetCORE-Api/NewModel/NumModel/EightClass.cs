using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.ClassObj;
using NetCORE_Api.NewPattern;

namespace NetCORE_Api.NewModel
{
    public class EightClass : IToPostfix
    {
        public void GetPostfix(ClassObject data)
        {
            data.Container += data.Text;;
        }
    }
}
