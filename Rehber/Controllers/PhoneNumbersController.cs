using Microsoft.AspNetCore.Mvc;
using Rehber.DataAccess.Interfaces;
using Rehber.Models;

namespace Rehber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumbersController : ControllerBase
    {
        
        private readonly IPhoneNumberDAL _phoneNumberDAL;
        


        public PhoneNumbersController(IPhoneNumberDAL phoneNumberDAL)
        {
            

            _phoneNumberDAL = phoneNumberDAL;

        }

        [HttpPost("add")]
        public IActionResult Add(int personId, string phoneNumber)
        {
            if (ModelState.IsValid)
            {
                PhoneNumber addedPhoneNumber = new PhoneNumber()
                {
                    PersonID = personId,
                    Value = phoneNumber,
                };
                _phoneNumberDAL.Create(addedPhoneNumber);

                return Ok("Telefon numarası başarıyla eklenmiştir");

            }
            return BadRequest("Gerekli alanları boş geçmeyiniz");

        }

        [HttpGet("getByPersonId")]
        public IActionResult GetByPersonId(int personId) // Kişinin Id si ile bütün lokasyon adreslerini dönecek
        {
            var phoneNumber = _phoneNumberDAL.GetDefaults(a => a.PersonID == personId);
            List<string> result = new List<string>();

            foreach (var item in phoneNumber)
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
        public IActionResult Update(int phoneNumberId, string phoneNumber)
        {
            var updatedPhoneNumber = _phoneNumberDAL.GetDefault(a => a.ID == phoneNumberId);
            if (phoneNumber == null)
            {
                return BadRequest("telefon numarası bulunamadı");
            }
            updatedPhoneNumber.Value = phoneNumber;

            _phoneNumberDAL.Update(updatedPhoneNumber);
            return Ok("Telefon numarası başarıyla güncellendi");

        }

        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var phoneNumber = _phoneNumberDAL.GetDefault(a => a.ID == id);
            if (phoneNumber == null)
            {
                return BadRequest("Lokasyon bulunamadı");
            }
            _phoneNumberDAL.Delete(phoneNumber);
            return Ok("telefon numarası başarıyla silindi");

         
        }
    }
}
