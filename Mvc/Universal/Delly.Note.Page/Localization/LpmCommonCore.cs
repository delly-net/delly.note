using Jip.Common.Atom;
using Nuo.Localization.Modular;
using Nuo.Localization.Modular.Dependency;
using Nuo.Localization.Modular.Extension;

namespace Delly.Note.Razor.Localization;

/// <summary>
/// 模块化语言包 通用核心
/// </summary>
public sealed class LpmCommonCore : BaseGenericCommonCore
{
    private readonly ILocalizationFactory _localizationFactory;

    /// <summary>
    /// 模块化语言包 通用核心
    /// </summary>
    public LpmCommonCore(
        ILocalizationFactory localizationFactory
    )
    {
        _localizationFactory = localizationFactory;
    }

    /// <summary>
    /// 获取模块语言包
    /// </summary>
    /// <param name="language"></param>
    /// <param name="moduleType"></param>
    /// <returns></returns>
    public ILanguagePackModule GetPackModule(string language, Type moduleType)
    {
        var languagePack = (ModularLanguagePack)_localizationFactory.GetLanguagePack(language);
        return languagePack.GetModulePack(moduleType);
    }

    /// <summary>
    /// 获取模块语言包
    /// </summary>
    /// <param name="language"></param>
    /// <returns></returns>
    public TPackModule GetPackModule<TPackModule>(string language)
    {
        var type = typeof(TPackModule);
        return (TPackModule)GetPackModule(language, type);
    }
}