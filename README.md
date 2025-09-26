# Watch Assets - Asset Monitoring System

A comprehensive asset monitoring and search system built with .NET Core and Angular, designed for enterprise-scale asset management with distributed system capabilities.

## Features

- Advanced search algorithms with semantic search capabilities
- Azure Blob Storage integration for asset storage
- Real-time health monitoring and performance analytics
- Distributed system architecture with performance monitoring
- RESTful API design with comprehensive endpoints
- Docker containerization for deployment
- CI/CD pipeline with GitLab
- Test-driven development approach

## Technologies Used

- **Backend**: .NET Core 6.0, Entity Framework Core
- **Frontend**: Angular 13
- **Cloud**: Azure Blob Storage
- **Database**: Entity Framework with In-Memory provider
- **Containerization**: Docker
- **CI/CD**: GitLab CI
- **Monitoring**: Performance logging and health checks

## Setup

1. Clone the repository
2. Run `dotnet run` in ServerApp directory
3. Navigate to ClientApp and run `npm install` then `ng serve`

## API Endpoints

- `GET /api/assets` - Get all assets
- `POST /api/assetsearch/search` - Search assets
- `POST /api/advancedsearch/semantic-search` - Semantic search
- `GET /api/systemhealth` - System health check
- `GET /api/health-summary` - Health analytics

## Architecture

This system demonstrates enterprise-scale distributed system design with:
- Search algorithm implementation and optimization
- Cloud integration (Azure Blob Storage)
- Performance monitoring and analytics
- Test-driven development practices
- Containerization and deployment strategies
- Real-time monitoring capabilities