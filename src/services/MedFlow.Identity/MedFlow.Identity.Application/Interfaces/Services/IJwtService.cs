namespace MedFlow.Identity.Application.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string userName, string password);
    }
}
