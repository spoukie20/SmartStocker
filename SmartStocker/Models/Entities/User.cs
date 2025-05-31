using Org.BouncyCastle.Asn1.X509;

namespace SmartStocker.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Rol { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
