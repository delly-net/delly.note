using DellyNote.Common.Redis.Configure;
using Jip.Common.Atom;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.Common.Redis;

/// <summary>
/// Redis通用核心
/// </summary>
public sealed class RedisCommonCore(IRedisConnection redisConnection, RedisConfig redisConfig) : BaseGenericCommonCore
{
    private readonly IRedisConnection _redisConnection = redisConnection;
    private readonly RedisConfig _redisConfig = redisConfig;
    private readonly IDatabase _database = redisConnection.GetDatabase();

    /// <summary>
    /// Redis标志
    /// </summary>
    public const string REDIS_FLAG = "Session_";

    /// <summary>
    /// 创建SessionKey
    /// </summary>
    /// <returns></returns>
    public async Task<string> CreatSessionKey()
    {
        string key;
        string redisKey;
        do
        {
            key = Guid.NewGuid().ToString("N");
            redisKey = REDIS_FLAG + key;
        } while ((await _database.StringGetAsync(redisKey)).HasValue);
        await _database.StringSetAsync(redisKey, "1", TimeSpan.FromMilliseconds(_redisConfig.ExpirationTime.Value));
        return key;
    }

    /// <summary>
    /// 判断是否包含SessionKey
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public async Task<bool> ContainsSessionKey(string key)
    {
        var redisKey = REDIS_FLAG + key;
        var redisValue = await _database.StringGetAsync(redisKey);
        if (!redisValue.HasValue) { return false; }
        // 延长有效期
        await _database.StringSetAsync(redisKey, "1", TimeSpan.FromMilliseconds(_redisConfig.ExpirationTime.Value));
        return true;
    }
}
