using AutoMapper;
using Televizor.VolgaIronHack.Deliveries.Views;

namespace Televizor.VolgaIronHack.Deliveries;

public class DeliveryMappingProfile : Profile
{
    public DeliveryMappingProfile()
    {
        CreateMap<Entities.Delivery, DeliverySetViewItem>();
    }
}
