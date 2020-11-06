namespace server.Services.Auth
{
    public interface IAuthManager
    {
        string EncryptPassword(string password);

        bool ComparePassword(string password, string hashedPassword);

        string GenerateJwt(string id, string email, string role);
    }
}