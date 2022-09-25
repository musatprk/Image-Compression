using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Compression.Application.AzureKeyVault
{
    public class KeyVaultConnection
    {
        public static string ImageConfigurationGetBlobConnection(string key) /* Key Vault Bilgilerinizi Girebilirsiniz 
                                                                               Blob Storage Account Connection Bilgilerinizi Key Vault a eklemeyi unutmayın bu method key value mantığında çalışır :)*/ 
        {
            var client = new SecretClient(new Uri(""),
            new ClientSecretCredential(tenantId: "",
            clientId: "",
            clientSecret: ""));
            try
            {
                var blobconnection = client.GetSecret(key).Value.Value.ToString();
                return blobconnection;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
