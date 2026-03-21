# Deployment Guide

## Introduction

This document describes how to build, run, deploy, and validate the GDE Certificate Store Platform.

The project contains:
- Angular frontend
- ASP.NET Core backend
- MongoDB database
- Docker support
- GitHub Actions CI
- GHCR image publishing
- Kubernetes manifests
- Helm-based MongoDB installation
- ArgoCD synchronization

## 1. Local Development Run

### 1.1 Start MongoDB Access

MongoDB runs inside Kubernetes in this project. For local backend testing, use port forwarding:

```powershell
kubectl port-forward svc/cert-store-mongodb 27017:27017
```

### 1.2 Start the Backend

```powershell
cd .\backend\cert-store-api
dotnet run --launch-profile https
```

Expected backend addresses:
- https://localhost:7249
- http://localhost:5011

### 1.3 Start the Frontend

```powershell
cd .\frontend\cert-store-ui
ng serve
```

Expected frontend address:
- http://localhost:4200

## 2. Docker Build and Run

### 2.1 Backend Docker Image

```powershell
cd .\backend\cert-store-api
docker build -t cert-store-api:dev .
docker run --rm -p 8080:8080 cert-store-api:dev
```

### 2.2 Frontend Docker Image

```powershell
cd .\frontend\cert-store-ui
docker build -t cert-store-ui:dev .
docker run --rm -p 4201:80 cert-store-ui:dev
```

## 3. Continuous Integration

The GitHub Actions workflow is stored at:

```text
`.github/workflows/ci.yml`
```

It performs:
- backend build
- frontend build
- backend Docker image build
- frontend Docker image build
- image publishing to GHCR

Validation:
- open the GitHub repository
- go to the Actions tab
- verify that the latest workflow run is successful

## 4. GitHub Container Registry

The generated images are published to GitHub Container Registry.

Typical image names:
- ghcr.io/<repository-owner>/cert-store-api:latest
- ghcr.io/<repository-owner>/cert-store-ui:latest

Validation:
- open the repository or profile Packages section
- verify that both images are available

## 5. Kubernetes Deployment

### 5.1 Apply Backend and Frontend Manifests

Manifest location:

```text
deploy/k8s/
```

Apply them with:

```powershell
kubectl apply -f .\deploy\k8s\backend.yaml
kubectl apply -f .\deploy\k8s\frontend.yaml
```

Verify the resources:

```powershell
kubectl get deployments
kubectl get pods
kubectl get services
```

## 6. MongoDB Installation with Helm

### 6.1 Add Helm Repository

```powershell
helm repo add bitnami https://charts.bitnami.com/bitnami
helm repo update
```

### 6.2 Install MongoDB

```powershell
helm install cert-store-mongodb bitnami/mongodb
```

Validation:

```powershell
helm list
kubectl get pods
kubectl get services
```

## 7. ArgoCD Installation

### 7.1 Create Namespace

```powershell
kubectl create namespace argocd
```

### 7.2 Install ArgoCD

```powershell
kubectl apply -n argocd --server-side --force-conflicts -f https://raw.githubusercontent.com/argoproj/argo-cd/stable/manifests/install.yaml
```

Validation:

```powershell
kubectl get pods -n argocd
kubectl get services -n argocd
```

## 8. Accessing ArgoCD

Use port forwarding:

```powershell
kubectl port-forward svc/argocd-server -n argocd 8081:443
```

Open in browser:

```text
https://localhost:8081
```

### Initial Login

Username:

```text
admin
```

Retrieve the initial password:

```powershell
kubectl get secret argocd-initial-admin-secret -n argocd -o jsonpath="{.data.password}"
```

Decode the returned base64 value if needed:

```powershell
[System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String((kubectl get secret argocd-initial-admin-secret -n argocd -o jsonpath="{.data.password}")))
```

## 9. ArgoCD Application

Application manifest location:


`deploy/argocd/app.yaml`


Apply it with:

powershell
`kubectl apply -f .\deploy\argocd\app.yaml`

Validation:

```powershell
kubectl get applications -n argocd
```

In the ArgoCD UI, the application should appear as:
- Healthy
- Synced

## 10. Validation Checklist

A full validation of the project should include the following checks.

### Application Level
- backend starts successfully
- frontend starts successfully
- GET /api/health works
- GET /api/root-certificates returns data
- GET /api/user-certificates returns data
- certificate cards are displayed in the frontend

### Container Level
- backend Docker image builds successfully
- frontend Docker image builds successfully
- backend container runs
- frontend container runs

### CI/CD Level
- GitHub Actions workflow is successful
- GHCR images are available

### Kubernetes / GitOps Level
- frontend and backend deployments are created
- pods are running
- services are created
- MongoDB Helm release exists
- ArgoCD is installed
- ArgoCD application is Healthy and Synced

## 11. Notes

In a local Kubernetes environment, port forwarding is an acceptable solution for validating internal services such as MongoDB and ArgoCD.

In a production-ready environment, these internal access methods would normally be replaced by ingress or other permanent exposure strategies.
