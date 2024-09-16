using Microsoft.AspNetCore.Identity;

namespace BikeWorkshop.Domain.Entities
{
    public class BikeWorkshop
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public BikeWorkshopContactDetails ContactDetails { get; set; } = default!;
        public string EncodedName { get; private set; } = default!;
        public string EncodName() => EncodedName = Name.ToLower().Replace(" ", "-");
        public string? About { get; set; }
        public string? CreatedById { get; set; }
		public IdentityUser? CreatedBy { get; set; }
        public List<BikeWorkshopService> Services { get; set; } = new();
	}
}
