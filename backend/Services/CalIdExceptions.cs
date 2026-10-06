namespace Calid.Api.Services;

/// <summary>
/// The caller supplied something Cal.id cannot use. Surfaces as HTTP 400.
/// </summary>
public class CalIdValidationException : Exception
{
    public CalIdValidationException(string message) : base(message)
    {
    }
}

/// <summary>
/// The upstream Cal.id call failed. Carries Cal.id's raw error body so the
/// controller can pass the details straight back to the client.
/// </summary>
public class CalIdApiException : Exception
{
    public CalIdApiException(string message, string responseBody) : base(message)
    {
        ResponseBody = responseBody;
    }

    public string ResponseBody { get; }
}
