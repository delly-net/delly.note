using DellyNote.Common.Storage.Configure;
using DellyNote.Common.General.Data;
using Jip.Common.Data.Configure;
using Jip.Common.General.Configure;
using Jip.Common.Logger;
using Jip.Common.Service.Configure;
using Jip.Configuration.Common.General.Utils;
using Jip.Kernel.Common.General.Configure;
using Jip.WebApi.Service.Ioc;
using Nuo.Ioc.Kernel;
using Nuo.Ioc.Kernel.Attribute;
using Nuo.Ioc.Kernel.Extension;
using Nuo.Ioc.Kernel.Profile;
using Nuo.Ioc.Modular.Attribute;
using Nuo.Jwt.Configure;
using Nuo.Platform.Data.Extension;
using Nuo.Platform.Logger.Extension;
using Nuo.Security.License.Configure;
using Nuo.WebApi.Jwt.Data;
using Nuo.WebApi.Jwt.Extension;

namespace DellyNote.Startup.Ioc;

/// <summary>
/// 平台 WebApi 启动 容器配置
/// </summary>
[IocApply]
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
        iocContainer.AddLogger();
        // iocContainer.AddTransient<ILogWriter, Log4NetLogger>();
        //iocContainer.AddTransient<ILogWriter, CommonLogWriter>();
        // 注册数据库配置
        Console.WriteLine("Apply Database ...");
        //var databaseConfig = GenericConfigureHelper.ReadEncryptConfig<DatabaseConfig>("Database.json", SecurityHelper.RC2StringEncryptor);
        var databaseConfig = GenericConfigureHelper.ReadGenericConfig<DellyNoteDatabaseConfig>("Database.json");
        iocContainer.AddSingleton<JipDatabaseConfig>(databaseConfig);
        iocContainer.AddSingleton(databaseConfig);
        iocContainer.AddDatabase();
        // 注册数据初始化配置
        Console.WriteLine("Apply DataInitialize.json ...");
        var dataInitializeConfig = GenericConfigureHelper.ReadGenericConfig<DataInitializeConfig>("DataInitialize.json");
        iocContainer.AddSingleton(dataInitializeConfig);
        // 注册建模配置
        Console.WriteLine("Apply OpenService.json ...");
        var openServiceConfig = GenericConfigureHelper.ReadGenericConfig<JipOpenServiceConfig>("JipService.json");
        iocContainer.AddSingleton(openServiceConfig);
        // 注册建模配置
        Console.WriteLine("Apply Model.json ...");
        var modelingConfig = OpenModelConfigureUtils.GetModelConfig(iocContainer, openServiceConfig, "Model.json").GetAwaiter().GetResult();
        iocContainer.AddSingleton(modelingConfig);
        // 注册Jwt
        Console.WriteLine("Apply Jwt ...");
        var jwtConfig = GenericConfigureHelper.ReadGenericConfig<JwtConfig>("Jwt.json");
        iocContainer.AddJwt<WebApiJwtData>(jwtConfig);
        // 读取许可证配置
        Console.WriteLine("Apply Licenses.json ...");
        var multiLicenseConfig = GenericConfigureHelper.ReadGenericConfig<MultiLicenseConfig>("Licenses.json");
        iocContainer.AddSingleton(multiLicenseConfig);
        // 读取存储配置
        Console.WriteLine("Apply Storage.json ...");
        var storageConfig = GenericConfigureHelper.ReadGenericConfig<StorageConfig>("Storage.json");
        iocContainer.AddSingleton(storageConfig);
    }
}
