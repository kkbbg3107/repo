using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text;
using ClassLibrary1.Model;
using NetCORE_Api;
using NetCORE_Api.Service;
using NetCORE_Api.Service.Nums;

namespace NetCORE_Api.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        /// <summary>
        /// logger提示欄位
        /// </summary>
        private readonly ILogger<CalculateController> _logger;

        /// <summary>
        /// 建立私有欄位
        /// </summary>
        private  IFactory _all;

        /// <summary>
        /// 建立相依
        /// </summary>
        /// <param name="logger">檢查api輸入正確性</param>
        public CalculateController(IFactory all,ILogger<CalculateController> logger)
        {
            this._all = all;
            this._logger = logger;
        }

        /// <summary>
        /// PostApi 計算邏輯
        /// </summary>
        /// <param name="cal">控制項物件</param>
        /// <returns>控制項物件</returns>
        [HttpPost("PostAll")]
        public Calculate PostCal([FromBody] Calculate cal)
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"CalculateController的PostSquare方法被呼叫,傳入參數為{cal}");

            _logger.LogWarning(2001, inform.ToString());

            // 建立字典讀取指定按紐實作
            Dictionary<string, IFactory> d = new Dictionary<string, IFactory>()
            {
                {"api", new Api()},
                {"Back", new Back()},
                {"C", new Clear()},
                {".", new Dot()},
                {"+", new Plus()},
                {"-", new Sub()},
                {"*", new Multi()},
                {"/", new Div()},
                {"=", new Equal()},
                {"+/-", new Negative()},
                {"(", new LeftMark()},
                {")", new RightMark()},
                {"√", new SquareRoot()},
                {"0", new Zero()},
                {"1", new One()},
                {"2", new Second()},
                {"3", new Three()},
                {"4", new Four()},
                {"5", new Five()},
                {"6", new Six()},
                {"7", new Seven()},
                {"8", new Eight()},
                {"9", new Nine()},
            };

            // 依賴助入服務
            _all =  d[cal.Button];
            var result = _all.PostAll(cal);

            return result;
        }
    };
}
