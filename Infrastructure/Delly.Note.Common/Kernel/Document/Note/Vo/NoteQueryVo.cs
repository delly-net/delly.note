using System.ComponentModel;

namespace Delly.Note.Common.Kernel.Document.Note.Vo;

/// <summary>
/// 笔记 查询视图输出
/// </summary>
[Description("笔记 查询视图输出")]
public class NoteQueryVo
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
    /// CreationUserId 创建用户Id
    /// </summary>
    [Description("创建用户Id")]
    public string CreationUserId { get; set; } = string.Empty;

    /// <summary>
    /// CreationUserName 创建用户名称
    /// </summary>
    [Description("创建用户名称")]
    public string CreationUserName { get; set; } = string.Empty;

    /// <summary>
    /// LastModificationTime 最后更新时间
    /// </summary>
    [Description("最后更新时间")]
    public DateTime LastModificationTime { get; set; }

    /// <summary>
    /// LastModificationUserId 最后更新用户Id
    /// </summary>
    [Description("最后更新用户Id")]
    public string LastModificationUserId { get; set; } = string.Empty;

    /// <summary>
    /// LastModificationUserName 最后更新用户名称
    /// </summary>
    [Description("最后更新用户名称")]
    public string LastModificationUserName { get; set; } = string.Empty;

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
