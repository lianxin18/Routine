using Microsoft.AspNetCore.Mvc;
using Routine.API.Unility.SwaggerExt;

namespace Routine.API.Controllers
{
    /// <summary>
    /// 天气预报 API 控制器
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = ApiVersionInfo.V2)]
    public class WeatherForecastV2Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// 获取天气预报列表
        /// </summary>
        /// <returns>返回未来5天的天气预报数组</returns>
        /// <response code="200">成功获取天气预报数据</response>
        [HttpGet(Name = "GetWeatherForecastV2")]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), 200)]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// 根据 ID 获取特定天气预报
        /// </summary>
        /// <param name="id">天气预报的唯一标识符</param>
        /// <returns>返回指定的天气预报</returns>
        /// <response code="200">成功找到对应的天气预报</response>
        /// <response code="404">未找到对应的天气预报</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(WeatherForecast), 200)]
        [ProducesResponseType(404)]
        public ActionResult<WeatherForecast> GetById(int id)
        {
            // 模拟数据查找逻辑
            if (id < 1 || id > 5)
                return NotFound();

            return new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(id)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }
    }
}
