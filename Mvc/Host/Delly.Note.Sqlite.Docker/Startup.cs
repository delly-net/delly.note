using Delly.Note.Startup;
using Microsoft.AspNetCore.Builder;
using Nuo.Data.Sqlite;
using Nuo.Ioc;
using Nuo.Ioc.Modular.Extension;

namespace Delly.Note.Sqlite.Docker;

/// <summary>
/// 通用启动
/// </summary>
public class Startup : DellyNoteStartup
{

    /// <summary>
    /// 加载构造器配置
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfigureBuilder(WebApplicationBuilder builder)
    {
        // 模块加载
        IocUtils.Factory.DependFactory.Include(typeof(SqliteProvider).Assembly);
        base.OnConfigureBuilder(builder);
    }

}
