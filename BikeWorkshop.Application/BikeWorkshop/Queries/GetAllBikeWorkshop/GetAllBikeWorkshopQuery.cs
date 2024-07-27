using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Application.BikeWorkshop.Queries.GetAllBikeWorkshop
{
	public class GetAllBikeWorkshopQuery : BikeWorkshopDto, IRequest<IEnumerable<BikeWorkshopDto>>
	{
	}
}
