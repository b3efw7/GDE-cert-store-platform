import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    // Enables global browser error handling for the Angular app.
    provideBrowserGlobalErrorListeners(),

    // Registers Angular HttpClient so services can call backend APIs.
    provideHttpClient()
  ]
};