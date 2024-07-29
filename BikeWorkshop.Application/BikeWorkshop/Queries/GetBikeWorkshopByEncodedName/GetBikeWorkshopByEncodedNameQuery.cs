using MediatR;

namespace BikeWorkshop.Application.BikeWorkshop.Queries.GetBikeWorkshopByEncodedName
{
	public class GetBikeWorkshopByEncodedNameQuery : BikeWorkshopDto, IRequest<BikeWorkshopDto>
	{
        public string EncodedName { get; set; }
        public GetBikeWorkshopByEncodedNameQuery(string encodedName)
        {
			EncodedName = encodedName;
		}
    }
}
