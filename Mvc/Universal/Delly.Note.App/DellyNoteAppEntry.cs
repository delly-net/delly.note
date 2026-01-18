using DellyNote.Common;
using Jip.WebApi.Service;
using Nuo.Ioc.Modular;
using Nuo.Ioc.Modular.Attribute;

[assembly:Module("delly")]
namespace DellyNote.App;

/// <summary>
/// Delly Note 应用模块入口
/// </summary>
[Depends(
    typeof(JipWebApiServiceEntry),
    typeof(DellyNoteCommonEntry)
    )]
public class DellyNoteAppEntry : BaseModuleEntry
{

}
