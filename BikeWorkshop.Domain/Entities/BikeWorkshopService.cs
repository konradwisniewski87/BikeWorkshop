using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Domain.Entities
{
    public class BikeWorkshopService
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public string Cost { get; set; } = default!;

        public int BikeWorkshopId { get; set; } = default!;
        public BikeWorkshop BikeWorkshop { get; set; } = default!;
    }
}
