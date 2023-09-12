using System.ComponentModel.DataAnnotations;

namespace OnKeyWebApp.Models
{
    public class MusicClub_Event
    {
        [Key] 
        public int Id { get; set; }
        public int MusicClubId { get; set; }
        public MusicClub? MusicClub { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }
        
    }
}
