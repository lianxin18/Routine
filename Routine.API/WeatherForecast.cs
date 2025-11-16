namespace Routine.API
{
    /// <summary>
    /// 天气预报数据模型
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// 日期
        /// </summary>
        /// <example>2024-01-01</example>
        public DateOnly Date { get; set; }

        /// <summary>
        /// 温度（摄氏度）
        /// </summary>
        /// <example>25</example>
        public int TemperatureC { get; set; }

        /// <summary>
        /// 温度（华氏度）
        /// </summary>
        /// <example>77</example>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// 天气摘要描述
        /// </summary>
        /// <example>温暖</example>
        public string? Summary { get; set; }
    }
}
