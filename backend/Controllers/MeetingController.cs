using Calid.Api.Models;
using Calid.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calid.Api.Controllers;

/// <summary>
/// HTTP surface for the meeting scheduler. The controller only validates the
/// request shape and maps service results/errors to status codes; every Cal.id
/// concern lives in <see cref="ICalIdService"/>.
/// </summary>
[ApiController]
[Route("api/meeting")]
public class MeetingController : ControllerBase
{
    private readonly ICalIdService _calIdService;
    private readonly ILogger<MeetingController> _logger;

    public MeetingController(ICalIdService calIdService, ILogger<MeetingController> logger)
    {
        _calIdService = calIdService;
        _logger = logger;
    }

    /// <summary>
    /// GET /api/meeting/event-types
    /// Returns the list of configured event types (durations and slugs) from Cal.id.
    /// Frontend filters these to show only public booking options (e.g. 15-min and 30-min).
    /// </summary>
    [HttpGet("event-types")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<IActionResult> GetEventTypes(CancellationToken cancellationToken)
    {
        try
        {
            var eventTypes = await _calIdService.GetEventTypesAsync(cancellationToken);
            return Ok(new { eventTypes });
        }
        catch (CalIdApiException ex)
        {
            _logger.LogError(ex, "Failed to fetch event types from Cal.id");
            return BadGateway("Failed to fetch event types from Cal.id.", ex);
        }
    }

    /// <summary>
    /// GET /api/meeting/available-slots?startDate=YYYY-MM-DD&amp;endDate=YYYY-MM-DD&amp;eventTypeId=111709
    /// Queries Cal.id for raw time slots within the requested date window. The service normalizes
    /// and flattens Cal.id's grouped date dictionary into a simple list of slots.
    /// </summary>
    [HttpGet("available-slots")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<IActionResult> GetAvailableSlots(
        [FromQuery] string? startDate,
        [FromQuery] string? endDate,
        [FromQuery] int? eventTypeId,
        CancellationToken cancellationToken)
    {
        try
        {
            var slots = await _calIdService.GetAvailableSlotsAsync(startDate, endDate, eventTypeId, cancellationToken);
            return Ok(new { slots });
        }
        catch (CalIdValidationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (CalIdApiException ex)
        {
            _logger.LogError(ex, "Failed to fetch available slots from Cal.id");
            return BadGateway("Failed to fetch available slots from Cal.id.", ex);
        }
    }

    /// <summary>
    /// GET /api/meeting/bookings
    /// Fetches existing bookings so the caller can perform schedule overlap and conflict checks.
    /// </summary>
    [HttpGet("bookings")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<IActionResult> GetBookings(CancellationToken cancellationToken)
    {
        try
        {
            var bookings = await _calIdService.GetBookingsAsync(cancellationToken);
            return Ok(new { bookings });
        }
        catch (CalIdApiException ex)
        {
            _logger.LogError(ex, "Failed to fetch bookings from Cal.id");
            return BadGateway("Failed to fetch bookings from Cal.id.", ex);
        }
    }

    /// <summary>
    /// POST /api/meeting/book
    /// Submits a booking request to Cal.id. CalIdService handles upstream creation and
    /// subsequent polling for video link generation (Google Meet) before returning the response.
    /// Note: This operation can take several seconds due to video link polling; clients must allow
    /// a sufficient timeout (e.g. 30 seconds) rather than treating latency as a failure.
    /// </summary>
    [HttpPost("book")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<IActionResult> BookMeeting(
        [FromBody] MeetingScheduleRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _calIdService.BookMeetingAsync(request, cancellationToken);

            if (!result.Success)
            {
                _logger.LogError("Cal.id rejected the booking: {Details}", result.Details?.ToJsonString());
                return BadGateway(result.Message!, result.Details?.ToJsonString());
            }

            return Ok(new { message = result.Message, booking = result.Booking });
        }
        catch (CalIdValidationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (CalIdApiException ex)
        {
            _logger.LogError(ex, "Failed to book the meeting on Cal.id");
            return BadGateway("Failed to book the meeting on Cal.id.", ex);
        }
    }

    private ObjectResult BadGateway(string error, string? responseBody) =>
        StatusCode(StatusCodes.Status502BadGateway, new
        {
            error,
            details = ParseDetails(responseBody)
        });

    private ObjectResult BadGateway(string error, CalIdApiException ex) =>
        BadGateway(error, ex.ResponseBody);

    private static object? ParseDetails(string? body)
    {
        if (string.IsNullOrWhiteSpace(body))
        {
            return null;
        }

        try
        {
            return System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(body);
        }
        catch (System.Text.Json.JsonException)
        {
            return body;
        }
    }
}
