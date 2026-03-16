export interface RootCertificate {
  id: string;
  commonName: string;
  subject: string;
  issuer: string;
  validFrom: string;
  validTo: string;
  status: string;
}