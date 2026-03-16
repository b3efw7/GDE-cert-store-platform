export interface UserCertificate {
  id: string;
  commonName: string;
  subject: string;
  issuer: string;
  email: string;
  validFrom: string;
  validTo: string;
  status: string;
}