using Jip.Common.Data.Attribute;
using Jip.Common.Data.Entity.GuidEntity;
using Nuo.Data.General.Attribute;
using Nuo.Data.General.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delly.Note.Common.Document.Entity;

/// <summary>
/// Markdown笔记
/// </summary>
[JipTable]
[Description("Markdown笔记")]
public sealed class MarkdownNote : BaseModificationGuidEntity
{
    /// <summary>
    /// 标题
    /// </summary>
    [Column]
    [ColumnIndex]
    [StringLength(200)]
    [Description("标题")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 内容
    /// </summary>
    [Column]
    [ColumnType(DbColumnType.TEXT)]
    [Description("内容")]
    public string Content { get; set; } = string.Empty;
}
