namespace cert_store_api.Models;

public class RootCertificate
{
    public string Id { get; set; } = string.Empty;

    public string CommonName { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Issuer { get; set; } = string.Empty;

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public string Status { get; set; } = "Active";
}