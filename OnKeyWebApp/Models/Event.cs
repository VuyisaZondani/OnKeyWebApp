using System.ComponentModel.DataAnnotations;

namespace OnKeyWebApp.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? ProfilePicUrl { get; set; }
        //public IFormFile Image { get; set; }
        //Relationship many to many
        public List<MusicClub_Event> MusicClub_Events { get; set; }
    }
}
