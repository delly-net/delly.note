using DellyNote.Common.Kernel.Document;
using DellyNote.Razor.Extension;
using DellyNote.Razor.Localization;
using DellyNote.Razor.Model;
using Jip.Kernel.Common.General.UnitOfWork;
using Nuo.Extension;

namespace DellyNote.Razor.Pages;

/// <summary>
/// 内容页
/// </summary>
public class ContentModel(
    ILogger<IndexModel> logger,
    NoteDataCore noteDataCore,
    UowCommonCore uowCommonCore,
    LpmCommonCore lpmCommonCore
    ) : BaseGenericPageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
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
    public Common.Kernel.Document.Entity.Note? Note { get; set; }

    /// <summary>
    /// 异步 Get
    /// </summary>
    /// <returns></returns>
    public async Task OnGetAsync()
    {
        using var uow = _uowCommonCore.Begin();
        //// 附加样式
        //this.AppendCss("css/content-page.css");
        //// 处理模板数据
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
        this.SetTitle(Note?.Title ?? string.Empty);
    }

    /// <summary>
    /// 加载笔记信息
    /// </summary>
    private async Task LoadNote(string noteId)
    {
        if (noteId.IsNullOrWhiteSpace()) { return; }
        Note = await _noteDataCore.GetEntityAsync(noteId);
    }
}