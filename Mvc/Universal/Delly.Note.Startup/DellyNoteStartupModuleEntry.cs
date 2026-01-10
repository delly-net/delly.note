using Delly.Note.App;
using Delly.Note.Razor;
using Jip.WebApi.DbLog.TaskJob;
using Jip.WebApi.Kernel.Plug;
using Nuo.Ioc.Modular;
using Nuo.Ioc.Modular.Attribute;

namespace Delly.Note.Startup;

/// <summary>
/// Delly Note启动 模块入口
/// </summary>
public class DellyNoteStartupModuleEntry : BaseModuleEntry
{
    protected override void OnInitialize()
    {
        base.OnInitialize();
        // 加载标准模块
        Depend<JipWebApiDbLogTaskJobEntry>();
        Depend<SupWebApiKernelPlugEntry>();
        // 加载DellyNote特殊模块
        Depend<DellyNoteRazorEntry>();
        Depend<DellyNoteAppEntry>();
    }
}
