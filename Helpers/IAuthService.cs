namespace Periodic.Helpers
{
    public interface IAuthService
    {
        public string GetJwtToken(int usr_id, string signingKey);

        public bool VerifyPassword(string give_password, string stored_password_hash);

        public bool GetPasswordHash(string password);

    }

}