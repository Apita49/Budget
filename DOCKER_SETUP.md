# Docker Setup for BudgetMan API

This guide explains how to run the BudgetMan API with MongoDB using Docker Compose.

## Prerequisites

- Docker and Docker Compose installed on your system
  - [Install Docker Desktop](https://www.docker.com/products/docker-desktop) (includes Docker Compose)
  - Or [install Docker Engine](https://docs.docker.com/engine/install/) and [Docker Compose](https://docs.docker.com/compose/install/) separately

## Quick Start

1. **Clone or navigate to the project directory:**
   ```bash
   cd /path/to/Budget
   ```

2. **Start the services:**
   ```bash
   docker-compose up --build
   ```

   The first run will:
   - Build the .NET API image
   - Start MongoDB container
   - Start the API container
   - Automatically connect the API to MongoDB

3. **Access the API:**
   - Swagger UI: http://localhost:5002/swagger
   - API Health: http://localhost:5002/health (if available)

## Services

### MongoDB
- **Container Name:** `budget_mongodb`
- **Port:** `27017`
- **Database:** `BudgetManDb`
- **Data Persistence:** Data is stored in a Docker volume (`mongodb_data`) and persists between container restarts

### BudgetMan API
- **Container Name:** `budget_api`
- **Port:** `5002` (HTTP), `5003` (HTTPS)
- **Environment:** Production
- **Connection:** Automatically connects to MongoDB via the service name `mongodb`

## Common Commands

### Start the services
```bash
docker-compose up
```

### Start in detached mode (background)
```bash
docker-compose up -d
```

### Stop the services
```bash
docker-compose down
```

### Stop and remove all volumes (clears database)
```bash
docker-compose down -v
```

### View logs
```bash
# All services
docker-compose logs -f

# Specific service
docker-compose logs -f api
docker-compose logs -f mongodb
```

### Rebuild the API image (after code changes)
```bash
docker-compose up --build
```

### Only rebuild without starting
```bash
docker-compose build
```

## Configuration

### Environment Variables

The docker-compose.yml file sets these environment variables for the API:

- `ASPNETCORE_ENVIRONMENT`: Production
- `ASPNETCORE_URLS`: http://+:5002
- `DatabaseSetting__ConnectionString`: mongodb://mongodb:27017
- `DatabaseSetting__DatabaseName`: BudgetManDb
- `DatabaseSetting__PeriodCollectionName`: Period

To modify these, edit the `docker-compose.yml` file under the `api` service's `environment` section.

### Ports

To use different ports, modify the port mappings in `docker-compose.yml`:

```yaml
ports:
  - "8080:5002"  # Map to 8080 instead of 5002
```

## Troubleshooting

### API can't connect to MongoDB
- Check that MongoDB is healthy: `docker-compose ps`
- View MongoDB logs: `docker-compose logs mongodb`
- The API waits for MongoDB to be healthy before starting (healthcheck is configured)

### Build fails
```bash
# Clean rebuild
docker-compose down
docker-compose build --no-cache
docker-compose up
```

### Port already in use
If ports 5002, 5003, or 27017 are already in use, either:
1. Stop the services using those ports
2. Or modify the ports in `docker-compose.yml`

### Access MongoDB directly
```bash
docker exec -it budget_mongodb mongosh
```

## Development

For development, you can modify code and rebuild:

```bash
# After code changes
docker-compose up --build
```

The Dockerfile uses a multi-stage build:
- **Build stage**: Compiles the .NET project
- **Publish stage**: Creates the release package
- **Runtime stage**: Runs the compiled application with minimal dependencies

## Files Included

- `Dockerfile` - Multi-stage Docker image definition
- `docker-compose.yml` - Orchestration configuration
- `appsettings.Docker.json` - Optional Docker-specific settings

## Network

Both services communicate over a Docker bridge network named `budget_network`, allowing the API to reach MongoDB via the hostname `mongodb` (standard Docker service discovery).
