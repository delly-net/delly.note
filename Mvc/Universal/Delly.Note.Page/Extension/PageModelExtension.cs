using Delly.Note.Razor.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nuo.Extension;

namespace Delly.Note.Razor.Extension;

/// <summary>
/// 页面扩展
/// </summary>
public static class PageModelExtension
{
    /// <summary>
    /// 添加样式文件
    /// </summary>
    /// <param name="page"></param>
    /// <param name="path"></param>
    public static void AppendCss(this PageModel page, string path)
    {
        var pageCss = (List<string>?)page.ViewData["css"];
        if (pageCss is null)
        {
            pageCss = new List<string>();
            page.ViewData["css"] = pageCss;
        }
        pageCss.Add(path);
    }

    /// <summary>
    /// 添加脚本文件
    /// </summary>
    /// <param name="page"></param>
    /// <param name="path"></param>
    public static void AppendJs(this PageModel page, string path)
    {
        var pageJs = (List<string>?)page.ViewData["js"];
        if (pageJs is null)
        {
            pageJs = new List<string>();
            page.ViewData["js"] = pageJs;
        }
        pageJs.Add(path);
    }

    /// <summary>
    /// 设置页面标题
    /// </summary>
    /// <param name="page"></param>
    /// <param name="title"></param>
    public static void SetTitle(this PageModel page, string title)
    {
        page.ViewData["title"] = title;
    }

    /// <summary>
    /// 设置标识
    /// </summary>
    /// <param name="page"></param>
    /// <param name="title"></param>
    public static void SetFlag(this PageModel page, string flag)
    {
        page.ViewData["flag"] = flag;
    }

    /// <summary>
    /// 获取语言设置
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public static string GetLanguage(this PageModel page)
    {
        var language = page.Request.Query["lang"].ToString();
        return language.IsNullOrWhiteSpace() ? "en" : language;
    }
    
    /// <summary>
    /// 设置页面语言
    /// </summary>
    /// <param name="page"></param>
    /// <param name="language"></param>
    public static void SetLanguage(this PageModel page, string language)
    {
        page.ViewData["lang"] = language;
    }
    
    /// <summary>
    /// 设置页面语言包
    /// </summary>
    /// <param name="page"></param>
    /// <param name="lpm"></param>
    public static void SetLanguagePack(this PageModel page, MvcLpm lpm)
    {
        page.ViewData["lpm"] = lpm;
    }
    
    /// <summary>
    /// 设置Banner图是否显示
    /// </summary>
    /// <param name="page"></param>
    /// <param name="isBannerVisible"></param>
    public static void SetBannerVisible(this PageModel page, bool isBannerVisible)
    {
        page.ViewData["banner_visible"] = isBannerVisible;
    }
}