using AutoMapper;
using WaterBill.DAL.Data.Entities;
using WaterBill.PL.ViewModels;

namespace WaterBill.PL.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RrealEstateType, RrealEstateDto>().ReverseMap();

            CreateMap<Subscriber, SubscriberDto>().ReverseMap();

            CreateMap<Subscription, SubscriptionDto>().ReverseMap();


            CreateMap<Subscriber, SubscriberToReturnDto>()
                .ForMember(D=>D.NumberOfSubscriptions,O=>O.MapFrom(S=>S.SubscriptionFiles.Count));


            CreateMap<Subscription, SubscriptionToReturnDto>()
                .ForMember(D=>D.SubscriberName,O=>O.MapFrom(S=>S.Subscriber.Name))
                .ForMember(D=>D.Mobile,O=>O.MapFrom(S=>S.Subscriber.Mobile))
                .ForMember(D=>D.RrealEstateName, O=>O.MapFrom(S=>S.RrealEstateType.Name));

            CreateMap<Invoice, InvoiceDto>().
                ForMember(D=>D.SubscriberName,O=>O.MapFrom(S=>S.Subscriber.Name));

            CreateMap< InvoiceDto, Invoice>();
        }
    }
}
