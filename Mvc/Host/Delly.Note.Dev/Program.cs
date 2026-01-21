using Nuo.Hosting.Application.Extension;
using Jip.Common.Host;
using Microsoft.AspNetCore.Builder;
using DellyNote.Startup;
using DellyNote.Dev;

// 初始化
HostUtils.Initialize(true);

// 启动
WebApplication.CreateBuilder(args).Build<Startup>().Run();
