using Microsoft.AspNetCore.Mvc;
using OnKeyWebApp.Data.Interface;
using OnKeyWebApp.Models;
using OnKeyWebApp.ViewModel;

namespace OnKeyWebApp.Controllers
{
    public class MusicClubController : Controller
    {
        private readonly IMusicClubRepository _musicClubRepository;
       
        private readonly IPhotoServices _photoServices;

        public MusicClubController(IMusicClubRepository musicClubRepository, IPhotoServices photoServices)
        {
            _musicClubRepository = musicClubRepository;
           
            _photoServices = photoServices;
          
        }
        public async Task<IActionResult> Index()
        {
           IEnumerable<MusicClub> musicClubs = await _musicClubRepository.GetAllMusicClubs();
           return View(musicClubs);
        }
        public async Task<IActionResult> Detail(int Id)
        {
            MusicClub club = await _musicClubRepository.GetByIdAsync(Id);
            var createMusicClubViewModel = new CreateMusicClubViewModel()
            {
                Title = club.Title,
                Description = club.Description,
                Genre = club.Genre,
                Street = club.Street,
                Neighbourhood = club.Neighbourhood,
             
                
            };
            return View(club);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ///*var currentUserId = _httpContextAccessor.HttpContext.User.GetUserId()*/;
            //var createMusicClubViewModel = new CreateMusicClubViewModel { AppUserId = currentUserId };
            //return View(createMusicClubViewModel);
            return View();
           
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMusicClubViewModel createMusicClubViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoServices.AddPhotoAsync(createMusicClubViewModel.Image);
                var club = new MusicClub
                {
                    Title = createMusicClubViewModel.Title,
                    Description = createMusicClubViewModel.Description,
                    Genre = createMusicClubViewModel.Genre,
                    Street = createMusicClubViewModel.Street,
                    Neighbourhood = createMusicClubViewModel.Neighbourhood,
                    ProfilePicUrl = result.Url.ToString()
                    
                };
                _musicClubRepository.Add(club);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(createMusicClubViewModel);
        }

        
    }
}
