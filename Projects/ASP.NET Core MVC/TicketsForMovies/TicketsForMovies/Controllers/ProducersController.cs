using Microsoft.AspNetCore.Mvc;
using TicketsForMovies.Data.Services.Producers;

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
    }
}
