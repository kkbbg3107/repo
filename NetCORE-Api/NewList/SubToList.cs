using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCORE_Api.NewPattern;
using NetCORE_Api.ToListServiceData;

namespace NetCORE_Api.NewList
{
    public class SubToList : IToListService
    {
        private Data _data;

        public SubToList(Data data)
        {
            _data = data;
        }

        public void GetList()
        {
            _data.List.Add(_data.Container);
            _data.Container = string.Empty;
            _data.List.Remove("");

            if (_data.List[_data.List.Count - 1] == "(")
            {
                _data.Container += _data.Text;
            }
            else
            {
                _data.List.Add(_data.Text);
            }
        }
    }
}
