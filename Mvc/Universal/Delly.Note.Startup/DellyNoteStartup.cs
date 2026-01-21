using Jip.WebApi.Service.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Nuo.Ioc;
using Nuo.Ioc.Modular.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.Startup;

/// <summary>
/// Yetmee Mvc 启动器
/// </summary>
public class DellyNoteStartup: BaseGenericWebApiStartup
{
    /// <summary>
    /// 配置构建器
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfigureBuilder(WebApplicationBuilder builder)
    {
        // 模块加载
        IocUtils.Factory.DependFactory.Include<DellyNoteStartupModuleEntry>();
        base.OnConfigureBuilder(builder);
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    /// <param name="services"></param>
    protected override void OnConfigureServices(IServiceCollection services)
    {
        base.OnConfigureServices(services);
        // 添加Session
        services.AddSession(options => {
            // 配置Session过期时间（示例：30分钟）
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            // 设置Session Cookie的名称（可选）
            options.Cookie.Name = "Delly-Session";
            // 设置Cookie为HttpOnly，提高安全性
            options.Cookie.HttpOnly = true;
            // 生产环境建议设为SameSiteMode.Strict
            options.Cookie.SameSite = SameSiteMode.Lax;
            // 生产环境建议设为Secure（仅HTTPS）
            options.Cookie.SecurePolicy = CookieSecurePolicy.None; // 开发环境用None，生产改Always
        });
    }

    /// <summary>
    /// 配置应用
    /// </summary>
    /// <param name="app"></param>
    protected override void OnConfigureApplication(WebApplication app)
    {
        base.OnConfigureApplication(app);
        // 使用Session
        app.UseSession();
    }
}
