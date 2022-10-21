using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rehber.DataAccess.Interfaces;
using Rehber.Models.DTOs;
using Rehber.Models;

namespace Rehber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IPersonDAL _personDAL;
        private readonly IEmailDAL _emailDAL;
        private readonly ILocationDAL _locationDAL;
        private readonly IPhoneNumberDAL _phoneNumberDAL;

        public EmailsController(IPersonDAL personDAL, IEmailDAL emailDAL, ILocationDAL locationDAL, IPhoneNumberDAL phoneNumberDAL)
        {
            _personDAL = personDAL;
            _emailDAL = emailDAL;
            _locationDAL = locationDAL;
            _phoneNumberDAL = phoneNumberDAL;
        }

        [HttpPost("add")]
        public IActionResult Add(int personId, string email)
        {
            if (ModelState.IsValid)
            {
                Email addedEmail = new Email()
                {
                    PersonID = personId,
                    Value = email
                };
                _emailDAL.Create(addedEmail);
               
                return Ok("Email başarıyla eklenmiştir");

            }
            return BadRequest("Gerekli alanları boş geçmeyiniz");

        }

        [HttpGet("getByPersonId")]
        public IActionResult GetByPersonId(int personId) // Kişinin Id si ile bütün mail adreslerini dönecek
        {
            var mail = _emailDAL.GetDefaults(a=>a.PersonID == personId);
            List<string> result = new List<string>();

            foreach (var item in mail)
            {
                result.Add(item.Value);
            }

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Kişi bulunamadı");
        }

        [HttpPost("update")]
        public IActionResult Update(int mailId, string email)
        {
            var updatedEmail = _emailDAL.GetDefault(a => a.ID == mailId);
            if (email == null)
            {
                return BadRequest("Mail bulunamadı");
            }
           updatedEmail.Value = email;

            _emailDAL.Update(updatedEmail);
            return Ok("Mail başarıyla güncellendi");

        }

        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var mail = _emailDAL.GetDefault(a => a.ID == id);
            if (mail == null)
            {
                return BadRequest("Mail bulunamadı");
            }
            _emailDAL.Delete(mail);
            return Ok("Mail başarıyla silindi");

            int adet = _emailDAL.GetDefaults(a => a.ID != 0).GroupBy(a=>a.Value).Count();
        }
    }
}
