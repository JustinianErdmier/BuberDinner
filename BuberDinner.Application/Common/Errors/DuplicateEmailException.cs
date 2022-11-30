using System.Net;

namespace BuberDinner.Application.Common.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    /// <inheritdoc />
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    /// <inheritdoc />
    /// <remarks>
    ///     This might be a security issue: if someone is just guessing email addresses, they can find out if an account
    ///     exists or not. Depending on your security requirements, you might want to return a generic error message to be
    ///     displayed.
    /// </remarks>
    public string ErrorMessage => "Email already exists";
}
