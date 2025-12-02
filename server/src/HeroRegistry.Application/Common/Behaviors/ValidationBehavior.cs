using FluentValidation;
using MediatR;

namespace HeroRegistry.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(e => e != null)
                .ToList();

            if (errors.Count != 0)
            {
                var messages = string.Join(", ", errors.Select(e => e.ErrorMessage));
                throw new ValidationException(messages);
            }
        }

        return await next();
    }
}
