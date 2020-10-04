namespace server.Services.Auth
{
    public interface IAuthManager
    {
        public string EncryptPassword(string password);

        public bool ComparePassword(string password, string hashedPassword);

        public string GenerateJwt(string id, string email, string role);
    }
}