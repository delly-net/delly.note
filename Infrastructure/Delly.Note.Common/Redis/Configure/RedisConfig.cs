using Nuo.Ref.Attribute;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.Common.Redis.Configure;

/// <summary>
/// Redis配置
/// </summary>
public sealed class RedisConfig
{
    /// <summary>
    /// 连接字符串
    /// </summary>
    [NotNull]
    [Initial("127.0.0.1:6379,defaultDatabase=0,connectTimeout=5000,syncTimeout=5000")]
    public string? ConnectionString { get; set; }

    /// <summary>
    /// 过期时间(毫秒)
    /// </summary>
    [NotNull]
    [Initial(3600000)]
    public long? ExpirationTime {  get; set; }
}
