namespace Rehber.Models.DTOs
{
    public class GetByIdPersonDTO
    {
        public GetByIdPersonDTO()
        {
           Email = new List<string>();
           PhoneNumber = new List<string>();
           Location = new List<string>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<String> Email { get; set; }
        public List<String> PhoneNumber { get; set; }
        public List<String> Location { get; set; }
    }
}
