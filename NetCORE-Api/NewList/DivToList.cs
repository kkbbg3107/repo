using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.PostfixToNum;
using NetCORE_Api.ToListServiceData;

namespace NetCORE_Api.NewList
{
    public class DivToList : IToListService
    {
        private ClassObj _data;

        public DivToList(ClassObj data)
        {
            _data = data;
        }

        public void GetList()
        {

            _data.PostList.Add(_data.Str);
            _data.Str = string.Empty;
            _data.PostList.Remove("");
            _data.PostList.Add(_data.Text);
        }
    }
}
