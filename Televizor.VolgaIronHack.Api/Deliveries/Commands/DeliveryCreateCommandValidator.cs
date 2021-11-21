using FluentValidation;

namespace Televizor.VolgaIronHack.Deliveries.Commands;

public class DeliveryCreateCommandValidator : AbstractValidator<DeliveryCreateCommand>
{
    private const string RequiredFieldMessage = "required field";
    
    public DeliveryCreateCommandValidator()
    {
        RuleFor(command => command.KeeperId)
            .NotEmpty()
                .WithMessage(RequiredFieldMessage);
        
        RuleFor(command => command.DeliveryRequestId)
                .NotEmpty()
            .WithMessage(RequiredFieldMessage);
        
        RuleFor(command => command.KeeperId)
            .NotEmpty()
                .WithMessage(RequiredFieldMessage);
    }
}