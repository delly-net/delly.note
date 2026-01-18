using Microsoft.Extensions.DependencyInjection;
using Nuo.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Nuo.Ioc.Modular.Extension;
using Jip.WebApi.Service.Startup;

namespace DellyNote.Startup;

/// <summary>
/// Yetmee Mvc 启动器
/// </summary>
public class DellyNoteStartup: BaseGenericWebApiStartup
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfigureBuilder(WebApplicationBuilder builder)
    {
        // 模块加载
        IocUtils.Factory.DependFactory.Include<DellyNoteStartupModuleEntry>();
        base.OnConfigureBuilder(builder);
    }
}
