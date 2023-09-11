namespace OnKeyWebApp.Models
{
    public class MusicClub_Event
    {
        public int MusicClubId { get; set; }
        public MusicClub? MusicClub { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }
    }
}
