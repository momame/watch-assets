# Watch Assets - Asset Monitoring System

A comprehensive asset monitoring and search system built with .NET Core and Angular, designed for enterprise-scale asset management.

## Features

- Advanced search algorithms with semantic search capabilities
- AWS S3 integration for asset storage
- Real-time health monitoring
- Performance analytics
- RESTful API design
- Docker containerization
- CI/CD pipeline with GitLab

## Technologies Used

- **Backend**: .NET Core 6.0, Entity Framework Core
- **Frontend**: Angular 13
- **Cloud**: AWS S3
- **Database**: Entity Framework with In-Memory provider
- **Containerization**: Docker
- **CI/CD**: GitLab CI

## Setup

1. Clone the repository
2. Run `dotnet run` in ServerApp directory
3. Navigate to ClientApp and run `npm install` then `ng serve`

## API Endpoints

- `GET /api/assets` - Get all assets
- `POST /api/assetsearch/search` - Search assets
- `GET /api/advancedsearch/semantic-search` - Semantic search
- `GET /api/health` - Health check

## Testing

Run tests with: `dotnet test`

## Architecture

This system demonstrates:
- Distributed system design
- Search algorithm implementation
- Cloud integration (AWS)
- Test-driven development
- Enterprise-scale architecture