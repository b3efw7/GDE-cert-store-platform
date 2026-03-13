using cert_store_api.Models;

namespace cert_store_api.Data;

public static class SampleData
{
    public static List<RootCertificate> GetRootCertificates()
    {
        return new List<RootCertificate>
        {
            new RootCertificate
            {
                Id = Guid.NewGuid(),
                CommonName = "GDE Root CA",
                Subject = "CN=GDE Root CA",
                Issuer = "CN=GDE Root CA",
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow.AddYears(5),
                Status = "Active"
            }
        };
    }
}