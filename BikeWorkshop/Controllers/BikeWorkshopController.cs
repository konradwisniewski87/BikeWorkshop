using BikeWorkshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeWorkshop.MVC.Controllers
{
    public class BikeWorkshopController : Controller
    {
        private readonly IBikeWorkshopService _bikeWorkshopService;

        public BikeWorkshopController(IBikeWorkshopService bikeWorkshopService)
        {
            _bikeWorkshopService = bikeWorkshopService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Domain.Entities.BikeWorkshop bikeWorkshop)
        {
            await _bikeWorkshopService.Create(bikeWorkshop);
            return RedirectToAction(nameof(Create)); //TODO: Refactor
        }
    }
}
