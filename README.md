# cert-store-platform

A simple certificate store platform built as an end-to-end DevOps project.

## Project goal

The goal of this project is to create an automated end-to-end solution from development to deployment, including:

- frontend and backend application modules
- containerization
- CI workflow for building and pushing Docker images
- Kubernetes deployment
- ArgoCD-based CD
- user and deployment documentation

## Planned technology stack

- Frontend: Angular
- Backend: ASP.NET Core Web API
- Database: MongoDB
- Containerization: Docker
- CI: GitHub Actions
- Deployment: Kubernetes
- CD: ArgoCD

## Planned domain

The application is a simple certificate store platform that supports:

- root certificate creation
- root certificate listing
- CSR upload
- user certificate signing
- certificate listing
- certificate deletion

## Repository structure

- `frontend/` - frontend application
- `backend/` - backend services
- `deploy/` - Kubernetes and ArgoCD deployment files
- `docs/` - user and deployment documentation
- `diagrams/` - architecture and domain diagrams