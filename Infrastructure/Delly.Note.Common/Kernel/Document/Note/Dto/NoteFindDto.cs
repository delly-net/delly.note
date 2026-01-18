using System.ComponentModel;

namespace DellyNote.Common.Kernel.Document.Note.Dto;

/// <summary>
/// 笔记 查找输入
/// </summary>
[Description("笔记 查找输入")]
public class NoteFindDto
{

    /// <summary>
    /// 标题 Title
    /// </summary>
    [Description("标题")]
    public string? Title { get; set; }

    /// <summary>
    /// 笔记类型 NoteType
    /// </summary>
    [Description("笔记类型")]
    public string? NoteType { get; set; }

}
