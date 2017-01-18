using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ConsoleApplication
{
    public static class ServicePrincipal
    {
        public static async Task<string> GetS2SAccessToken(string authority, string resource, string clientId)
        {
            var certPath = Path.Combine(GetCurrentDirectoryFromExecutingAssembly(), "NAME OF THE CERTIFICATE");
            var certfile = File.OpenRead(certPath);
            var certificateBytes = new byte[certfile.Length];
            certfile.Read(certificateBytes, 0, (int)certfile.Length);
            var cert = new X509Certificate2(
                certificateBytes,
                "PASSWORD OF THE CERTIFICATE",
                X509KeyStorageFlags.Exportable |
                X509KeyStorageFlags.MachineKeySet |
                X509KeyStorageFlags.PersistKeySet);

            var certificate = new ClientAssertionCertificate(clientId, cert);
            AuthenticationContext context = new AuthenticationContext(authority);
            AuthenticationResult authenticationResult = await context.AcquireTokenAsync(resource, certificate);
            return authenticationResult.AccessToken;
        }

        public static string GetCurrentDirectoryFromExecutingAssembly()
        {
            var codeBase = typeof(Program).GetTypeInfo().Assembly.CodeBase;

            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}