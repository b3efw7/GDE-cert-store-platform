# User Guide

## Introduction

The GDE Certificate Store Platform is a simple web application for displaying certificate-related data stored in a MongoDB database.

The system includes:
- an Angular frontend
- an ASP.NET Core backend
- a MongoDB database

This project is intended for educational and demonstration purposes.

## Main User Functions

The current version supports the following user-visible functions:

- view root certificates
- view user certificates

## Application View

After the frontend and backend are started successfully, the start page displays two main sections:

### Root Certificates
This section shows root certificate records stored in MongoDB.

Displayed information:
- Common Name
- Subject
- Issuer
- Valid From
- Valid To
- Status

### User Certificates
This section shows user certificate records stored in MongoDB.

Displayed information:
- Common Name
- Subject
- Issuer
- Email
- Valid From
- Valid To
- Status

## Data Source

Both certificate lists are loaded from the backend API.

The backend retrieves the data from MongoDB.  
If the database is empty, the backend inserts default seed records during startup.

## Backend API Endpoints

The following endpoints are used by the frontend and can also be checked directly in a browser or API client:

- `GET /api/health`
- `GET /api/root-certificates`
- `GET /api/user-certificates`

## Typical Usage

A typical demonstration flow is:

1. start MongoDB access
2. start the backend
3. start the frontend
4. open the frontend in a browser
5. verify that both certificate sections are populated
6. optionally verify the backend API responses directly

## Expected Result

When the system is running correctly:

- the frontend loads without errors
- root certificates are displayed in card format
- user certificates are displayed in card format
- backend API endpoints return JSON data
- certificate data is loaded from MongoDB

## Current Scope

The project currently focuses on:

- certificate data storage
- certificate data display
- frontend-backend integration
- DevOps workflow
- deployment automation

The following are not implemented in the current version:

- certificate creation from the UI
- certificate deletion from the UI
- CSR upload handling
- full PKI lifecycle management
- end-user authentication and authorizationis document will describe how to use the application and its features.