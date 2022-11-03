using System.Collections.Generic;
using System.Collections.Immutable;

namespace Domain.Models.Pagination;

public class PagedResponse<TModel> : IPagedResponse<TModel>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int LastPage { get; set; }
    public IReadOnlyCollection<TModel?> Items { get; set; } = ImmutableList<TModel>.Empty;

    public static PagedResponse<TModel> Create(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<TModel?> items)
    {
        return new PagedResponse<TModel>
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            LastPage = lastPage,
            Items = items
        };
    }
}