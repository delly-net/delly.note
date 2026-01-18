using Nuo.Localization.Modular;
using Nuo.Localization.Modular.Attribute;
using Nuo.Ref.Attribute;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.Common.General.Localization;

/// <summary>
/// 内核
/// </summary>
[LanguageName("DellyNote")]
public sealed class DellyNoteLpm : BaseLanguageModulePack
{
    #region 常见异常

    /// <summary>
    /// 不允许为空
    /// </summary>
    [NotNull]
    [Initial("不允许为空")]
    public string? NotNull { get; set; }

    /// <summary>
    /// 缺失
    /// </summary>
    [NotNull]
    [Initial("缺失")]
    public string? Missing { get; set; }

    /// <summary>
    /// 不存在
    /// </summary>
    [NotNull]
    [Initial("不存在")]
    public string? NotExist { get; set; }

    /// <summary>
    /// 已存在
    /// </summary>
    [NotNull]
    [Initial("已存在")]
    public string? AlreadyExist { get; set; }

    /// <summary>
    /// 不可用
    /// </summary>
    [NotNull]
    [Initial("不可用")]
    public string? NotAvailable { get; set; }

    /// <summary>
    /// 重复
    /// </summary>
    [NotNull]
    [Initial("重复")]
    public string? Duplicate { get; set; }

    /// <summary>
    /// 字段必填
    /// </summary>
    [NotNull]
    [Initial("字段必填")]
    public string? FieldRequired { get; set; }

    /// <summary>
    /// Root账户未找到可初始化的内容
    /// </summary>
    [NotNull]
    [Initial("Root账户未找到可初始化的内容")]
    public string? RootNoInitializationAvailable { get; set; }

    /// <summary>
    /// 用户名或密码错误
    /// </summary>
    [NotNull]
    [Initial("用户名或密码错误")]
    public string? IncorrectUsernameOrPassword { get; set; }

    /// <summary>
    /// 权限不足
    /// </summary>
    [NotNull]
    [Initial("权限不足")]
    public string? PermissionDenied { get; set; }

    /// <summary>
    /// 账户未绑定租户
    /// </summary>
    [NotNull]
    [Initial("账户未绑定租户")]
    public string? AccountUnboundTenant { get; set; }

    /// <summary>
    /// 原密码不正确
    /// </summary>
    [NotNull]
    [Initial("原密码不正确")]
    public string? OldPasswordIncorrect { get; set; }

    /// <summary>
    /// 已经是第一条
    /// </summary>
    [NotNull]
    [Initial("已经是第一条")]
    public string? AlreadyFirstSeq { get; set; }

    /// <summary>
    /// 已经是最后一条
    /// </summary>
    [NotNull]
    [Initial("已经是最后一条")]
    public string? AlreadyLastSeq { get; set; }

    /// <summary>
    /// 未发现上传文件
    /// </summary>
    [NotNull]
    [Initial("未发现上传文件")]
    public string? UploadFileNotFound { get; set; }

    #endregion

    #region 专用异常

    /// <summary>
    /// 批量新增时租户必须唯一
    /// </summary>
    [NotNull]
    [Initial("批量新增时租户必须唯一")]
    public string? BatchInsertTenantUnique { get; set; }

    /// <summary>
    /// 注册信息校验失败
    /// </summary>
    [NotNull]
    [Initial("注册信息校验失败")]
    public string? RegistryVerifyFailed { get; set; }

    /// <summary>
    /// 安装密码不正确
    /// </summary>
    [NotNull]
    [Initial("安装密码不正确")]
    public string? SetupPasswordIncorrect { get; set; }

    #endregion

    #region 常见名词

    /// <summary>
    /// 用户
    /// </summary>
    [NotNull]
    [Initial("用户")]
    public string? User { get; set; }

    /// <summary>
    /// 平台用户编码
    /// </summary>
    [NotNull]
    [Initial("平台用户编码")]
    public string? UserCode { get; set; }

    /// <summary>
    /// 平台用户组编码
    /// </summary>
    [NotNull]
    [Initial("平台用户组编码")]
    public string? UserGroupCode { get; set; }

    /// <summary>
    /// 平台功能类别编码
    /// </summary>
    [NotNull]
    [Initial("平台功能类别编码")]
    public string? FeatureCategoryCode { get; set; }

    /// <summary>
    /// 平台功能菜单编码
    /// </summary>
    [NotNull]
    [Initial("平台功能菜单编码")]
    public string? FeatureMenuCode { get; set; }

    /// <summary>
    /// 平台功能类型编码
    /// </summary>
    [NotNull]
    [Initial("平台功能类型编码")]
    public string? FeatureTypeCode { get; set; }

    /// <summary>
    /// 平台功能Id
    /// </summary>
    [NotNull]
    [Initial("平台功能Id")]
    public string? FeatureId { get; set; }

    /// <summary>
    /// 平台功能编码
    /// </summary>
    [NotNull]
    [Initial("平台功能编码")]
    public string? FeatureCode { get; set; }

    /// <summary>
    /// 平台权限组编码
    /// </summary>
    [NotNull]
    [Initial("平台权限组编码")]
    public string? PermissionGroupCode { get; set; }

    /// <summary>
    /// 平台权限编码
    /// </summary>
    [NotNull]
    [Initial("平台权限编码")]
    public string? PermissionCode { get; set; }

    /// <summary>
    /// 用户状态
    /// </summary>
    [NotNull]
    [Initial("用户状态")]
    public string? UserStatus { get; set; }

    /// <summary>
    /// 员工
    /// </summary>
    [NotNull]
    [Initial("员工")]
    public string? Emplyee { get; set; }

    /// <summary>
    /// 租户
    /// </summary>
    [NotNull]
    [Initial("租户")]
    public string? Tenant { get; set; }

    #endregion
}
