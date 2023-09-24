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
        public ActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Create()
        //{

        //}
        public async Task<IActionResult>Detail(int id)
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
    }
}
