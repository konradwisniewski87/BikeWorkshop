using AutoMapper;
using BikeWorkshop.Application.BikeWorkshop.Commands.CreateBikeWorkshop;
using BikeWorkshop.Application.BikeWorkshop.Commands.EditBikeWorkshop;
using BikeWorkshop.Application.BikeWorkshop.Queries.GetAllBikeWorkshop;
using BikeWorkshop.Application.BikeWorkshop.Queries.GetBikeWorkshopByEncodedName;
using BikeWorkshop.MVC.Extensions;
using BikeWorkshop.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        //------------------------------------------------------------------------------------------------
        //------------------------------------------------------- Create ---------------------------------
        //------------------------------------------------------------------------------------------------
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            //if(!User.IsInRole("Admin"))
            //{
            //    return RedirectToAction("NoAccess", "BikeWorkshop");
            //}
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateBikeWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            this.SetNotification("success", $"Created bikeworkshop: {command.Name}");

            return RedirectToAction(nameof(Index));
        }


        //------------------------------------------------------------------------------------------------
        //------------------------------------------------------- Index ----------------------------------
        //------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var bikeWorkshopDto = await _mediator.Send(new GetAllBikeWorkshopQuery());
            return View(bikeWorkshopDto);
        }


        //------------------------------------------------------------------------------------------------
        //------------------------------------------------------- Privacy --------------------------------
        //------------------------------------------------------------------------------------------------
        public IActionResult Privacy()
        {
            return View();
        }


        //------------------------------------------------------------------------------------------------
        //------------------------------------------------------- Details --------------------------------
        //------------------------------------------------------------------------------------------------
        [Route("BikeWorkshop/{encodedName}/Details")]
		public async Task<IActionResult> Details(string encodedName)
		{
            var bikeWorkshop = await _mediator.Send(new GetBikeWorkshopByEncodedNameQuery(encodedName));
			return View(bikeWorkshop);
		}


        //------------------------------------------------------------------------------------------------
        //------------------------------------------------------- Edit -----------------------------------
        //------------------------------------------------------------------------------------------------
        [Route("BikeWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var bikeWorkshopDto = await _mediator.Send(new GetBikeWorkshopByEncodedNameQuery(encodedName));
            if (!bikeWorkshopDto.IsEditable4You)
            {
                return RedirectToAction("NoAccess", "BikeWorkshop");
            }
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



        //------------------------------------------------------------------------------------------------
        //------------------------------------------------------ NoAccess --------------------------------
        //------------------------------------------------------------------------------------------------
        public IActionResult NoAccess()
        {
            return View();
        }

        //------------------------------------------------------------------------------------------------
        //------------------------------------------------------- Home -----------------------------------
        //------------------------------------------------------------------------------------------------
        public IActionResult Home()
        {
            return RedirectToAction(nameof(Index));
		}
	}
}
