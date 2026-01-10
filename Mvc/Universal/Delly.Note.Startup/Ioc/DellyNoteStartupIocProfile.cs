using Delly.Note.Common.General.Data;
using Jip.Common.Data.Configure;
using Jip.Common.General.Configure;
using Jip.Common.Logger;
using Jip.WebApi.Service.Ioc;
using Nuo.Ioc.Kernel;
using Nuo.Ioc.Kernel.Extension;
using Nuo.Ioc.Kernel.Profile;
using Nuo.Ioc.Modular.Attribute;
using Nuo.Platform.Data.Extension;

namespace Delly.Note.Startup.Ioc;

/// <summary>
/// 平台 WebApi 启动 容器配置
/// </summary>
[Depends(typeof(JipWebApiIocProfile))]
public sealed class DellyNoteStartupIocProfile : BaseIocProfile
{
    /// <summary>
    /// 应用配置
    /// </summary>
    /// <param name="iocContainer"></param>
    protected override void OnApplying(IIocContainer iocContainer)
    {
        iocContainer.ApplyProfile<JipWebApiIocProfile>();
        // 注册日志
        Console.WriteLine("Apply Log4NetLogger ...");
        LogWriteUtils.Initialize(iocContainer, false);
        // iocContainer.AddTransient<ILogWriter, Log4NetLogger>();
        //iocContainer.AddTransient<ILogWriter, CommonLogWriter>();
        // 注册数据库配置
        Console.WriteLine("Apply Database ...");
        //var databaseConfig = GenericConfigureHelper.ReadEncryptConfig<DatabaseConfig>("Database.json", SecurityHelper.RC2StringEncryptor);
        var databaseConfig = GenericConfigureHelper.ReadGenericConfig<DellyNoteDatabaseConfig>("Database.json");
        iocContainer.AddSingleton<JipDatabaseConfig>(databaseConfig);
        iocContainer.AddSingleton(databaseConfig);
        iocContainer.AddDatabase();
    }
}
