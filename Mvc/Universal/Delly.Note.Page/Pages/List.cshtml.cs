using DellyNote.Common.Kernel.Document;
using DellyNote.Common.Kernel.Document.Note.Dto;
using DellyNote.Common.Kernel.Document.Note.Vo;
using DellyNote.Razor.Extension;
using DellyNote.Razor.Localization;
using DellyNote.Razor.Model;
using Jip.Common.Data.Extension;
using Jip.Define.Data.Vo;
using Jip.Kernel.Common.General.UnitOfWork;
using Nuo.Data.General.Extension;
using Nuo.Extension;

namespace DellyNote.Razor.Pages;

/// <summary>
/// 列表
/// </summary>
public class ListModel(
    ILogger<ListModel> logger,
    NoteDataCore noteDataCore,
    UowCommonCore uowCommonCore,
    LpmCommonCore lpmCommonCore
    ) : BaseGenericPageModel
{

    private readonly ILogger<ListModel> _logger = logger;
    private readonly NoteDataCore _noteDataCore = noteDataCore;
    private readonly UowCommonCore _uowCommonCore = uowCommonCore;
    private readonly LpmCommonCore _lpmCommonCore = lpmCommonCore;

    /// <summary>
    /// 语言包模块
    /// </summary>
    public MvcLpm Lpm { get; set; } = new MvcLpm();

    /// <summary>
    /// 最新产品信息
    /// </summary>
    public PagedVo<NoteQueryVo> NotePaged { get; set; } = new();

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
        this.AppendCss("css/list.css");
        // 附加脚本
        this.AppendJs("js/list.js");
        //// 处理模板数据
        //await base.HandleTemplateData(_siteDefineDataCore, _sitePageDataCore, _topicDefineDataCore,
        //    _categoryDefineDataCore, _articleInfoDataCore);
        // 获取语言包
        var lpm = _lpmCommonCore.GetPackModule<MvcLpm>(Language);
        this.SetLanguagePack(lpm);
        Lpm = lpm;
        // 设置标题
        this.SetTitle($"{lpm.AllNotes} - {lpm.DellyNote}");
        // 设置标志
        this.SetFlag(nameof(ListModel));
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
    private async Task<PagedVo<NoteQueryVo>> GetNotePage(string key, int page)
    {
        var query = from n in _noteDataCore.Query()
                .WhereIf(!key.IsNullOrWhiteSpace(), d => d.Title.Contains(key))
                    select new NoteQueryVo
                    {
                        Id = n.Id,
                        Title = n.Title,
                        NoteType = n.NoteType,
                        CreationTime = n.CreationTime,
                        CreationUserId = n.CreationUserId,
                        CreationUserName = n.CreationUserName,
                        LastModificationTime = n.LastModificationTime,
                        LastModificationUserId = n.LastModificationUserId,
                        LastModificationUserName = n.LastModificationUserName,
                    };
        // 获取总行数
        var rowCount = await query.CountAsync();
        // 执行分页查询并返回
        var pagedDto = new NotePagedDto()
        {
            Page = page,
            PageSize = 12
        };
        var pagedVo = new PagedVo<NoteQueryVo>(pagedDto, rowCount);
        pagedVo.Rows = await query.OrderByDescending(d=>d.LastModificationTime).Paged(pagedDto.Page, pagedDto.PageSize).ToListAsync();
        return pagedVo;
    }
}