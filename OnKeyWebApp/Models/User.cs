using OnKeyWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnKeyWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name ="Username")]
        public string UserName { get; set; }
        public MusicalBackground MusicalBackground { get; set; }
        public string? Street { get; set; }
        public string? Neigbourhood { get; set; }
        public string? ProfilePicUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
