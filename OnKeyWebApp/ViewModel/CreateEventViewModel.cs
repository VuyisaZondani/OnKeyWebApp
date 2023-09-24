namespace OnKeyWebApp.ViewModel
{
    public class CreateEventViewModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? ProfilePicUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
