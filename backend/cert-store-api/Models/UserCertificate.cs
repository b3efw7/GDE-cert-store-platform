namespace cert_store_api.Models;

public class UserCertificate
{
    public Guid Id { get; set; }

    public string CommonName { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Issuer { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public string Status { get; set; } = "Issued";
}