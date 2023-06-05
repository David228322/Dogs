namespace Dogs.Application.Models;

/// <summary>
/// Represents an error response.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    public string ErrorCode { get; set; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the dictionary of validation errors.
    /// The key represents the property name, and the value represents the array of error messages for that property.
    /// </summary>
    public IDictionary<string, string[]> ValidationErrors { get; set; }
}

