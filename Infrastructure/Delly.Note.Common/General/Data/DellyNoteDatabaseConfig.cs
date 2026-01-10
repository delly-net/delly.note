using Jip.Common.Data.Configure;
using Nuo.Configure;
using Nuo.Configure.Json.Attribute;
using Nuo.Data.Configure;
using Nuo.IO.Constant;
using Nuo.Ref.Attribute;

namespace Delly.Note.Common.General.Data;

/// <summary>
/// 数据库配置
/// </summary>
public class DellyNoteDatabaseConfig: JipDatabaseConfig
{
    /// <summary>
    /// Delly Note
    /// </summary>
    [Initial(Type = typeof(DbConnectionConfig))]
    public DbConnectionConfig? DellyNote { get; set; }
}
