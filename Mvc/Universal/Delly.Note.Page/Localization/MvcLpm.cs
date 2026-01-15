using System.Diagnostics.CodeAnalysis;
using Nuo.Localization.Modular;
using Nuo.Localization.Modular.Attribute;
using Nuo.Ref.Attribute;

namespace Delly.Note.Razor.Localization;

/// <summary>
/// 内核
/// </summary>
[LanguageName("Mvc")]
public sealed class MvcLpm : BaseLanguageModulePack
{
    #region 常见名词

    /// <summary>
    /// 主页
    /// </summary>
    [NotNull]
    [Initial("主页")]
    public string? Home { get; set; }

    /// <summary>
    /// 小D笔记
    /// </summary>
    [NotNull]
    [Initial("小D笔记")]
    public string? DellyNote { get; set; }

    /// <summary>
    /// 所有笔记
    /// </summary>
    [NotNull]
    [Initial("所有笔记")]
    public string? AllNotes { get; set; }

    /// <summary>
    /// 添加Markdown笔记
    /// </summary>
    [NotNull]
    [Initial("添加Markdown笔记")]
    public string? AddMdNote { get; set; }

    /// <summary>
    /// 保存
    /// </summary>
    [NotNull]
    [Initial("保存")]
    public string? Save { get; set; }

    /// <summary>
    /// 编辑
    /// </summary>
    [NotNull]
    [Initial("编辑")]
    public string? Edit { get; set; }

    /// <summary>
    /// 登录
    /// </summary>
    [NotNull]
    [Initial("登录")]
    public string? Login { get; set; }

    /// <summary>
    /// 让笔记更简单
    /// </summary>
    [NotNull]
    [Initial("让笔记更简单")]
    public string? Slogan { get; set; }
    
    /// <summary>
    /// 获取报价
    /// </summary>
    [NotNull]
    [Initial("获取报价")]
    public string? Quotation { get; set; }
    
    /// <summary>
    /// 获取报价提示
    /// </summary>
    [NotNull]
    [Initial("获取报价提示")]
    public string? QuotationTip { get; set; }
    
    /// <summary>
    /// 确定
    /// </summary>
    [NotNull]
    [Initial("确定")]
    public string? Confirm { get; set; }

    /// <summary>
    /// 请输入标题
    /// </summary>
    [NotNull]
    [Initial("请输入标题")]
    public string? PleaseInputTitle { get; set; }

    #endregion

}