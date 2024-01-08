namespace DevFreela.Domain.Models;

public class PaginationResult<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public List<T> Data { get; set; }

    public PaginationResult() { }

    public PaginationResult(int page, int pageSize, int totalCount, int totalPages, List<T> data)
    {
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = totalPages;
        Data = data;
    }
}