using BikeWorkshop.Application.BikeWorkshop;
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
        public async Task<IActionResult> Create(BikeWorkshopDto bikeWorkshopDto)
        {
            await _bikeWorkshopService.Create(bikeWorkshopDto);
            return RedirectToAction(nameof(Create)); //TODO: Refactor
        }
    }
}
