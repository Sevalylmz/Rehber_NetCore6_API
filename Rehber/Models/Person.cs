using System.Security.Principal;

namespace Rehber.Models
{
    public class Person
    {
        //Class içerisindeki list yapıları kullanılabilmesi için List yapıları ctor içerisinde instance edilir.
        public Person()
        {
            Emails = new List<Email>();
            PhoneNumbers = new List<PhoneNumber>();
            Locations = new List<Location>();
        }

        //Person a ait propertyler tanımlanır.
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        //Navigation Property => bir person ın birden çok email,phone number ve location ı olabilir
        public virtual List<Email>? Emails { get; set; }
        public virtual List<PhoneNumber>? PhoneNumbers { get; set; }
        public virtual List<Location>? Locations { get; set; }




    }
}
