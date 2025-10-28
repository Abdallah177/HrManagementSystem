using HrManagementSystem.Common.Entities.Roles;
using System.Data;

namespace HrManagementSystem.Common.Entities
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; } = null!;
        public Role Role { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiry { get; set; }
        public string OrganizationId { get; set; } = null!;  
        public Organization Organization { get; set; } = null!;
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

