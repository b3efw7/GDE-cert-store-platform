import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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
    return this.http.get(`${this.apiUrl}/root-certificates`);
  }
}