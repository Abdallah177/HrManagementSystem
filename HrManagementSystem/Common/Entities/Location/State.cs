using HrManagementSystem.Common.Entities;

namespace HrManagementSystem.Common.Entities.Location
{
    public class State : BaseModel
    {
        public string Name { get; set; } = null!;

        public string CountryId { get; set; } = null!;
        public Country Country { get; set; } = null!;

        public ICollection<City> Cities { get; set; } = new List<City>();

    }
}
