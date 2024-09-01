using CSharpFunctionalExtensions;
using FluentValidation;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Application.Validation;

public static class CustomValidation
{
    public static IRuleBuilderOptionsConditions<T, TElement> MustBeValueObject<T, TElement, TValueObject>(
        this IRuleBuilder<T, TElement> ruleBuilder, 
        Func<TElement, Result<TValueObject, Error>> createFunc)
    {
        return ruleBuilder.Custom((item, context) =>
        {
            Result<TValueObject, Error> result = createFunc(item);

            if (result.IsSuccess)
                return;

            context.AddFailure(result.Error.Serialize());
        });
    }

    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
    this IRuleBuilderOptions<T, TProperty> rule, Error error)
    {
        return rule.WithMessage(error.Serialize());
    }
}
