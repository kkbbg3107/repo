using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.PostfixToNum;

namespace NetCORE_Api.NewPattern
{
    public interface IToPostfix : IAll
    {
        void GetPostfix(ClassObj data);
    }
}
