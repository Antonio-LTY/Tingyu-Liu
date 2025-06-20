// 配置依赖注入（MVC、数据库上下文）
// 配置数据库（Sqlite）
// 配置 HTTP 请求管道（异常处理、HSTS、HTTPS、路由、授权、静态资源）
// 启动应用

using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;

//创建一个 Web 应用的构建器对象。CreateBuilder 方法会初始化应用的配置、日志、依赖注入等基础设施
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//向依赖注入容器注册 MVC 控制器和视图服务。这使得你的应用支持 MVC 模式（即支持控制器和视图）。
builder.Services.AddControllersWithViews();

// 注册 ApplicationDbContext，使用 Sqlite
builder.Services.AddDbContext<LibraryManagement.Data.ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


//根据前面配置，构建 Web 应用实例
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
