using Jip.Kernel.Common;
using Jip.WebApi.App;
using Nuo.Ioc.Modular;
using Nuo.Ioc.Modular.Attribute;

namespace Delly.Note.Common;

/// <summary>
/// Yetmee通用 模块入口
/// </summary>
[Depends(
    typeof(JipWebApiAppEntry),
    typeof(JipKernelCommonEntry)
    )]
public sealed class DellyNoteCommonEntry : BaseModuleEntry
{

}
