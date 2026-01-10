using Nuo.Data.General.Attribute;
using Nuo.Data.General.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Delly.Note.Common.Document.Vo;

/// <summary>
/// Markdown 视图输出
/// </summary>
[Description("Markdown 视图输出")]
public class MarkdownNoteVo
{

    /// <summary>
    /// Id 唯一ID
    /// </summary>
    [Description("唯一ID")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// CreationTime 创建时间
    /// </summary>
    [Description("创建时间")]
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// CreationUser 创建用户
    /// </summary>
    [Description("创建用户")]
    public string CreationUser { get; set; } = string.Empty;

    /// <summary>
    /// LastModificationTime 最后更新时间
    /// </summary>
    [Description("最后更新时间")]
    public DateTime LastModificationTime { get; set; }

    /// <summary>
    /// LastModificationUser 最后更新用户
    /// </summary>
    [Description("最后更新用户")]
    public string LastModificationUser { get; set; } = string.Empty;

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; } = string.Empty;

}
