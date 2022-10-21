using Microsoft.AspNetCore.Mvc;
using Rehber.DataAccess.Interfaces;
using Rehber.Models;

namespace Rehber.Controllers
{
    
    
        [Route("api/[controller]")]
        [ApiController]
        public class LocationsController : ControllerBase
        {
            private readonly IPersonDAL _personDAL;
            
            private readonly ILocationDAL _locationDAL;
            

            public LocationsController(  ILocationDAL locationDAL)
            {
                
                
                _locationDAL = locationDAL;
                
            }

            [HttpPost("add")]
            public IActionResult Add(int personId, string location)
            {
                if (ModelState.IsValid)
                {
                    Location addedLocation = new Location()
                    {
                        PersonID = personId,
                        Value = location
                    };
                    _locationDAL.Create(addedLocation);

                    return Ok("Lokasyon başarıyla eklenmiştir");

                }
                return BadRequest("Gerekli alanları boş geçmeyiniz");

            }

            [HttpGet("getByPersonId")]
            public IActionResult GetByPersonId(int personId) // Kişinin Id si ile bütün lokasyon adreslerini dönecek
            {
                var location = _locationDAL.GetDefaults(a => a.PersonID == personId);
                List<string> result = new List<string>();

                foreach (var item in location)
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
            public IActionResult Update(int locationId, string location)
            {
                var updatedLocation = _locationDAL.GetDefault(a => a.ID == locationId);
                if (location == null)
                {
                    return BadRequest("Lokasyon bulunamadı");
                }
                updatedLocation.Value = location;

                _locationDAL.Update(updatedLocation);
                return Ok("Lokasyon başarıyla güncellendi");

            }

            [HttpGet("delete")]
            public IActionResult Delete(int id)
            {
                var location = _locationDAL.GetDefault(a => a.ID == id);
                if (location == null)
                {
                    return BadRequest("Lokasyon bulunamadı");
                }
                _locationDAL.Delete(location);
                return Ok("Lokasyon başarıyla silindi");

                int adet = _locationDAL.GetDefaults(a => a.ID != 0).GroupBy(a => a.Value).Count();
            }
        }
    
}
