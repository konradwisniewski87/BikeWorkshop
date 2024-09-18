using MediatR;

namespace BikeWorkshop.Application.BikeWorkshopService.Commands
{
    public class CreateBikeWorkshopServiceCommand : BikeWorkshopServiceDto, IRequest
    {
        public string BikeWorkshopEncodedName { get; set; } = default!;
    }
}
