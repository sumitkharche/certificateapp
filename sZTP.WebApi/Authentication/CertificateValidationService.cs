using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace sZTP.WebApi.Authentication
{
    public class CertificateValidationService
    {
        public CertificateValidationService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public bool ValidateCertificate(X509Certificate2 clientCertificate)
        {
            string allowedCertThumbprints = Configuration["AllowedCertThumbprints"];
            string[] allowedThumbprints = allowedCertThumbprints.Split(",");
            //string[] allowedThumbprints = {
            //    "8B722FE35ECE119474AF7ED104C5F84D380B7CC2"
            //};
            if (allowedThumbprints.Contains(clientCertificate.Thumbprint))
            {
                return true;
            }
            return false;
        }
    }
}
