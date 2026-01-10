using Delly.Note.Common.Document.Vo;
using Delly.Note.Razor.Extension;
using Delly.Note.Razor.Localization;
using Delly.Note.Razor.Model;
using Jip.Define.Data.Vo;
using Jip.Kernel.Common.General.UnitOfWork;

namespace Delly.Note.Razor.Pages;

/// <summary>
/// 列表
/// </summary>
public class ListModel : BaseGenericPageModel
{
    private readonly ILogger<ListModel> _logger;
    private readonly UowCommonCore _uowCommonCore;
    private readonly LpmCommonCore _lpmCommonCore;

    /// <summary>
    /// 列表
    /// </summary>
    public ListModel(
        ILogger<ListModel> logger,
        UowCommonCore uowCommonCore,
        LpmCommonCore lpmCommonCore
    )
    {
        _logger = logger;
        _uowCommonCore = uowCommonCore;
        _lpmCommonCore = lpmCommonCore;
    }

    /// <summary>
    /// 语言包模块
    /// </summary>
    public MvcLpm Lpm { get; set; } = new MvcLpm();

    /// <summary>
    /// 最新产品信息
    /// </summary>
    public PagedVo<MarkdownNoteQueryVo> NotePaged { get; set; } = new();

    /// <summary>
    /// 关键字
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// 异步 Get
    /// </summary>
    /// <returns></returns>
    public async Task OnGetAsync()
    {
        using var uow = _uowCommonCore.Begin();
        // 附加样式
        this.AppendCss("css/product.css");
        //// 处理模板数据
        //await base.HandleTemplateData(_siteDefineDataCore, _sitePageDataCore, _topicDefineDataCore,
        //    _categoryDefineDataCore, _articleInfoDataCore);
        // 获取语言包
        var lpm = _lpmCommonCore.GetPackModule<MvcLpm>(Language);
        this.SetLanguagePack(lpm);
        Lpm = lpm;
        // 设置标题
        this.SetTitle(lpm.Home);
        // 获取页码
        if (!int.TryParse(Request.Query["page"].ToString(), out var page))
        {
            page = 1;
        }
        // 获取搜索关键字
        Key = Request.Query["key"].ToString();
        // 获取最新产品
        NotePaged = await GetNotePage(Key, page);
    }

    // 获取最新产品
    private async Task<PagedVo<MarkdownNoteQueryVo>> GetNotePage(string key, int page)
    {
        //var query = from ai in _articleInfoDataCore.Query()
        //        .WhereIf(!key.IsNullOrWhiteSpace(), d => d.Title.Contains(key))
        //    join cd in _categoryDefineDataCore.Query() on ai.CategoryId equals cd.Id
        //    join td in _topicDefineDataCore.Query() on cd.TopicId equals td.Id
        //    where td.SiteId == Site.Id
        //          && td.Code == "PRODUCTS"
        //    orderby ai.LastModificationTime descending
        //    select new ArticleViewDto
        //    {
        //        Id = ai.Id,
        //        Title = ai.Title,
        //        Image = ai.Image,
        //        Summary = ai.Summary,
        //        CategoryId = ai.CategoryId,
        //        CategoryName = cd.Name,
        //    };
        //// 获取总行数
        //var rowCount = await query.CountAsync();
        // 执行分页查询并返回
        var paged = new PagedVo()
        {
            Page = page,
            PageSize = 10
        };
        var pagedVo = new PagedVo<MarkdownNoteQueryVo>(paged);
        //paged.UpdateRowCountAndPageTotal(rowCount);
        //paged.Rows = await query.Paged(pagedDto.Page, pagedDto.PageSize)
        //    .ToListAsync();
        return pagedVo;
    }
}