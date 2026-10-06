using System.ComponentModel.DataAnnotations;

namespace Polypus.Web.Models;

/// <summary>
/// Bound to the contact page form. Validation attributes drive the Blazor
/// <c>DataAnnotationsValidator</c> messages, so adding a rule here is enough -
/// no extra UI work is required.
/// </summary>
public sealed class ContactRequest
{
    [Required(ErrorMessage = "Please tell us your name.")]
    [StringLength(80, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 80 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "We need a work email to reply to.")]
    [EmailAddress(ErrorMessage = "That does not look like a valid email address.")]
    public string WorkEmail { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please add your company name.")]
    public string Company { get; set; } = string.Empty;

    [Required(ErrorMessage = "Select the plan you would like to discuss.")]
    public string PlanId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Roughly how many documents do you process each month?")]
    public string MonthlyVolume { get; set; } = string.Empty;

    [Required(ErrorMessage = "Select your SAP landscape.")]
    public string SapLandscape { get; set; } = string.Empty;

    [StringLength(1200, ErrorMessage = "Please keep this under 1200 characters.")]
    public string Message { get; set; } = string.Empty;

    public bool ConsentToContact { get; set; }

    /// <summary>Reference number shown after a successful submission.</summary>
    public string? Reference { get; set; }
}
