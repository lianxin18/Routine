
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Routine.API.Unility.SwaggerExt;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// 添加 Swagger 服务
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    #region 注释
    string basePath = AppContext.BaseDirectory;
    string xmlPath = Path.Combine(basePath, "Routine.API.xml"); 
    options.IncludeXmlComments(xmlPath);
    #endregion

    #region 多版本控制
    var versions = new[] { ApiVersionInfo.V1, ApiVersionInfo.V2 };

    foreach (var version in versions)
    {
        options.SwaggerDoc(version, new OpenApiInfo()
        {
            Title = $"{version}：这里是Core Webapi9",
            Version = version,
            Description = $"Core Webapi 9 {version} 版本"
            
        });
    }
    #endregion
});


var app = builder.Build();

// 配置 HTTP 请求管道
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Routine.API v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "Routine.API v2");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
