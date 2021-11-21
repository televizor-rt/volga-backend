using FluentValidation;

namespace Televizor.VolgaIronHack.Parcels.Queries;

public abstract class AbstractDeliverySetQueryValidator<T> : AbstractValidator<T>
    where T : AbstractDeliverySetQuery
{
    protected AbstractDeliverySetQueryValidator()
    {
        RuleFor(query => query.Direction).IsInEnum();
    }
}