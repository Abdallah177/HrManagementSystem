using System.ComponentModel.DataAnnotations.Schema;
using HrManagementSystem.Common.Entities;

namespace HrManagementSystem.Common.Entities.Location
{
    public class City : BaseModel
    {
        public string Name { get; set; } = null!;

        public string StateId { get; set; } = null!;
        public State State { get; set; } = null!;

        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
    }
}
