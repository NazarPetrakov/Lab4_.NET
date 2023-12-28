namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(string userId, IList<string> roles);
    }
}
