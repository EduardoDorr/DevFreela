using Microsoft.EntityFrameworkCore;

using DevFreela.Domain.Models;

namespace DevFreela.Infrastructure.Persistence.Extensions;

public static class Extensions
{
    public static async Task<PaginationResult<T>> GetPaged<T>(
        this IQueryable<T> query,
        int page,
        int pageSize) where T : class
    {
        var result = new PaginationResult<T>();
        result.Page = page;
        result.PageSize = pageSize;
        result.TotalCount = await query.CountAsync();

        var pageCount = (double)result.TotalCount / pageSize;
        result.TotalPages = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * pageSize;

        result.Data = await query.Skip(skip).Take(pageSize).ToListAsync();

        return result;
    }
}