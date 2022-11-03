using System.Collections.Generic;

namespace Domain.Models.Pagination;

public interface IPagedResponse<TModel>
{
    int PageNumber { get; set; }
    int PageSize { get; set; }
    int LastPage { get; set; }
    IReadOnlyCollection<TModel> Items { get; set; }
}