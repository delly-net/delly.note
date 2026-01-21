using DellyNote.Common.Kernel.Document;
using DellyNote.Common.Kernel.Document.Note.Dto;
using Jip.Common.Data.Extension;
using Jip.Define.Data.Vo;
using Jip.Kernel.Common.General.Exception;
using Jip.WebApi.Service.Atom;
using Microsoft.AspNetCore.Http;
using Nuo.Data.Expression.Delete.Extension;
using Nuo.Data.General.Extension;
using Nuo.Extension;

namespace DellyNote.App.Kernel.Document;

/// <summary>
/// 笔记 服务核心
/// </summary>
public sealed class NoteCore(
    ExceptionCommonCore exceptionCommonCore,
    NoteDataCore noteDataCore,
    IHttpContextAccessor httpContextAccessor
    ) : BaseGenericServiceCore
{
    #region 依赖注入

    private readonly ExceptionCommonCore _exceptionCommonCore = exceptionCommonCore;
    private readonly NoteDataCore _noteDataCore = noteDataCore;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    #endregion

    #region 新增

    /// <summary>
    /// 新增 笔记
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task Insert(DellyNote.Common.Kernel.Document.Entity.Note data)
    {
        await _noteDataCore.InsertAsync(data);
    }

    /// <summary>
    /// 新增 笔记 集合
    /// </summary>
    /// <param name="datas"></param>
    /// <returns></returns>
    public async Task InsertList(List<DellyNote.Common.Kernel.Document.Entity.Note> datas)
    {
        await _noteDataCore.InsertListAsync(datas);
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
        await _noteDataCore.Delete().Where(d => d.Id == id).ExecuteAsync();
    }

    /// <summary>
    /// 删除 笔记 集合
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public async Task DeleteList(List<string> ids)
    {
        await _noteDataCore.Delete().Where(d => ids.Contains(d.Id)).ExecuteAsync();
    }

    #endregion

    #region 修改

    /// <summary>
    /// 修改 笔记
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task Update(DellyNote.Common.Kernel.Document.Entity.Note data)
    {
        await _noteDataCore.UpdateAsync(data);
    }

    #endregion 

    #region 查询

    /// <summary>
    /// 获取 笔记
    /// </summary>
    /// <returns></returns>
    public async Task<DellyNote.Common.Kernel.Document.Entity.Note> GetDataById(string id)
    {
        var data = await _noteDataCore.GetEntityAsync(id);
        return data ?? throw _exceptionCommonCore.NotAvailable("ID", id);
    }

    /// <summary>
    /// 获取 笔记
    /// </summary>
    /// <returns></returns>
    public async Task<DellyNote.Common.Kernel.Document.Entity.Note?> GetDataOrNullById(string id)
    {
        return await _noteDataCore.GetEntityAsync(id);
    }

    /// <summary>
    /// 查找 笔记
    /// </summary>
    /// <returns></returns>
    public async Task<DellyNote.Common.Kernel.Document.Entity.Note?> FindData(NoteFindDto dto)
    {
        var query = _noteDataCore.Query();
        query = query.WhereIf(!dto.Title.IsNullOrWhiteSpace(), d => d.Title == dto.Title);
        query = query.WhereIf(!dto.NoteType.IsNullOrWhiteSpace(), d => d.NoteType == dto.NoteType);
        return await query.FirstOrDefaultAsync();
    }

    /// <summary>
    /// 查询 笔记 集合
    /// </summary>
    /// <returns></returns>
    public async Task<List<DellyNote.Common.Kernel.Document.Entity.Note>> QueryDatas(NoteQueryDto dto)
    {
        var query = _noteDataCore.Query();
        query = query.WhereIf(!dto.Title.IsNullOrWhiteSpace(), d => d.Title.Contains(dto.Title!));
        query = query.WhereIf(!dto.NoteType.IsNullOrWhiteSpace(), d => d.NoteType == dto.NoteType);
        return await query.ToListAsync();
    }

    /// <summary>
    /// 分页查询 笔记 集合
    /// </summary>
    /// <returns></returns>
    public async Task<PagedVo<DellyNote.Common.Kernel.Document.Entity.Note>> QueryPagedDatas(NotePagedDto dto)
    {
        // 建立查询
        var query = _noteDataCore.Query();
        query = query.WhereIf(!dto.Title.IsNullOrWhiteSpace(), d => d.Title.Contains(dto.Title!));
        query = query.WhereIf(!dto.NoteType.IsNullOrWhiteSpace(), d => d.NoteType == dto.NoteType);
        // 获取总行数
        var rowCount = await query.CountAsync();
        // 执行分页查询并返回
        var paged = new PagedVo<DellyNote.Common.Kernel.Document.Entity.Note>(dto)
        {
            RowCount = rowCount,
            Rows = await query.Paged(dto).ToListAsync(),
        };
        return paged;
    }

    #endregion

}
