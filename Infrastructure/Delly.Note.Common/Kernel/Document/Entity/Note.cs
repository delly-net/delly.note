using DellyNote.Common.Kernel.Document.Note.Dto;
using DellyNote.Common.Kernel.Document.Note.Vo;
using Jip.Common.Data.Attribute;
using Jip.Common.Data.Entity.GuidEntity;
using Nuo.Data.General.Attribute;
using Nuo.Data.General.Enum;
using Nuo.Mapper.Ioc.Attribute;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DellyNote.Common.Kernel.Document.Entity;

/// <summary>
/// 笔记
/// </summary>
[JipTable]
[Description("笔记")]
[MapFrom(typeof(NoteInsertDto))]
[MapFrom(typeof(NoteUpdateDto))]
[MapTo(typeof(NoteVo))]
[MapTo(typeof(NoteQueryVo))]
public class Note : BaseModificationGuidEntity
{

    /// <summary>
    /// 标题 Title
    /// </summary>
    [Column]
    [StringLength(200)]
    [Description("标题")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 笔记类型 NoteType
    /// </summary>
    [Column]
    [StringLength(20)]
    [Description("笔记类型")]
    public string NoteType { get; set; } = string.Empty;

    /// <summary>
    /// 编辑内容 EditContent
    /// </summary>
    [Column]
    [ColumnType(DbColumnType.TEXT)]
    [Description("编辑内容")]
    public string EditContent { get; set; } = string.Empty;

    /// <summary>
    /// 渲染HTML RenderHtml
    /// </summary>
    [Column]
    [ColumnType(DbColumnType.TEXT)]
    [Description("渲染HTML")]
    public string RenderHtml { get; set; } = string.Empty;

}
