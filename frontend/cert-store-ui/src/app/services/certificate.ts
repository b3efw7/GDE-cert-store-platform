import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RootCertificate } from '../models/root-certificate';
import { UserCertificate } from '../models/user-certificate';

@Injectable({
  providedIn: 'root'
})
export class Certificate {
  // Angular HTTP client used for backend API calls.
  private http = inject(HttpClient);

  // Base URL of the backend API.
  private apiUrl = 'https://localhost:7249/api';

  // Requests the list of root certificates from the backend.
  getRootCertificates() {
    return this.http.get<RootCertificate[]>(`${this.apiUrl}/root-certificates`);
  }

  // Requests the list of user certificates from the backend.
  getUserCertificates() {
    return this.http.get<UserCertificate[]>(`${this.apiUrl}/user-certificates`);
  }
}