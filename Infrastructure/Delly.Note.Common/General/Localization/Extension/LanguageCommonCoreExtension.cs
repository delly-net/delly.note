using Jip.Common.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DellyNote.Common.General.Localization.Extension;

/// <summary>
/// 语言通用核心 扩展
/// </summary>
public static class LanguageCommonCoreExtension
{
    /// <summary>
    /// 获取平台内核语言包
    /// </summary>
    /// <param name="languageCommonCore"></param>
    /// <returns></returns>
    public static DellyNoteLpm GetDellyNote(this LanguageCommonCore languageCommonCore)
    {
        return languageCommonCore.GetPackModule<DellyNoteLpm>();
    }
}
