using Microsoft.AspNetCore.Mvc;
using OnKeyWebApp.Data;
using OnKeyWebApp.Models;

namespace OnKeyWebApp.Controllers
{
    public class MusicClubController : Controller
    {
        private readonly IMusicClubRepository _musicClubRepository;

        public MusicClubController(IMusicClubRepository musicClubRepository )
        {
           _musicClubRepository = musicClubRepository;
        }
        public async Task<IActionResult> Index()
        {
           IEnumerable<MusicClub> musicClubs = await _musicClubRepository.GetAllMusicClubs();
           return View(musicClubs);
        }
        public async Task<IActionResult> Detail(int Id)
        {
            return View();
        }
    }
}
