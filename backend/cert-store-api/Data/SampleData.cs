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
    
    public static List<UserCertificate> GetUserCertificates()
    {
        return new List<UserCertificate>
        {
            new UserCertificate
            {
                Id = Guid.NewGuid(),
                CommonName = "GDE Student Certificate",
                Subject = "CN=GDE Student",
                Issuer = "CN=GDE Root CA",
                Email = "student@neptun.gde.hu",
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow.AddYears(2),
                Status = "Issued"
            }
        };
    }
}