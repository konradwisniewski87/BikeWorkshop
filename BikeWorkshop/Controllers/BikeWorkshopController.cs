using AutoMapper;
using BikeWorkshop.Application.BikeWorkshop.Commands.CreateBikeWorkshop;
using BikeWorkshop.Application.BikeWorkshop.Commands.EditBikeWorkshop;
using BikeWorkshop.Application.BikeWorkshop.Queries.GetAllBikeWorkshop;
using BikeWorkshop.Application.BikeWorkshop.Queries.GetBikeWorkshopByEncodedName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BikeWorkshop.MVC.Controllers
{
    public class BikeWorkshopController : Controller
    {
		private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BikeWorkshopController(IMediator mediator, IMapper mapper)
        {
			_mediator = mediator;
            _mapper = mapper;
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
		public async Task<IActionResult> Create(CreateBikeWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Index()
        {
            var bikeWorkshopDto = await _mediator.Send(new GetAllBikeWorkshopQuery());
            return View(bikeWorkshopDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("BikeWorkshop/{encodedName}/Details")]
		public async Task<IActionResult> Details(string encodedName)
		{
            var bikeWorkshop = await _mediator.Send(new GetBikeWorkshopByEncodedNameQuery(encodedName));
			return View(bikeWorkshop);
		}

        [Route("BikeWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var bikeWorkshopDto = await _mediator.Send(new GetBikeWorkshopByEncodedNameQuery(encodedName));
            EditBikeWorkshopCommand editBikeWorkshop = _mapper.Map<EditBikeWorkshopCommand>(bikeWorkshopDto);
            return View(editBikeWorkshop);
        }
        [HttpPost]
        [Route("BikeWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditBikeWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            } 
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Home()
        {
            return RedirectToAction(nameof(Index));
		}
	}
}
