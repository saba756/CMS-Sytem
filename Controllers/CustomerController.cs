using AutoMapper;
using CMS.Data;
using CMS.Dto;
using CMS.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CMS.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _repository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }
        //GET api
        [Authorize]
        [HttpGet]
        public  ActionResult<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var CustomerDto =  _repository.GetAllCustomers();
           return Ok(_mapper.Map<IEnumerable<Customer>>(CustomerDto));
        }
        //GET api/commands/{id}
       
        [HttpGet("{id}", Name = "GetCustomerById")]
        public ActionResult<CustomerDto> GetGustomerById(int id)
        {
            var commandItem = _repository.GetCustomerId(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CustomerDto>(commandItem));
            }
            return NotFound();
        }


        //POST api/commands
   
        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            var customerModel = _mapper.Map<Customer>(customerDto);
            _repository.CreateCustomer(customerModel);
            _repository.SaveChanges();
            var commandReadDto = _mapper.Map<CustomerDto>(customerModel);

            return Ok(commandReadDto);
        }


        //PUT api/commands/{id}
  
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customerModelFromRepo = _repository.GetCustomerId(id);
            if (customerModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(customerDto, customerModelFromRepo);

            _repository.UpdateCustomer(customerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        

        //PATCH api/customer/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCustomerUpdate(int id, JsonPatchDocument<CustomerDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCustomerId(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CustomerDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCustomer(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/customer/{id}

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var commandModelFromRepo = _repository.GetCustomerId(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCustomer(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
