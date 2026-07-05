using MediatR;

namespace NextHoliday.Application.Features.Admin.Commands.SyncHistoricalClimate;

public record SyncHistoricalClimateCommand : IRequest<SyncHistoricalClimateResponse>;

public record SyncHistoricalClimateResponse(bool Success, int TotalSynced, string Message);