namespace NextHoliday.Application.Common.Parameters
{
    public record PagedRequest
    {
        public string? Search { get; init; } = null;
        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 50;
    }
}
