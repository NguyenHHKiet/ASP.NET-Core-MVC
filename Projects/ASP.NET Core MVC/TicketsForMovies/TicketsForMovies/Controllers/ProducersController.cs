using Microsoft.AspNetCore.Mvc;
using TicketsForMovies.Data.Services.Producers;
using TicketsForMovies.Models;

namespace TicketsForMovies.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersServices _services;

        public ProducersController(IProducersServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _services.GetAllAsync();
            return View(allProducers);
        }

        //GET: producers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _services.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //GET: producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await _services.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //GET: producers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _services.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if (id == producer.Id)
            {
                await _services.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

    }
}
