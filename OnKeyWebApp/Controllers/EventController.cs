using Microsoft.AspNetCore.Mvc;
using OnKeyWebApp.Data.Interface;
using OnKeyWebApp.Models;
using OnKeyWebApp.ViewModel;

namespace OnKeyWebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IPhotoServices _photoServices;

        public EventController(IEventRepository eventRepository, IPhotoServices photoServices)
        {
            _eventRepository = eventRepository;
            _photoServices = photoServices;
        }
        public async Task<ActionResult> Index()
        {
            IEnumerable<Event> events = await _eventRepository.GetAllEvents();
            return View(events);
        }

        //public async Task<IActionResult> Create()
        //{

        //}
        public async Task<IActionResult> Detail(int id)
        {
            Event events = await _eventRepository.GetByIdAsync(id);
            var createEventViewModel = new CreateEventViewModel()
            {
                Title = events.Title,
                Description = events.Description,
                Location = events.Location,
                ProfilePicUrl = events.ProfilePicUrl
            };

            return View(events);
        }
        [HttpGet]
        //public async Task<IActionResult> Create()
        //{
        //    //var currentUserId = _httpContextAccessor.HttpContext.User.GetUserId();
        //    //var createMusicClubViewModel = new CreateMusicClubViewModel { AppUserId = currentUserId };
        //    return View();


        //}.    
        [HttpPost]
        public async Task<IActionResult> Create(CreateEventViewModel createEventViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoServices.AddPhotoAsync(createEventViewModel.Image);
                var events = new Event
                {
                    Title = createEventViewModel.Title,
                    Description = createEventViewModel.Description,
                    Location = createEventViewModel.Location,
                    ProfilePicUrl = result.Url.ToString()
                };
                _eventRepository.Add(events);
                return RedirectToAction("Index");
            }

            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(createEventViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var events = await _eventRepository.GetByIdAsync(id);
            if (events == null) return View("Error");

            var eventsVM = new CreateEventViewModel()
            {

                Title = events.Title,
                Description = events.Description,
                Location = events.Location,
                ProfilePicUrl = events.ProfilePicUrl
            };
            return View(eventsVM);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(int id,CreateEventViewModel editEventViewModel)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Event");
                return View("Error");
            }

            var events = await _eventRepository.GetByIdAsyncNoTracking(id);

            if(events != null)
            {
                try
                {
                    await _photoServices.DeletePhotoAsync(events.ProfilePicUrl);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(editEventViewModel);
                }

                var photoResult = await _photoServices.AddPhotoAsync(editEventViewModel.Image);
                var musicEvents = new Event
                {
                    Id = id,
                    Title = events.Title,
                    Description = events.Description,
                    Location = events.Location,
                    ProfilePicUrl = photoResult.Url.ToString()
                };
                _eventRepository.Update(events);
                return RedirectToAction("Index");

            }
        }
    }
}
