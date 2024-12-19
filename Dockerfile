# Stage 1: Build the React Vite PWA
FROM node:22.9.0 AS build

# Set working directory
WORKDIR /app

# Copy package.json and package-lock.json
COPY ./package*.json ./

# Install dependencies
RUN npm install -g pnpm
RUN pnpm install

# Copy the React Vite PWA source code
COPY . ./

# Build the React Vite PWA
RUN pnpm run build

# Stage 2: Serve the React Vite PWA
FROM nginx:alpine AS release

# Copy built React Vite PWA from the previous stage
COPY --from=build /app/build /usr/share/nginx/html

# Copy the SSL certificates and Nginx configuration
COPY ./certificates /etc/ssl/certs/
COPY ./nginx/nginx.conf /etc/nginx/nginx.conf

# Expose ports 80 and 443 for HTTP and HTTPS
EXPOSE 80 443

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
