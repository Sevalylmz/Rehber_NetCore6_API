using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rehber.DataAccess.Interfaces;
using Rehber.Models;
using Rehber.Models.DTOs;


namespace Rehber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonDAL _personDAL;
        private readonly IEmailDAL _emailDAL;
        private readonly ILocationDAL _locationDAL;
        private readonly IPhoneNumberDAL _phoneNumberDAL;

        public PersonsController(IPersonDAL personDAL, IEmailDAL emailDAL, ILocationDAL locationDAL, IPhoneNumberDAL phoneNumberDAL)
        {
            _personDAL = personDAL;
            _emailDAL = emailDAL;
            _locationDAL = locationDAL;
            _phoneNumberDAL = phoneNumberDAL;
        }

        [HttpPost("add")]
        public IActionResult Add(AddPersonDTO dto)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Company = dto.Company,
                };

                _personDAL.Create(person); // Öncelikle person oluşturulur ve oluşturulan bi personun ID si ile diğer entityler oluşturulur
                Email email = new Email()
                {
                    PersonID = person.ID,
                    Value = dto.Email
                };

                _emailDAL.Create(email);

                Location location = new Location()
                {
                    PersonID = person.ID,
                    Value = dto.Location
                };

                _locationDAL.Create(location);

                PhoneNumber phoneNumber = new PhoneNumber()
                {
                    PersonID = person.ID,
                    Value = dto.PhoneNumber
                };

                _phoneNumberDAL.Create(phoneNumber);
                return Ok("Kişi başarıyla eklenmiştir");

            }
            return BadRequest("Gerekli alanları boş geçmeyiniz");

        }

        [HttpGet("getById")]
        public IActionResult GetById(int id) // 1 kişinin bilgilerinin getiirlmesi
        {
            var person = _personDAL.GetDefault(a => a.ID == id);
            var mail = _emailDAL.GetDefaults(a => a.PersonID == person.ID);
            GetByIdPersonDTO result = new GetByIdPersonDTO()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Company = person.Company,
            };


            foreach (var item in person.Emails)
            {
                result.Email.Add(item.Value);
            }

            foreach (var item in person.Locations)
            {
                result.Location.Add(item.Value);
            }


            foreach (var item in person.PhoneNumbers)
            {
                result.PhoneNumber.Add(item.Value);
            }



            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Kişi bulunamadı");
        }

        [HttpPost("update")]
        public IActionResult Update(UpdatePersonDTO dto)
        {
         var person =   _personDAL.GetDefault(a => a.ID == dto.Id);
            if (person == null)
            {
                return BadRequest("Kişi bulunamadı");
            }
            person.FirstName = dto.FirstName;
            person.LastName = dto.LastName;
            person.Company = dto.Company;

            _personDAL.Update(person);
            return Ok("Kişi başarıyla güncellendi");

        }

        [HttpGet("delete") ]
        public IActionResult Delete(int id)
        {
            var person = _personDAL.GetDefault(a => a.ID == id);
            if(person == null)
            {
                return BadRequest("Kişi bulunamadı");
            }
            _personDAL.Delete(person);
            return Ok("Kişi başarıyla silindi");
        }


    }
}
