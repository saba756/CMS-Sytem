using AutoMapper;
using CMS.Dto;
using CMS.Model;

namespace CMS.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //Source -> Target
            CreateMap<Customer, CustomerDto>().ReverseMap();
          
            //      .ForMember(dest => dest.customerId, opt => opt.MapFrom(src => src.customerId))
            //.ForMember(dest => dest.customer_name, opt => opt.MapFrom(src => src.customer_name))
            //.ForMember(dest => dest.customer_email, opt => opt.MapFrom(src => src.customer_email))
            //.ForMember(dest => dest.customer_phone, opt => opt.MapFrom(src => src.customer_phone))
            //.ForMember(dest => dest.payment_method_code, opt => opt.MapFrom(src => src.payment_method_code))
            //.ForMember(dest => dest.payment_detail, opt => opt.MapFrom(src => src.payment_detail))
            //.ForMember(dest => dest.other_payment_detail, opt => opt.MapFrom(src => src.other_payment_detail));

        }


    }
}
