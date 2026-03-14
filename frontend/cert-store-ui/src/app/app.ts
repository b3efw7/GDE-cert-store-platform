import { Component, OnInit, inject, signal } from '@angular/core';
import { Certificate } from './services/certificate';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  // Service used to call the backend certificate endpoints.
  private certificateService = inject(Certificate);

  // Stores the received root certificate list for display.
  rootCertificates = signal<any[]>([]);

  ngOnInit(): void {
    // Loads root certificate data when the component starts.
    this.certificateService.getRootCertificates().subscribe({
      next: (data: any) => {
        this.rootCertificates.set(data);
      },
      error: (error) => {
        console.error('Error while loading root certificates:', error);
      }
    });
  }
}