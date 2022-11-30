// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Application > ValidationBehaviors.cs
// Created: 23 11, 2022
// Modified: 23 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using FluentValidation;
using FluentValidation.Results;

using MediatR;

namespace BuberDinner.Application.Common.Behaviors;

public class AbstractValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public AbstractValidationBehavior(IValidator<TRequest>? validator = null) => _validator = validator;

    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest          request, RequestHandlerDelegate<TResponse> next,
                                        CancellationToken cancellationToken)
    {
        if (_validator is null) { return await next(); }

        ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        return (dynamic) validationResult.Errors.ConvertAll(validationFailure => Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
    }
}
