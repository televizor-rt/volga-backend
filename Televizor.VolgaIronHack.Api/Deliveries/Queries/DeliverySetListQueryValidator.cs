using FluentValidation;
using Televizor.VolgaIronHack.Deliveries.Queries;

namespace Televizor.VolgaIronHack.Parcels.Queries;

public class DeliverySetListQueryValidator : AbstractDeliverySetQueryValidator<DeliveryListQuery>
{
    public DeliverySetListQueryValidator()
    {
        RuleFor(query => query.Statuses)
            .ForEach(col => col.IsInEnum());
    }
}