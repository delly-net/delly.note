using DellyNote.Common.Kernel.Document;
using DellyNote.Common.Kernel.Document.Entity;
using DellyNote.Razor.Extension;
using DellyNote.Razor.Localization;
using DellyNote.Razor.Model;
using Jip.Kernel.Common.General.UnitOfWork;
using Nuo.Data.Expression.Query.Extension;
using Nuo.Extension;

namespace DellyNote.Razor.Pages;

/// <summary>
/// 编辑页
/// </summary>
public class MdEditModel(
    ILogger<MdEditModel> logger,
    NoteDataCore noteDataCore,
    UowCommonCore uowCommonCore,
    LpmCommonCore lpmCommonCore
    ) : BaseGenericPageModel
{
    private readonly ILogger<MdEditModel> _logger = logger;
    private readonly NoteDataCore _noteDataCore = noteDataCore;
    private readonly UowCommonCore _uowCommonCore = uowCommonCore;
    private readonly LpmCommonCore _lpmCommonCore = lpmCommonCore;

    /// <summary>
    /// 语言包模块
    /// </summary>
    public MvcLpm Lpm { get; set; } = new MvcLpm();

    /// <summary>
    /// 文章信息
    /// </summary>
    public Note? Note { get; set; }

    /// <summary>
    /// 异步 Get
    /// </summary>
    /// <returns></returns>
    public async Task OnGetAsync()
    {
        using var uow = _uowCommonCore.Begin();
        //// 附加样式
        //this.AppendCss("css/product-content-page.css");
        // 处理模板数据
        //var site = await base.HandleTemplateData(_siteDefineDataCore, _sitePageDataCore, _topicDefineDataCore,
        //    _categoryDefineDataCore, _articleInfoDataCore);
        // 获取语言包
        var lpm = _lpmCommonCore.GetPackModule<MvcLpm>(Language);
        this.SetLanguagePack(lpm);
        Lpm = lpm;
        // 获取页面
        var noteId = Request.Query["id"].ToString();
        await LoadNote(noteId);
        // 设置标题
        this.SetTitle(Note is null ? "新增笔记" : $"修改笔记 - {Note.Title}");
        // 判断是否登录
        var userCode = Session.GetString("UserCode");
        if (userCode.IsNullOrWhiteSpace())
        {
            Response.Redirect("/Login");
        }
    }

    /// <summary>
    /// 加载笔记信息
    /// </summary>
    private async Task LoadNote(string noteId)
    {
        if (noteId.IsNullOrWhiteSpace()) { return; }
        Note = await _noteDataCore.GetEntityAsync(noteId);
        //// 获取文章信息
        //var query = from ai in _articleInfoDataCore.Query()
        //    join cd in _categoryDefineDataCore.Query() on ai.CategoryId equals cd.Id
        //    join td in _topicDefineDataCore.Query() on cd.TopicId equals td.Id
        //    where ai.Title == articleCode
        //          && cd.Code == "PAGE"
        //          && td.Code == "PAGE"
        //          && td.SiteId == site.Id
        //    select ai;
        //var sqlSet = query.ToSqlSet();
        //var articleInfo = await query.FirstOrDefaultAsync();
        //if (articleInfo is null)
        //{
        //    return;
        //}
        //ArticleInfo = articleInfo;
        //// 获取超文本信息
        //var htmlInfo = await _htmlInfoDataCore.Query(d => d.TargetType == "ACTICLE" && d.TargetId == articleInfo.Id)
        //    .FirstOrDefaultAsync();
        //if (htmlInfo is null)
        //{
        //    return;
        //}
        //HtmlInfo = htmlInfo;
    }
}