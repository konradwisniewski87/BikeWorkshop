using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeWorkshop.Domain.Entities
{
    public class BikeWorkshop
    {
        public required int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public BikeWorkshopContactDetails ContactDetails { get; set; } = default!;
        public string EncodedName { get; private set; } = default!;
        public string EncodName() => EncodedName = Name.ToLower().Replace(" ", "-");
    }
}
