using Jip.Common.Data.Attribute;
using Jip.Kernel.Common.Authorize;
using Jip.Kernel.Common.General.Configure;
using Jip.Kernel.Common.General.Exception;
using Jip.Kernel.Define.Setup.DataInitialize.Dto;
using Jip.WebApi.Kernel.App.General;
using Jip.WebApi.Kernel.Service.Setup;

namespace DellyNote.App.Setup;

/// <summary>
/// 数据初始化
/// </summary>
public sealed class DataInitializeApp(
    DataInitializeCore dataInitializeCore,
    JipUserDataCore jipUserDataCore,
    ExceptionCommonCore exceptionCommonCore
    ) : BaseModuleAppService
{
    #region 依赖注入

    private readonly DataInitializeCore _dataInitializeCore = dataInitializeCore;
    private readonly JipUserDataCore _jipUserDataCore = jipUserDataCore;
    private readonly ExceptionCommonCore _exceptionCommonCore = exceptionCommonCore;

    #endregion

    /// <summary>
    /// 验证安装密码
    /// </summary>
    /// <returns></returns>
    public async Task VerifySetupPassword(DataInitializeDto dto)
    {
        await _dataInitializeCore.VerifySetupPassword(dto.Password);
    }

    /// <summary>
    /// 安装数据库
    /// </summary>
    /// <returns></returns>
    public async Task SetupDatabase(DataInitializeDto dto)
    {
        await _dataInitializeCore.VerifySetupPassword(dto.Password);
        await _dataInitializeCore.SetupDatabase<JipTableAttribute>();
    }

    /// <summary>
    /// 安装根账户
    /// </summary>
    /// <returns></returns>
    public async Task SetupRoot(DataInitializeDto dto)
    {
        await _dataInitializeCore.VerifySetupPassword(dto.Password);
        var success = await _dataInitializeCore.SetupRoot();
        if (!success) { throw _exceptionCommonCore.UserFriendly(Lpm.RootNoInitializationAvailable); }
    }

}
