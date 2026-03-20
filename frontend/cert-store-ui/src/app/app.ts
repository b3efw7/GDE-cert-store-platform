import { Component, OnInit, inject, signal } from '@angular/core';
import { DatePipe } from '@angular/common';
import { Certificate } from './services/certificate';
import { RootCertificate } from './models/root-certificate';
import { UserCertificate } from './models/user-certificate';

@Component({
  selector: 'app-root',
  imports: [DatePipe],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  // Service used to call the backend certificate endpoints.
  private certificateService = inject(Certificate);

  // Stores the received root certificate list for display.
  rootCertificates = signal<RootCertificate[]>([]);

  // Stores the received user certificate list for display.
  userCertificates = signal<UserCertificate[]>([]);

  ngOnInit(): void {
    // Loads root certificate data when the component starts.
    this.certificateService.getRootCertificates().subscribe({
      next: (data) => {
        this.rootCertificates.set(data);
      },
      error: (error) => {
        console.error('Error while loading root certificates:', error);
      }
    });

    // Loads user certificate data when the component starts.
    this.certificateService.getUserCertificates().subscribe({
      next: (data) => {
        this.userCertificates.set(data);
      },
      error: (error) => {
        console.error('Error while loading user certificates:', error);
      }
    });
  }
}