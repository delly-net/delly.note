using DellyNote.Linux;
using DellyNote.Startup;
using Jip.Common.Host;
using Microsoft.AspNetCore.Builder;
using Nuo.Hosting.Application.Extension;

// 初始化
HostUtils.Initialize(false);

// 启动
WebApplication.CreateBuilder(args).Build<Startup>().Run();
