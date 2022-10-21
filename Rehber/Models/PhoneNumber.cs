namespace Rehber.Models
{
    public class PhoneNumber
    {
        public int ID { get; set; }

        public int PersonID { get; set; }
        public string Value { get; set; }

        public virtual Person Person { get; set; }

    }
}
