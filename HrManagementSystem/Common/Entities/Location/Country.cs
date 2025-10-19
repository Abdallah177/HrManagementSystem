using System.ComponentModel.DataAnnotations;
using HrManagementSystem.Common.Entities;

namespace HrManagementSystem.Common.Entities.Location
{
    public class Country : BaseModel
    {
        public string Name { get; set; } = null!;

        public string? Code { get; set; }

        public ICollection<State> States { get; set; } = new List<State>();

        public ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}
