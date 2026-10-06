namespace Calid.Api.Models;

/// <summary>
/// Cal.id connection settings, bound from the "CalId" section of configuration.
/// </summary>
public class CalIdOptions
{
    public const string SectionName = "CalId";

    public string ApiKey { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string EventSlug { get; set; } = string.Empty;

    public int EventTypeId { get; set; }

    public string TimeZone { get; set; } = "Asia/Kolkata";

    public string ApiBaseUrl { get; set; } = "https://api.cal.id";

    public int BaseBookingDurationMinutes { get; set; } = 15;

    /// <summary>
    /// Cal.id attaches the Google Meet link a moment after the booking is created, so the
    /// confirmation is re-read up to this many times (waiting <see cref="VideoLinkPollDelayMs"/>
    /// between attempts) to include it.
    /// </summary>
    public int VideoLinkPollAttempts { get; set; } = 3;

    public int VideoLinkPollDelayMs { get; set; } = 1000;

    /// <summary>
    /// Browser origins allowed by CORS. Any port on localhost / 127.0.0.1 is allowed
    /// when <see cref="AllowLocalhostOrigins"/> is true.
    /// </summary>
    public string[] AllowedOrigins { get; set; } = [];

    public bool AllowLocalhostOrigins { get; set; } = true;

    public bool HasApiKey =>
        !string.IsNullOrWhiteSpace(ApiKey) &&
        !ApiKey.Contains("your_cal_id_api_key", StringComparison.OrdinalIgnoreCase);

    public bool HasUsername => !string.IsNullOrWhiteSpace(Username);
}
