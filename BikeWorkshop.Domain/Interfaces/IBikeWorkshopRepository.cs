using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Domain.Interfaces
{
    public interface IBikeWorkshopRepository
    {
        Task Create(Domain.Entities.BikeWorkshop bikeWorkshop);
    }
}
