using AutoMapper;
using Televizor.VolgaIronHack.Entities;

namespace Televizor.VolgaIronHack.DeliveryRequests;

public class DeliveryRequestMappingProfile : Profile
{
    public DeliveryRequestMappingProfile()
    {
        CreateMap<CreateDeliveryRequestCommand, DeliveryRequest>();
    }
}