using System.ComponentModel;

namespace Delly.Note.Common.Kernel.Document.Note.Vo;

/// <summary>
/// 笔记 查询视图输出
/// </summary>
[Description("笔记 查询视图输出")]
public class NoteQueryVo
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

}
