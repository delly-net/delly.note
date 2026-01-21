using DellyNote.Common.OpenService.Extension;
using Jip.Common.Service.Configure;
using Jip.Common.Service.Util;
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

namespace DellyNote.App.General.Authorize;

/// <summary>
/// 账户
/// </summary>
/// <remarks>
/// 账户
/// </remarks>
public sealed class AccountApp(
    AccountCore accountCore,
    JipUserDataCore jipUserDataCore,
    //JipFeatureCategoryDataCore jipFeatureCategoryDataCore,
    ExceptionCommonCore exceptionCommonCore,
    //MapCommonCore mapCommonCore,
    PasswordCommonCore passwordCommonCore,
    IHttpContextAccessor httpContextAccessor,
    JipOpenServiceConfig jipOpenServiceConfig
        //IJwtManager jwtManager,
        //JwtConfig jwtConfig,
        ) : BaseModuleAppService
{
    #region 依赖注入

    private readonly AccountCore _accountCore = accountCore;
    private readonly JipUserDataCore _jipUserDataCore = jipUserDataCore;
    private readonly ExceptionCommonCore _exceptionCommonCore = exceptionCommonCore;
    private readonly PasswordCommonCore _passwordCommonCore = passwordCommonCore;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly JipOpenServiceConfig _jipOpenServiceConfig = jipOpenServiceConfig;

    #endregion

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task Login(AccountLoginDto dto)
    {
        var res = await JipServiceUtils.GetHelper(_jipOpenServiceConfig).LoginAsync(dto);
        if (!res.Success) { throw _exceptionCommonCore.UserFriendly(res.Message!); }
        //var user = await _accountCore.Login(input);
        //if (user is null) { throw _exceptionCommonCore.UserFriendly(Lpm.IncorrectUsernameOrPassword); }
        //using var work = _jwtManager.CreateWork();
        //// 输出Jwt
        //var jwtInfo = work.SetInfoByDataTo(new WebApiJwtData()
        //{
        //    UserId = user.Id,
        //    UserCode = user.Code,
        //    UserName = user.Name,
        //});
        var session = _httpContextAccessor.HttpContext?.Session;
        if (session is null) { return; }
        // response?.SetJwtToken(jwtInfo, _jwtConfig);
        // session.SetString("UserId", user.Id);
        session.SetString("UserCode", dto.UserCode);
        //session.SetString("UserName", user.Name);
    }

    /// <summary>
    /// 注销
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task Logout()
    {
        var session = _httpContextAccessor.HttpContext?.Session;
        if (session is null) { return; }
        session.Remove("UserCode");
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
