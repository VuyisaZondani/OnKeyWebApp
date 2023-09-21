using Microsoft.AspNetCore.Mvc;
using OnKeyWebApp.Data.Interface;
using OnKeyWebApp.Models;
using OnKeyWebApp.ViewModel;
using System.Security.Claims;

namespace OnKeyWebApp.Controllers
{
    public class MusicClubController : Controller
    {
        private readonly IMusicClubRepository _musicClubRepository;

        private readonly IPhotoServices _photoServices;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MusicClubController(IMusicClubRepository musicClubRepository, IPhotoServices photoServices, IHttpContextAccessor httpContextAccessor)
        {
            _musicClubRepository = musicClubRepository;
            _photoServices = photoServices;
            _httpContextAccessor = httpContextAccessor;
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
            var currentUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createMusicClubViewModel = new CreateMusicClubViewModel { AppUserId = currentUserId };
            return View(createMusicClubViewModel);
           

        }
        [HttpGet]
        public async Task<IActionResult> Create(CreateMusicClubViewModel createMusicClubViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoServices.AddPhotoAsync(createMusicClubViewModel.Image);
                var musicClub = new MusicClub
                {
                    Title = createMusicClubViewModel.Title,
                    Description = createMusicClubViewModel.Description,
                    Genre = createMusicClubViewModel.Genre,
                    Street = createMusicClubViewModel.Street,
                    Neighbourhood = createMusicClubViewModel.Neighbourhood,
                    ProfilePicUrl = result.Url.ToString()

                };
                _musicClubRepository.Add(musicClub);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(createMusicClubViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var musicClub = await _musicClubRepository.GetByIdAsync(id);
            if (musicClub == null) return View("Error");

            var musicClubV = new CreateMusicClubViewModel()
            {
                Title = musicClub.Title,
                Description = musicClub.Description,
                Genre = musicClub.Genre,
                Street = musicClub.Street,
                Neighbourhood = musicClub.Neighbourhood,
                ProfilePicUrl = musicClub.ProfilePicUrl,
                AppUserId = musicClub.AppUserId
            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateMusicClubViewModel createMusicClubVM)
        {
            if(!ModelState.IsValid)
            {
                return View("Error");
            }
            var userMC = await _musicClubRepository.GetByIdAsync(id);

            if (userMC != null)
                try
                {
                    await _photoServices.DeletePhotoAsync(userMC.ProfilePicUrl);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(createMusicClubVM);
                }

            var photoResult = await _photoServices.AddPhotoAsync(createMusicClubVM.Image);
           

            var musicClub = new MusicClub
            {
                Id = id,
                Title = createMusicClubVM.Title,
                Description = createMusicClubVM.Description,
                ProfilePicUrl = photoResult.Url.ToString(),
                Genre = createMusicClubVM.Genre,
                Street = createMusicClubVM.Street,
                Neighbourhood = createMusicClubVM.Neighbourhood,

            };

            _musicClubRepository.Update(musicClub);

            return RedirectToAction("Index");
        }

    }
}
