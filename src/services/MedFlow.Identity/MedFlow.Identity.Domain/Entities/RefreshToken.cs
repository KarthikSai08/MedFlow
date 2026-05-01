namespace MedFlow.Identity.Domain.Entities
{
    public class RefreshToken
    {
        public int TokenId { get; set; }
        public int UserId { get; set; } 
        public string Token { get; set; } = null!;
        public bool IsRevoked { get; set; } = false;
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
