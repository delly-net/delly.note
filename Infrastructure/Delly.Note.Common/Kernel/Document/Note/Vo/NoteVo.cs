using System.ComponentModel;

namespace Delly.Note.Common.Kernel.Document.Note.Vo;

/// <summary>
/// 笔记 视图输出
/// </summary>
[Description("笔记 视图输出")]
public class NoteVo
{

    /// <summary>
    /// 标题 Title
    /// </summary>
    [Description("标题")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 笔记类型 NoteType
    /// </summary>
    [Description("笔记类型")]
    public string NoteType { get; set; } = string.Empty;

    /// <summary>
    /// 编辑内容 EditContent
    /// </summary>
    [Description("编辑内容")]
    public string EditContent { get; set; } = string.Empty;

    /// <summary>
    /// 渲染HTML RenderHtml
    /// </summary>
    [Description("渲染HTML")]
    public string RenderHtml { get; set; } = string.Empty;

}
