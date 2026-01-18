using DellyNote.Common.Kernel.Document.Note.Dto;
using DellyNote.Common.Kernel.Document.Note.Vo;
using Jip.Define.Data.Vo;
using Jip.Kernel.Common.General.Exception;
using Jip.Kernel.Common.General.ObjectMap;
using Jip.WebApi.Kernel.App.General;
using Microsoft.AspNetCore.Mvc;
using Nuo.Extension;
using Nuo.WebApi.Jwt.Attribute;

namespace DellyNote.App.Kernel.Document;

/// <summary>
/// 笔记
/// </summary>
//[JwtAuthorize]
public sealed class NoteApp(
    NoteCore noteCore,
    MapCommonCore mapCommonCore,
    ExceptionCommonCore exceptionCommonCore
    ) : BaseModuleAppService
{

    #region 依赖注入

    private readonly NoteCore _noteCore = noteCore;
    private readonly MapCommonCore _mapCommonCore = mapCommonCore;
    private readonly ExceptionCommonCore _exceptionCommonCore = exceptionCommonCore;

    #endregion

    #region 新增

    /// <summary>
    /// 新增 笔记
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<NoteVo> Insert(NoteInsertDto dto)
    {
        var data = _mapCommonCore.Map<DellyNote.Common.Kernel.Document.Entity.Note>(dto);
        await _noteCore.Insert(data);
        return _mapCommonCore.Map<NoteVo>(data);
    }

    /// <summary>
    /// 批量新增 笔记
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task BatchInsert(List<NoteInsertDto> dto)
    {
        var data = _mapCommonCore.MapList<DellyNote.Common.Kernel.Document.Entity.Note>(dto);
        await _noteCore.InsertList(data);
    }

    #endregion

    #region 删除

    /// <summary>
    /// 删除 笔记
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(string id)
    {
        if (id.IsNullOrWhiteSpace()) { throw _exceptionCommonCore.FieldRequired("ID"); }
        await _noteCore.Delete(id);
    }

    /// <summary>
    /// 批量删除 笔记
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task BatchDelete(List<string> ids)
    {
        if (!ids.Any()) { throw _exceptionCommonCore.FieldRequired("ID"); }
        await _noteCore.DeleteList(ids);
    }

    #endregion

    #region 修改

    /// <summary>
    /// 修改 笔记
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task Update(NoteUpdateDto dto)
    {
        var data = await _noteCore.GetDataById(dto.Id);
        _mapCommonCore.Map(dto, data);
        await _noteCore.Update(data);
    }

    #endregion

    #region 查询

    /// <summary>
    /// 获取 笔记
    /// </summary>
    /// <returns></returns>
    public async Task<NoteVo> Get(string id)
    {
        if (id.IsNullOrWhiteSpace()) { throw _exceptionCommonCore.FieldRequired("ID"); }
        var data = await _noteCore.GetDataById(id);
        return _mapCommonCore.Map<NoteVo>(data);
    }

    /// <summary>
    /// 查找 笔记
    /// </summary>
    /// <returns></returns>
    public async Task<NoteVo?> Find(NoteFindDto dto)
    {
        var data = await _noteCore.FindData(dto);
        return data is null ? null : _mapCommonCore.Map<NoteVo>(data);
    }

    /// <summary>
    /// 查询 笔记 集合
    /// </summary>
    /// <returns></returns>
    public async Task<List<NoteVo>> Query(NoteQueryDto dto)
    {
        var datas = await _noteCore.QueryDatas(dto);
        return _mapCommonCore.MapList<NoteVo>(datas);
    }

    /// <summary>
    /// 分页查询 笔记 集合
    /// </summary>
    /// <returns></returns>
    public async Task<PagedVo<NoteVo>> Page(NotePagedDto dto)
    {
        var dataPaged = await _noteCore.QueryPagedDatas(dto);
        var paged = new PagedVo<NoteVo>(dataPaged);
        paged.Rows = _mapCommonCore.MapList<NoteVo>(dataPaged.Rows);
        return paged;
    }

    #endregion

}
