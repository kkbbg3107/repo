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
        private IFactory _all;

        private IReadOnlyDictionary<string, IFactory> _dictionary;
        /// <summary>
        /// 建立相依
        /// </summary>
        /// <param name="logger">檢查api輸入正確性</param>
        public CalculateController(IReadOnlyDictionary<string, IFactory> dictionary, ILogger<CalculateController> logger)
        {
            this._dictionary = dictionary;
            this._logger = logger;
        }

        /// <summary>
        /// PostApi 計算邏輯
        /// </summary>
        /// <param name="cal">控制項物件</param>
        /// <returns>控制項物件</returns>
        [HttpPost("PostAll")]
        public Calculate PostCal([FromBody] string calButton)
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"CalculateController的PostSquare方法被呼叫,傳入參數為{calButton}");

            _logger.LogWarning(2001, inform.ToString());

            // 依賴注入服務
            _all = _dictionary[calButton];
            var result = _all.PostAll(calButton);

            return result;
        }
    }
}