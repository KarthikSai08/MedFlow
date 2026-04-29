using MedFlow.Identity.Domain.Enums;

namespace MedFlow.Identity.Domain.Entities
{
    public class User
    {
        public int UsertId { get; set; }
        public string UserName { get; set; }
        public Roles Role { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }

    }
}
