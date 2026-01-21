using DellyNote.Razor.Extension;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DellyNote.Razor.Model;

/// <summary>
/// 基础通用
/// </summary>
public abstract class BaseGenericPageModel : PageModel
{
    /// <summary>
    /// 语言
    /// </summary>
    public string Language { get; private set; } = string.Empty;

    /// <summary>
    /// 交互信息
    /// </summary>
    public ISession Session => HttpContext.Session;
}