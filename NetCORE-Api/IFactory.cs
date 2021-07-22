using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCORE_Api
{
    //做按鈕的判斷
    public interface IFactory
    {        
        Calculate PostAll(Calculate cal);
    }
}
 