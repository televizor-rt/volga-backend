using FluentValidation;

namespace Televizor.VolgaIronHack.DeliveryRequests;

public class CreateDeliveryRequestCommandValidator : AbstractValidator<CreateDeliveryRequestCommand>
{
    public CreateDeliveryRequestCommandValidator(IServiceProvider services)
    {

    }
}