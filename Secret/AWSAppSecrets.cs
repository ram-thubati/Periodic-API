using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Text.Json;

namespace Periodic.Secret
{
    public class AWSAppSecrets : IAppSecrets
    {
        private readonly string _dbSecretName = "periodic/dev/rds/admin";
        private readonly string _jwtSecretName = "periodic/dev/crypto/JwtSigningKey";
        private string _regionName = "us-east-1";
        public string getDbConnectionString()
        {
            var secret_string = GetSecret(_dbSecretName, _regionName);

            var values = JsonSerializer.Deserialize<Dictionary<string,object>>(secret_string);

            //use string interpolation to build connection string
            var connectionString = $"Server={values["host"]},{values["port"]};Initial Catalog={values["dbInstanceIdentifier"]};User Id={values["username"]};Password={values["password"]};";
            
            return connectionString;
        }
        public string getJwtSigningKey()
        {
            var secret_string = GetSecret(_jwtSecretName,_regionName);

            var values = JsonSerializer.Deserialize<Dictionary<string,object>>(secret_string);

            return values["JwtSigningKey"].ToString();
        }
        private string GetSecret(string secretName, string regionName) 
        {
            string secret = "";

            MemoryStream memoryStream = new MemoryStream();
            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(regionName));
            GetSecretValueRequest request = new GetSecretValueRequest();
            
            request.SecretId = secretName;
            request.VersionStage = "AWSCURRENT"; 
            
            GetSecretValueResponse response = null;
            try 
            {
                response = client.GetSecretValueAsync(request).Result;
            } 
            catch(Exception e)
            {
                throw e;
            }
            // Decrypts secret using the associated KMS key.
            // Depending on whether the secret is a string or binary, one of these fields will be populated.
            if (response.SecretString != null) 
            {
                return secret = response.SecretString;
            } 
            else 
            {
                memoryStream = response.SecretBinary;
                StreamReader reader = new StreamReader(memoryStream);
                string decodedBinarySecret = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(reader.ReadToEnd()));
                return decodedBinarySecret;
            }
        }
    }
}