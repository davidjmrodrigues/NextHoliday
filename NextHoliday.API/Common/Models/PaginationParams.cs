namespace NextHoliday.API.Common.Models
{
    public record struct PaginationParams
    (
        string? Search = null,
        int Page = 1,
        int PageSize = 50
    );
}
