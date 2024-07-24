using BikeWorkshop.Application.BikeWorkshop;
using BikeWorkshop.Application.Services;
using Microsoft.AspNetCore.Authorization;
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

        //      [HttpGet]
        //      public IActionResult Create()
        //      {
        //          if(User.Identity == null || !User.Identity.IsAuthenticated)
        //          {
        //              return RedirectToPage("/Account/Login", new { area= "Identity" });
        //          }
        //	return View();
        //}

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		[Authorize]
		public async Task<IActionResult> Create(BikeWorkshopDto bikeWorkshopDto)
        {
            if (!ModelState.IsValid)
            {
                return View(bikeWorkshopDto);
            }
            await _bikeWorkshopService.Create(bikeWorkshopDto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Index()
        {
            var bikeWorkshopDto = await _bikeWorkshopService.GetAll();
            return View(bikeWorkshopDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Home()
        {
            return RedirectToAction(nameof(Index));
		}
	}
}
