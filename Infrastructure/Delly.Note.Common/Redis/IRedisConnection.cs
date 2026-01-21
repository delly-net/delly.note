using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.Common.Redis;

/// <summary>
/// Redis连接
/// </summary>
public interface IRedisConnection
{
    /// <summary>
    /// 获取数据库
    /// </summary>
    /// <returns></returns>
    IDatabase GetDatabase(int db = -1);
}
