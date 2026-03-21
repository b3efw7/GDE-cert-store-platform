# GDE Certificate Store Platform

A certificate store platform developed as an end-to-end DevOps project for the GDE B-ALKFET course.
A DevOps-oriented certificate store project developed for the GDE B-ALKFET course.

## Project Goal

The goal of the project is to demonstrate a complete development-to-deployment workflow for a simple certificate-related application, including:

- frontend and backend application modules
- database integration
- containerization
- CI pipeline automation
- container registry publishing
- Kubernetes deployment
- ArgoCD-based synchronization
- user and deployment documentation

## Project Overview

The system consists of an Angular frontend, an ASP.NET Core backend, and a MongoDB database.  
It demonstrates how application development, Docker-based packaging, GitHub Actions CI, GHCR image publishing, Kubernetes deployment, Helm-based MongoDB installation, and ArgoCD synchronization can be combined into one project.

The goal of the project is to provide a simple certificate store platform where certificate-related data can be managed and displayed through a web application. The solution uses an Angular frontend, an ASP.NET Core backend, and MongoDB as the database. The project also demonstrates containerization, CI/CD automation, Kubernetes deployment, Helm-based MongoDB installation, and ArgoCD-based synchronization.

## Main Features

The current implementation supports the following functions:

- display root certificates
- display user certificates
- store certificate data in MongoDB
- seed MongoDB with default certificate records
- expose certificate data through REST API endpoints
- display certificate data in the frontend

## Technology Stack

### Frontend
- Angular

### Backend
- ASP.NET Core Web API / C#

### Database
- MongoDB

### DevOps / Deployment
- Docker
- GitHub Actions
- GitHub Container Registry (GHCR)
- Kubernetes
- Helm
- ArgoCD

## Repository Structure

```text
GDE-cert-store-platform/
├── backend/                # backend services
│   └── cert-store-api/
├── frontend/               # frontend application
│   └── cert-store-ui/
├── deploy/                 # Kubernetes and ArgoCD deployment files
│   ├── argocd/
│   └── k8s/
├── diagrams/               # architecture, CI/CD and domain diagrams
├── docs/                   # user and deployment documentation 
├── .gitignore
├── GDE-cert-store-platform.slnx
└── README.md

```
## API Endpoints

- GET /api/health
- GET /api/root-certificates
- GET /api/user-certificates

## Diagrams

The diagrams folder contains:
- arch.drawio – architecture diagram
- cicd.drawio – CI/CD pipeline diagram
- domain.drawio – domain / use case diagram

## CI/CD Summary

The implemented pipeline performs the following high-level steps:

- source code is pushed to GitHub
- GitHub Actions builds the backend and frontend
- Docker images are built for both services
- images are pushed to GitHub Container Registry

Kubernetes manifests define the target runtime state

ArgoCD synchronizes the deployment state

## Documentation

Additional documentation is available in the docs folder:
- user-guide.md
- deployment-guide.md

## Notes

This project is intended for educational and demonstration purposes.
The focus is on DevOps workflow, environment integration, deployment automation, and certificate data handling rather than full PKI lifecycle management.

```