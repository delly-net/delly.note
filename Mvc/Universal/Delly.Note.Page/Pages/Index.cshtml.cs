using DellyNote.Common.Kernel.Document;
using DellyNote.Common.Kernel.Document.Entity;
using DellyNote.Common.Kernel.Document.Note.Dto;
using DellyNote.Common.Kernel.Document.Note.Vo;
using DellyNote.Razor.Extension;
using DellyNote.Razor.Localization;
using DellyNote.Razor.Model;
using Jip.Define.Data.Vo;
using Jip.Kernel.Common.General.UnitOfWork;
using Nuo.Data.General.Extension;
using Nuo.Extension;

namespace DellyNote.Razor.Pages;

/// <summary>
/// 主页
/// </summary>
public class IndexModel(
    ILogger<IndexModel> logger,
    UowCommonCore uowCommonCore,
    LpmCommonCore lpmCommonCore,
    NoteDataCore noteDataCore
    ) : BaseGenericPageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly UowCommonCore _uowCommonCore = uowCommonCore;
    private readonly LpmCommonCore _lpmCommonCore = lpmCommonCore;
    private readonly NoteDataCore _noteDataCore = noteDataCore;

    /// <summary>
    /// 语言包模块
    /// </summary>
    public MvcLpm Lpm { get; set; } = new();

    /// <summary>
    /// 笔记集合
    /// </summary>
    public List<NoteQueryVo> Notes { get; set; } = [];

    /// <summary>
    /// 异步 Get
    /// </summary>
    /// <returns></returns>
    public async Task OnGetAsync()
    {
        using var uow = _uowCommonCore.Begin();
        // 附加样式
        this.AppendCss("css/index.css");
        //// 处理模板数据
        //await base.HandleTemplateData(_siteDefineDataCore, _sitePageDataCore, _topicDefineDataCore,
        //    _categoryDefineDataCore, _articleInfoDataCore);
        // 获取语言包
        var lpm = _lpmCommonCore.GetPackModule<MvcLpm>(Language);
        this.SetLanguagePack(lpm);
        Lpm = lpm;
        // 设置标题
        this.SetTitle(lpm.DellyNote);
        // 设置标志
        this.SetFlag(nameof(IndexModel));
        // 设置Banner图显示
        this.SetBannerVisible(true);
        // 判断是否登录
        var userCode = Session.GetString("UserCode");
        if (userCode.IsNullOrWhiteSpace())
        {
            this.SetLoginButtonVisible(true);
        }
        else
        {
            this.SetAddNoteButtonVisible(true);
        }
        Notes = await GetTopNotes();
    }

    // 获取最新产品
    private async Task<List<NoteQueryVo>> GetTopNotes()
    {
        var query = from n in _noteDataCore.Query()
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
        return await query.OrderByDescending(d => d.LastModificationTime).Take(6).ToListAsync();
    }

}