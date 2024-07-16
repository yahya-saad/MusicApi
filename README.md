# Music API

## Overview

This API is designed to manage a music platform with features similar to those found on services like Spotify or Anghami. It supports user authentication, role-based access control (RBAC), file uploads using Cloudinary, and pagination for efficient data retrieval.

## Features

- **Cloudinary for File Uploads**: Easily upload and manage images for songs, albums, and artists.
- **RBAC Using JWT Bearer**: Secure endpoints with JSON Web Tokens and manage user roles.
- **Pagination**: Efficiently handle large datasets with pagination.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Cloudinary Account](https://cloudinary.com/)

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/yahya-saad/music-api.git
   cd music-api
   ```

2. **Restore packages**

   ```bash
   dotnet restore
   ```

3. **Set up the database**

   - Update the connection string in `appsettings.json` to point to your database.
   - Run the migrations to set up the database schema.
     ```bash
     dotnet ef database update
     ```

4. **Configure appsetting.json**

   - Add your Cloudinary credentials , jwtSettings inside the `appsettings.json`.

   ```json
   "CloudinarySettings": {
     "CloudName": "your_cloud_name",
     "ApiKey": "your_api_key",
     "ApiSecret": "your_api_secret"
   }
   ```

   ```json
     "JwtSettings": {
    "SecretKey": "",
    "Issuer": "",
    "Audience": "",
    "ExpirationInMinutes": 30
   }
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

### Usage

Using Postman Collection attatched with repo or [Swagger] to interact with the API endpoints.

## Contributing

Contributions are welcome! Please create a pull request or open an issue to discuss changes.

[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/yahya-saad)
