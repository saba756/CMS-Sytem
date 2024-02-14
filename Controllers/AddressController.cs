using AutoMapper;
using CMS.Data;
using CMS.Dto;
using CMS.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddress _repository;
        private readonly IMapper _mapper;

        public AddressController(IAddress repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        [HttpGet("{id}", Name = "GetCustomerAddressesById")]
        public ActionResult<IEnumerable<AddressDto>> GetCustomerAddressesById(int id)
        {
            var addresses = _repository.GetAddressesByCustomerId(id);
            return Ok(_mapper.Map<IEnumerable<AddressDto>>(addresses));
        }
        [Authorize]
        [HttpPost]
        public ActionResult<CustomerAddressDto> CreateCustomerAddress(CustomerAddressDto customerAddressDto)
        {
            var customerAddress = _mapper.Map<CustomerAddresses>(customerAddressDto);
            _repository.CreateCustomerAddress(customerAddress);
            _repository.SaveChanges();
            //var commandReadDto = _mapper.Map<CustomerAddressDto>(customerAddress);
            customerAddressDto.address_id = customerAddress.address_id;
            
            return Ok(customerAddressDto);
        }
       
    }
}
