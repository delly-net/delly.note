using Nuo.Hosting.Application.Extension;
using Jip.Common.Host;
using Microsoft.AspNetCore.Builder;
using Delly.Note.Startup;

// 初始化
HostUtils.Initialize(false);

// 启动
WebApplication.CreateBuilder(args).Build<DellyNoteStartup>().Run();
