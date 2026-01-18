using Nuo.Configure;
using Nuo.Ref.Attribute;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.Common.Storage.Configure;

/// <summary>
/// 存储配置
/// </summary>
public sealed class StorageConfig
{
    /// <summary>
    /// 存储路径
    /// </summary>
    [NotNull]
    [Initial("${EXECUTION}upload")]
    public string? Path { get; set; }
}
