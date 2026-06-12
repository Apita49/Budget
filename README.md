# BudgetMan

A RESTful API for budget management built with .NET 6.0, MongoDB, and modern architectural patterns. This project showcases clean architecture principles, dependency injection, and best practices for building scalable APIs.

## Table of Contents
- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Docker Setup](#docker-setup)
- [API Documentation](#api-documentation)
- [Development](#development)

## Overview

BudgetMan is a REST API designed to manage budget periods and financial tracking. It demonstrates professional software architecture with:
- Clean separation of concerns
- Dependency injection for loose coupling
- MongoDB integration for document-based storage
- Swagger/OpenAPI documentation
- RESTful API design patterns

## Tech Stack

### Backend
- **Runtime:** .NET 6.0
- **Language:** C#
- **Framework:** ASP.NET Core
- **Documentation:** Swagger/OpenAPI (Swashbuckle)

### Database
- **MongoDB:** Document-based NoSQL database for data persistence

### Development Tools
- **Containerization:** Docker & Docker Compose
- **API Testing:** Swagger UI

## Architecture

BudgetMan follows a **Layered Architecture** pattern with clear separation of concerns:

```
┌─────────────────────────────────────────────────┐
│           API Layer (REST)                      │
│         BudgetMan.RestAPI                       │
│    - Controllers                                │
│    - HTTP Request/Response handling             │
└────────────────────┬────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────┐
│         Service/Business Logic Layer            │
│         BudgetMan.Service                       │
│    - IBudgetManService                          │
│    - Business rules & logic                     │
└────────────────────┬────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────┐
│      Data Access Layer (Repository Pattern)     │
│     BudgetMan.Dao.Interface                     │
│     BudgetMan.Dao.MongoDb (Implementation)      │
│    - Data access abstraction                    │
│    - MongoDB operations                         │
└────────────────────┬────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────┐
│         Domain & Models Layer                   │
│     BudgetMan.Domain                            │
│     BudgetMan.Dao.MongoDb.Domain                │
│    - Core entities                              │
│    - Business models                            │
└─────────────────────────────────────────────────┘
```

### Design Patterns Used
- **Repository Pattern:** Data access abstraction via `IBudgetManDao`
- **Dependency Injection:** Automatic service resolution and lifecycle management
- **Singleton Pattern:** For database and service instances
- **Interface Segregation:** Clean contracts between layers

## Project Structure

```
Budget/
├── BudgetMan/                          # REST API Layer (Presentation)
│   ├── Controllers/
│   │   └── BudgetManController.cs      # API endpoints
│   ├── Startup.cs                      # Service configuration
│   ├── Program.cs                      # Application entry point
│   ├── appsettings.json                # Configuration
│   └── BudgetMan.RestAPI.csproj
│
├── BudgetMan.Service/                  # Business Logic Layer
│   ├── IBudgetManService.cs            # Service contract
│   ├── BudgetManService.cs             # Service implementation
│   └── BudgetMan.Service.csproj
│
├── BudgetMan.Dao.Interface/            # Data Access Abstraction
│   ├── IBudgetManDao.cs                # Repository contract
│   └── BudgetMan.Dao.Interface.csproj
│
├── BudgetMan.Dao.MongoDb/              # MongoDB Implementation
│   ├── BudgetManDao.cs                 # MongoDB repository
│   └── BudgetMan.Dao.MongoDb.csproj
│
├── BudgetMan.Dao.MongoDb.Domain/       # MongoDB Models
│   └── BudgetMan.Dao.MongoDb.Domain.csproj
│
├── BudgetMan.Domain/                   # Core Business Entities
│   ├── DatabaseSetting.cs              # Configuration model
│   ├── PeriodModel.cs                  # Domain entity
│   └── BudgetMan.Domain.csproj
│
├── Dockerfile                          # Container image definition
├── docker-compose.yml                  # Multi-container orchestration
├── DOCKER_SETUP.md                     # Docker documentation
└── README.md                           # This file
```

## Getting Started

### Prerequisites
- .NET 6.0 SDK or later ([Download](https://dotnet.microsoft.com/download/dotnet/6.0))
- MongoDB instance running locally or accessible
- (Optional) Docker & Docker Compose for containerized setup

### Local Development

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd Budget
   ```

2. **Restore NuGet packages:**
   ```bash
   dotnet restore
   ```

3. **Update MongoDB connection (if needed):**
   Edit `BudgetMan/appsettings.json`:
   ```json
   "DatabaseSetting": {
     "ConnectionString": "mongodb://localhost:27017",
     "DatabaseName": "BudgetManDb"
   }
   ```

4. **Run the application:**
   ```bash
   dotnet run --project BudgetMan/BudgetMan.RestAPI.csproj
   ```

5. **Access the API:**
   - Swagger UI: http://localhost:5002/swagger
   - API Base URL: http://localhost:5002/v1.0

## Docker Setup

For containerized deployment with MongoDB, use Docker Compose:

### Quick Start

1. **Start all services:**
   ```bash
   docker-compose up --build
   ```

2. **Access the API:**
   - Swagger UI: http://localhost:5002/swagger

3. **Stop services:**
   ```bash
   docker-compose down
   ```

For detailed Docker instructions, see [DOCKER_SETUP.md](DOCKER_SETUP.md).

## API Documentation

### Base URL
```
http://localhost:5002/v1.0
```

### Endpoints

#### Hello
- **GET** `/BudgetMan/Hello`
- Returns a welcome message
- **Response:** `"Welcome to BudgetMan Service"`

#### Get Current Period
- **GET** `/BudgetMan/Actual`
- Retrieves the current budget period
- **Response:** 
  ```json
  {
    "id": "string",
    "name": "string",
    "startDate": "2024-01-01",
    "endDate": "2024-12-31"
  }
  ```

### Interactive Documentation
- Access Swagger UI at: http://localhost:5002/swagger
- Try API endpoints directly from the browser
- View request/response schemas

## Development

### Building the Solution

```bash
# Build all projects
dotnet build

# Build with specific configuration
dotnet build -c Release

# Run tests (if applicable)
dotnet test
```

## Configuration

### Environment Variables (Docker)
The application respects the following environment variables:

- `ASPNETCORE_ENVIRONMENT` - Environment mode (Development/Production)
- `ASPNETCORE_URLS` - Server URLs to listen on
- `DatabaseSetting__ConnectionString` - MongoDB connection string
- `DatabaseSetting__DatabaseName` - MongoDB database name
- `DatabaseSetting__PeriodCollectionName` - Collection name for periods

### Application Settings
Configuration is loaded from `appsettings.json` and environment-specific files:
- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Development overrides
- `appsettings.Docker.json` - Docker-specific configuration

## Status

**Active Development** - Core API structure and MongoDB integration complete. Additional endpoints and features are being developed.

## License

This project is a showcase of software architecture and best practices.