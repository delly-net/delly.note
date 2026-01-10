using Delly.Note.Common;
using Nuo.Ioc.Modular;
using Nuo.Ioc.Modular.Attribute;

namespace Delly.Note.Razor;

/// <summary>
/// Razor页 模块入口
/// </summary>
[Depends(typeof(DellyNoteCommonEntry))]
public sealed class DellyNoteRazorEntry : BaseModuleEntry
{

}
