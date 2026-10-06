using Calid.Api.Models;

namespace Calid.Api.Services;

public interface ICalIdService
{
    /// <summary>Event types configured on the Cal.id account.</summary>
    Task<IReadOnlyList<EventTypeDto>> GetEventTypesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Availability between two dates, flattened to one entry per slot.
    /// Throws <see cref="CalIdValidationException"/> for missing or unparseable input.
    /// </summary>
    Task<IReadOnlyList<SlotDto>> GetAvailableSlotsAsync(
        string? startDate,
        string? endDate,
        int? eventTypeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Books a slot on Cal.id. Never throws for upstream failures; inspect
    /// <see cref="MeetingScheduleResponse.Success"/> instead.
    /// </summary>
    Task<MeetingScheduleResponse> BookMeetingAsync(
        MeetingScheduleRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirmed bookings on Cal.id.
    /// </summary>
    Task<IReadOnlyList<BookingDto>> GetBookingsAsync(CancellationToken cancellationToken = default);
}

