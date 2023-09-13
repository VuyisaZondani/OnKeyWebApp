using OnKeyWebApp.Data.Enum;

namespace OnKeyWebApp.ViewModel
{
    public class CreateMusicClubViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public string Street { get; set; }
        public string Neighbourhood { get; set; }
        public string ProfilePicUrl { get; set; }
        public IFormFile Image { get; set; }
        public string AppUserId { get; set; }
    }
}
