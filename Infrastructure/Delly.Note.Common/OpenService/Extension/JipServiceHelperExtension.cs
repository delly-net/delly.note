using Jip.Common.Service.Util;
using Jip.Kernel.Define.Authorize.AccountLogin.Dto;
using Jip.Kernel.Define.Authorize.License.Dto;
using Jip.Kernel.Define.Authorize.License.Vo;
using Nuo.Exception;
using Nuo.Net;
using Nuo.Net.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.Common.OpenService.Extension;

/// <summary>
/// Jip服务助手扩展
/// </summary>
public static class JipServiceHelperExtension
{
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="helper"></param>
    /// <param name="loginDto"></param>
    /// <returns></returns>
    public static async Task<ApiResult> LoginAsync(this JipServiceHelper helper, AccountLoginDto loginDto)
    {
        string url = helper.Config.BaseUrl + "/app/kernel/Account/Login";
        return await HttpHelper.WebApi.PostJsonAsync(url, loginDto);
    }
}
