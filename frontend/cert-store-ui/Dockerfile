# Build stage: installs dependencies and builds the Angular application.
FROM node:22 AS build
WORKDIR /app

# Copy package files first for better layer caching.
COPY package*.json ./
RUN npm install

# Copy the remaining source files and build the Angular app.
COPY . .
RUN npm run build

# Runtime stage: serves the built frontend with nginx.
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Copy the built Angular files into the nginx web root.
COPY --from=build /app/dist/cert-store-ui/browser .

# Exposes the default nginx HTTP port.
EXPOSE 80