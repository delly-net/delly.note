using DellyNote.Common.Redis.Configure;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.Common.Redis.Impl;

/// <summary>
/// Redis连接
/// </summary>
/// <remarks>
/// Redis连接
/// </remarks>
public sealed class DefaultRedisConnection(RedisConfig redisConfig) : IRedisConnection
{
    // 静态连接复用器（核心：整个应用生命周期内复用，不要频繁创建/销毁）
    private readonly IConnectionMultiplexer _redisConn = ConnectionMultiplexer.Connect(redisConfig.ConnectionString);

    /// <summary>
    /// 获取数据库
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public IDatabase GetDatabase(int db = -1)
    {
        return _redisConn.GetDatabase(db);
    }
}
