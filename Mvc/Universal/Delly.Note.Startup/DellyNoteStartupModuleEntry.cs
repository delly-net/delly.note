using DellyNote.App;
using DellyNote.Razor;
using Jip.WebApi.DbLog.TaskJob;
using Jip.WebApi.Kernel.Plug;
using Nuo.Ioc.Modular;
using Nuo.Ioc.Modular.Attribute;

namespace DellyNote.Startup;

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
