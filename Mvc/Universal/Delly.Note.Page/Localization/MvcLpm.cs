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
    /// 登录
    /// </summary>
    [NotNull]
    [Initial("登录")]
    public string? Login { get; set; }

    /// <summary>
    /// 注销
    /// </summary>
    [NotNull]
    [Initial("注销")]
    public string? Logout { get; set; }

    /// <summary>
    /// 所有产品
    /// </summary>
    [NotNull]
    [Initial("所有产品")]
    public string? Products { get; set; }
    
    /// <summary>
    /// 关于
    /// </summary>
    [NotNull]
    [Initial("关于")]
    public string? About { get; set; }
    
    /// <summary>
    /// 联系我们
    /// </summary>
    [NotNull]
    [Initial("联系我们")]
    public string? ContactUs { get; set; }
    
    /// <summary>
    /// 快速访问
    /// </summary>
    [NotNull]
    [Initial("快速访问")]
    public string? QuickLink { get; set; }
    
    /// <summary>
    /// 关注我们
    /// </summary>
    [NotNull]
    [Initial("关注我们")]
    public string? FollowUs { get; set; }
    
    /// <summary>
    /// 搜索产品
    /// </summary>
    [NotNull]
    [Initial("搜索产品")]
    public string? SearchProduct { get; set; }

    /// <summary>
    /// 让笔记更简单
    /// </summary>
    [NotNull]
    [Initial("让笔记更简单")]
    public string? Slogan { get; set; }
    
    /// <summary>
    /// 副标语
    /// </summary>
    [NotNull]
    [Initial("副标语")]
    public string? SubSlogan { get; set; }
    
    /// <summary>
    /// 选择产品
    /// </summary>
    [NotNull]
    [Initial("选择产品")]
    public string? SelectProduct { get; set; }
    
    /// <summary>
    /// OEM
    /// </summary>
    [NotNull]
    [Initial("OEM")]
    public string? Oem { get; set; }
    
    /// <summary>
    /// 可定制
    /// </summary>
    [NotNull]
    [Initial("可定制")]
    public string? Customized { get; set; }
    
    /// <summary>
    /// 质量保证
    /// </summary>
    [NotNull]
    [Initial("质量保证")]
    public string? QualityAssurance { get; set; }
    
    /// <summary>
    /// 获取报价
    /// </summary>
    [NotNull]
    [Initial("获取报价")]
    public string? Quotation { get; set; }
    
    /// <summary>
    /// 地址
    /// </summary>
    [NotNull]
    [Initial("地址")]
    public string? Address { get; set; }
    
    /// <summary>
    /// 电话
    /// </summary>
    [NotNull]
    [Initial("电话")]
    public string? Phone { get; set; }
    
    /// <summary>
    /// 邮箱
    /// </summary>
    [NotNull]
    [Initial("邮箱")]
    public string? Email { get; set; }
    
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

    #endregion
    
}