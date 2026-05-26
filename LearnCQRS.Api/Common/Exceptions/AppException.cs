namespace LearnCQRS.Api.Common.Exceptions;

public abstract class AppException(string message, int statusCode) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
}

public class BadRequestException(string message) 
    : AppException(message, StatusCodes.Status400BadRequest);

public class UnauthorizedException(string message) 
    : AppException(message, StatusCodes.Status401Unauthorized);

public class ForbiddenException(string message) 
    : AppException(message, StatusCodes.Status403Forbidden);

public class NotFoundException(string message) 
    : AppException(message, StatusCodes.Status404NotFound);

public class MethodNotAllowedException(string message) 
    : AppException(message, StatusCodes.Status405MethodNotAllowed);

public class ConflictException(string message) 
    : AppException(message, StatusCodes.Status409Conflict);

public class UnprocessableEntityException(string message)
    : AppException(message, StatusCodes.Status422UnprocessableEntity);

public class TooManyRequestsException(string message) 
    : AppException(message, StatusCodes.Status429TooManyRequests);

public class InternalServerErrorException(string message)
    : AppException(message, StatusCodes.Status500InternalServerError);

public class ServiceUnavailableException(string message)
    : AppException(message, StatusCodes.Status503ServiceUnavailable);

public class AppInvalidOperationException(string message)
    : AppException(message, StatusCodes.Status500InternalServerError);