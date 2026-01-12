using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Delly.Note.Common.Kernel.Document.Note.Dto;

/// <summary>
/// 笔记 新增 DTO
/// </summary>
[Description("笔记 新增 DTO")]
public class NoteInsertDto
{

    /// <summary>
    /// 标题 Title
    /// </summary>
    [Description("标题")]
    [Required]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 笔记类型 NoteType
    /// </summary>
    [Description("笔记类型")]
    [Required]
    public string NoteType { get; set; } = string.Empty;

    /// <summary>
    /// 编辑内容 EditContent
    /// </summary>
    [Description("编辑内容")]
    public string? EditContent { get; set; }

    /// <summary>
    /// 渲染HTML RenderHtml
    /// </summary>
    [Description("渲染HTML")]
    public string? RenderHtml { get; set; }

}
