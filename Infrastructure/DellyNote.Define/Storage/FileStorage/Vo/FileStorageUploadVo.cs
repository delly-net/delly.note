using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.Define.Storage.FileStorage.Vo;

/// <summary>
/// 文件存储上传 视图输出
/// </summary>
public sealed class FileStorageUploadVo
{
    /// <summary>
    /// 是否成功
    /// </summary>
    public int Success { get; set; } = 0;

    /// <summary>
    /// 消息
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 下载地址
    /// </summary>
    public string? Url { get; set; }
}
