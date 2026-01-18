using DellyNote.Common.Storage;
using Jip.Kernel.Common.General.LogRecord;
using Jip.WebApi.Kernel.App.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nuo.Hosting.ResultWrapper.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.App.Storage;

/// <summary>
/// 文件
/// </summary>
public sealed class FileApp(
    IHttpContextAccessor httpContextAccessor,
    StorageCommonCore storageCommonCore,
    LogCommonCore logCommonCore
    ) : BaseModuleAppService
{

    /// <summary>
    /// 文本
    /// </summary>
    private const string MIME_TEXT_PLAINT = "text/plain";

    #region 依赖注入

    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly StorageCommonCore _storageCommonCore = storageCommonCore;
    private readonly LogCommonCore _logCommonCore = logCommonCore;

    #endregion

    /// <summary>
    /// 文件上传
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [NotWrapper]
    public async Task<IActionResult> Get(string id)
    {
        var respose = _httpContextAccessor.HttpContext?.Response!;
        try
        {
            // 打开文件
            var fs = _storageCommonCore.OpenRead($"{id}.file");
            // 文件名必须编码，否则会有特殊字符(如中文)无法在此下载。
            string encodeFilename = System.Web.HttpUtility.UrlEncode($"{id}.file", Encoding.GetEncoding("UTF-8"));
            // 添加头部信息
            respose.Headers.ContentLength = fs.Length;
            respose.Headers.Append("Access-Control-Expose-Headers", "*");
            respose.Headers.Append("Content-Disposition", "attachment; filename=" + encodeFilename);
            // 返回文件流
            return new FileStreamResult(fs, "application/octet-stream");
        }
        catch (Exception ex)
        {
            _logCommonCore.Error(ex);
            return new ContentResult() { Content = ex.Message, ContentType = MIME_TEXT_PLAINT, StatusCode = 500 };
        }
    }
}
