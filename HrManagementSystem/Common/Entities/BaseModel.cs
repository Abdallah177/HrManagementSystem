using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Common.Entities
{
    public class BaseModel
    {
        [Key]
        public string Id { get; set; }
        public string CreatedByUser { get; set; }
        public string? UpdatedByUser { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
