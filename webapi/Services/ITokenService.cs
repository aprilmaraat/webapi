namespace webapi.Services
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string role);
    }
}
