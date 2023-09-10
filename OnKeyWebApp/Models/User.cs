using System.ComponentModel.DataAnnotations.Schema;

namespace OnKeyWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public string? ProfilePicUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
