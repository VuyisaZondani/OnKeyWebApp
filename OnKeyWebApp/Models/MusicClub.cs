using OnKeyWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace OnKeyWebApp.Models
{
    public class MusicClub
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Genre Genre { get; set; }
        public string? Street { get; set; }
        public string? Neighbourhood { get; set; }
        public string? ProfilePicUrl { get; set; }
        //public IFormFile Image { get; set; }
        //public List<MusicClub_Event> MusicClub_Events { get; set; }
    }

}
