# 请参阅 https://aka.ms/customizecontainer 以了解如何自定义调试容器，以及 Visual Studio 如何使用此 Dockerfile 生成映像以更快地进行调试。

# 使用官方Ubuntu 22.04基础镜像
# FROM ubuntu:22.04
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app
# EXPOSE 8011

# # 安装libicu-dev
# RUN apt-get update && \
#     apt-get install -y libicu-dev && \
#     rm -rf /var/lib/apt/lists/*

# # 设置环境变量（时区/语言）
# ENV TZ=Asia/Shanghai \
#     DEBIAN_FRONTEND=noninteractive
RUN apk add --no-cache libc6-compat tzdata && \
  ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime && \
  echo "Asia/Shanghai" > /etc/timezone

# 复制程序文件
COPY files /app
# 设置主程序可运行
RUN chmod +x /app/delly-note
# 执行主程序
CMD ["/app/delly-note"]