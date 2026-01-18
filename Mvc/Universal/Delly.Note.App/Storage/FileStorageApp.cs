using Microsoft.AspNetCore.Mvc;
using Nuo.WebApi.Jwt.Attribute;
using Microsoft.AspNetCore.Http;
using Jip.WebApi.Kernel.App.General;
using Jip.Kernel.Common.General.Exception;
using DellyNote.Common.Storage;
using Nuo.Hosting.ResultWrapper.Attribute;
using DellyNote.Define.Storage.FileStorage.Vo;

namespace DellyNote.App.Storage;

/// <summary>
/// 文件存储信息
/// </summary>
//[JwtAuthorize]
public sealed class FileStorageApp(
    ExceptionCommonCore exceptionCommonCore,
    StorageCommonCore storageCommonCore
    ) : BaseModuleAppService
{
    private readonly ExceptionCommonCore _exceptionCommonCore = exceptionCommonCore;
    private readonly StorageCommonCore _storageCommonCore = storageCommonCore;

    /// <summary>
    /// 文件上传
    /// </summary>
    /// <param name="file">文件</param>
    /// <returns></returns>
    [NotWrapper]
    public async Task<FileStorageUploadVo> Upload([FromForm(Name = "editormd-image-file")] IFormFile? file)
    {
        try
        {
            if (file is null) { throw _exceptionCommonCore.UserFriendly(Lpm.UploadFileNotFound); }
            // 获取当前时间
            var now = DateTime.Now;
            var id = Guid.NewGuid().ToString("N");
            var path = $"{id}.file";
            // 保存文件
            await _storageCommonCore.WriteAsync(file, path);
            return new FileStorageUploadVo
            {
                Success = 1,
                Url = $"/app/delly/File/Get?id={id}",
            };
        }
        catch (Exception ex)
        {
            return new FileStorageUploadVo
            {
                Success = 0,
                Message = ex.Message,
            };
        }

    }

}
