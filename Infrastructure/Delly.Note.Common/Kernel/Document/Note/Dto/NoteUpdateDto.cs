using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DellyNote.Common.Kernel.Document.Note.Dto;

/// <summary>
/// 笔记 更新 DTO
/// </summary>
[Description("笔记 更新 DTO")]
public class NoteUpdateDto
{

    /// <summary>
    /// Id
    /// </summary>
    [Description("Id")]
    [Required]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 标题 Title
    /// </summary>
    [Description("标题")]
    public string? Title { get; set; }

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
