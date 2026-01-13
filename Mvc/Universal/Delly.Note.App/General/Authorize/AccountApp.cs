using Jip.Kernel.Common.Authorize;
using Jip.Kernel.Common.Feature;
using Jip.Kernel.Common.General.Exception;
using Jip.Kernel.Common.General.ObjectMap;
using Jip.Kernel.Define.Authorize.AccountLogin.Dto;
using Jip.WebApi.App.AppService;
using Jip.WebApi.Kernel.App.General;
using Jip.WebApi.Kernel.Service.Authorize;
using Microsoft.AspNetCore.Http;
using Nuo.Extension;
using Nuo.Ioc.Kernel.Extension;
using Nuo.Jwt.Configure;
using Nuo.Jwt.Dependency;
using Nuo.Jwt.Extension;
using Nuo.WebApi.Jwt.Attribute;
using Nuo.WebApi.Jwt.Data;
using Nuo.WebApi.Jwt.Dependency;
using Nuo.WebApi.Jwt.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delly.Note.App.General.Authorize;

/// <summary>
/// 账户
/// </summary>
public sealed class AccountApp : BaseModuleAppService
{
    #region 依赖注入

    private readonly AccountCore _accountCore;
    private readonly JipUserDataCore _jipUserDataCore;
    private readonly ExceptionCommonCore _exceptionCommonCore;
    private readonly PasswordCommonCore _passwordCommonCore;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IJwtManager _jwtManager;
    private readonly JwtConfig _jwtConfig;

    /// <summary>
    /// 账户
    /// </summary>
    public AccountApp(
        AccountCore accountCore,
        JipUserDataCore jipUserDataCore,
        JipFeatureCategoryDataCore jipFeatureCategoryDataCore,
        ExceptionCommonCore exceptionCommonCore,
        MapCommonCore mapCommonCore,
        PasswordCommonCore passwordCommonCore,
        IHttpContextAccessor httpContextAccessor,
        IJwtManager jwtManager,
        JwtConfig jwtConfig
        )
    {
        _accountCore = accountCore;
        _jipUserDataCore = jipUserDataCore;
        _exceptionCommonCore = exceptionCommonCore;
        _passwordCommonCore = passwordCommonCore;
        _httpContextAccessor = httpContextAccessor;
        _jwtManager = jwtManager;
        _jwtConfig = jwtConfig;
    }

    #endregion

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task Login(AccountLoginDto input)
    {
        var user = await _accountCore.Login(input);
        if (user is null) { throw _exceptionCommonCore.UserFriendly(Lpm.IncorrectUsernameOrPassword); }
        using var work = _jwtManager.CreateWork();
        // 输出Jwt
        var jwtInfo = work.SetInfoByDataTo(new WebApiJwtData()
        {
            UserId = user.Id,
            UserCode = user.Code,
            UserName = user.Name,
        });
        var response = _httpContextAccessor.HttpContext?.Response;
        response?.SetJwtToken(jwtInfo, _jwtConfig);
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [JwtAuthorize]
    public async Task ChangePassword(AccountChangePasswordDto input)
    {
        var jwtDataManager = IocContainer.ResolveRequired<IJwtDataManager>();
        var jwtData = jwtDataManager.GetData<WebApiJwtData>().Sure();
        // 校验用户是否存在
        var user = await _jipUserDataCore.GetEntityAsync(jwtData.UserId);
        if (user is null) { throw _exceptionCommonCore.NotExist(Lpm.User, jwtData.UserCode); }
        // 判断用户密码是否正确
        var oldPassword = _passwordCommonCore.GetPassword(user.Code, input.OldPassword);
        if (user.Password != oldPassword) { throw _exceptionCommonCore.UserFriendly(Lpm.OldPasswordIncorrect); }
        // 执行密码修改
        await _accountCore.ChangePassword(input, user);
    }
}
