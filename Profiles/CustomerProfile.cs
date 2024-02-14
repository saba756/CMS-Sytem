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
            CreateMap<Customer, CustomerWriteDto>().ReverseMap();
            CreateMap<AddressTypes, AddressTypesDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CustomerAddresses, CustomerAddressDto>().ReverseMap()
                .ForMember(dest => dest.customerId, opt => opt.MapFrom(src => src.customerId))
                .ForMember(dest => dest.date_from, opt => opt.MapFrom(src => src.date_from))
                .ForMember(dest => dest.date_to, opt => opt.MapFrom(src => src.date_to))
                  .ForMember(dest => dest.address_id, opt => opt.MapFrom(src => src.address_id))
                .ForMember(dest => dest.address_type_code, opt => opt.MapFrom(src => src.address_type_code))
                //  .ForMember(dest => dest.addresses, act => act.Ignore());
                .ForPath(dest => dest.addresses.City, opt => opt.MapFrom(src => src.addresses.City))
                .ForPath(dest => dest.addresses.FirstName, opt => opt.MapFrom(src => src.addresses.FirstName))
                .ForPath(dest => dest.addresses.LastName, opt => opt.MapFrom(src => src.addresses.LastName))
                .ForPath(dest => dest.addresses.Street, opt => opt.MapFrom(src => src.addresses.Street))
                .ForPath(dest => dest.addresses.ZipCode, opt => opt.MapFrom(src => src.addresses.ZipCode))
                .ForPath(dest => dest.addresses.State, opt => opt.MapFrom(src => src.addresses.State));
                //.ForMember(dest => dest.addresses.address_id, opt => opt.MapFrom(src => src.addresses.address_id));
            

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
