using DellyNote.Razor.Extension;
using DellyNote.Razor.Localization;
using DellyNote.Razor.Model;
using Jip.Kernel.Common.General.UnitOfWork;

namespace DellyNote.Razor.Pages;

/// <summary>
/// 主页
/// </summary>
public class LoginModel : BaseGenericPageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly UowCommonCore _uowCommonCore;
    private readonly LpmCommonCore _lpmCommonCore;

    /// <summary>
    /// 主页
    /// </summary>
    public LoginModel(
        ILogger<IndexModel> logger,
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
    /// 异步 Get
    /// </summary>
    /// <returns></returns>
    public async Task OnGetAsync()
    {
        //using var uow = _uowCommonCore.Begin();
        // 附加样式
        this.AppendCss("css/login.css");
        // 附加脚本
        this.AppendJs("js/login.js");
        //// 处理模板数据
        //await base.HandleTemplateData(_siteDefineDataCore, _sitePageDataCore, _topicDefineDataCore,
        //    _categoryDefineDataCore, _articleInfoDataCore);
        // 获取语言包
        var lpm = _lpmCommonCore.GetPackModule<MvcLpm>(Language);
        this.SetLanguagePack(lpm);
        Lpm = lpm;
        // 设置标题
        this.SetTitle(lpm.DellyNote);
        //// 设置标志
        //this.SetFlag(nameof(IndexModel));
        // 设置Banner图显示
        this.SetBannerVisible(true);
        // 设置标题
        this.SetTitle($"{lpm.Login} - {lpm.DellyNote}");
        // 设置按钮可见性
        this.SetAddNoteButtonVisible(false);
        this.SetLoginButtonVisible(false);
    }

}