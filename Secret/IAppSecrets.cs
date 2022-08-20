namespace Periodic.Secret
{
    public interface IAppSecrets
    {
        public string getDbConnectionString();

        public string getJwtSigningKey();
    }
}