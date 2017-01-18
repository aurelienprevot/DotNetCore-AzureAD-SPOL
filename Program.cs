using System;
using System.Net.Http;
using SharePoint.Client;

namespace ConsoleApplication
{
    public class Program
    {
        //https://blog.mastykarz.nl/azure-ad-app-only-access-token-using-certificate-dotnet-core/
        //http://www.erwinmcm.com/azure-active-directory-app-only-authentication-with-officedev-pnp-powershell/
        //Generation du certificat sur Mac : https://blogs.msdn.microsoft.com/arsen/2015/09/18/certificate-based-auth-with-azure-service-principals-from-linux-command-line/
        //Generation du pfx sur Mac : openssl pkcs12 -inkey bob_key.pem -in bob_cert.cert -export -out bob_pfx.pfx
        //Publication Azure Web Job : https://blog.kloud.com.au/2016/06/08/azure-webjobs-with-dotnet-core-rc2/
        public static void Main(string[] args)
        {

            var tenantId = "TENANT ID OF AUZRE TNEANT";
            var resource = "URL OF YOUR SPOL TENANT";
            var clientId = "CLIENT ID OF THE AZURE APP";
            var accessToken = ServicePrincipal.GetS2SAccessToken("https://login.microsoftonline.com/" + tenantId, resource, clientId).Result;
            var webUri = new Uri("URL OF THE SITE COLLECTION");

            using (SPHttpClient client = new SPHttpClient(webUri, accessToken))
            {
                try
                {
                    var itemPayload = new { __metadata = new { type = "SP.Data.TestListItem" }, Title = "Element de test" };
                    var endpointUrl = string.Format("{0}/_api/web/lists/getbytitle('Test')/items", webUri);
                    var item = client.ExecuteJson(endpointUrl, HttpMethod.Post, null, itemPayload);
                    Console.WriteLine("List item created");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
