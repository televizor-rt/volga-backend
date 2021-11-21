using AutoMapper;
using Televizor.VolgaIronHack.Deliveries.Commands;
using Televizor.VolgaIronHack.Deliveries.Views;
using Televizor.VolgaIronHack.Entities;

namespace Televizor.VolgaIronHack.Deliveries;

public class DeliveryMappingProfile : Profile
{
    public DeliveryMappingProfile()
    {
        CreateMap<Entities.Delivery, DeliverySetViewItem>();
        CreateMap<DeliveryCreateCommand, Delivery>();
    }
}
