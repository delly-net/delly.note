using DellyNote.Common.Storage.Configure;
using Jip.Common.Atom;
using Microsoft.AspNetCore.Http;
using Nuo.Extension;
using Nuo.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.Common.Storage;

/// <summary>
/// 存储公共和兴
/// </summary>
public sealed class StorageCommonCore(StorageConfig storageConfig) : BaseGenericCommonCore
{
    private readonly StorageConfig _storageConfig = storageConfig;

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="storageCommonCore"></param>
    /// <param name="file"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public async Task WriteAsync(IFormFile file, string path)
    {
        // 拼接完整路径
        string filePath = PathUtils.StandardCombine(_storageConfig.Path, path);
        // 自动创建目录
        string fileFolder = Path.GetDirectoryName(filePath).Sure();
        PathUtils.CreateFolderIfPossible(fileFolder);
        // 保存文件
        using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        await file.CopyToAsync(fs);
        fs.Close();
    }

    /// <summary>
    /// 打开读取流
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public FileStream OpenRead(string path)
    {
        // 拼接完整路径
        string filePath = PathUtils.StandardCombine(_storageConfig.Path, path);
        return new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
    }
}
