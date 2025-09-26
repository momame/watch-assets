# Development Notes

## Iteration 1
- Started with basic asset tracking
- Used in-memory DB for quick prototyping
- Basic CRUD operations working

## Iteration 2
- Added search functionality
- Realized we need better scoring algorithm
- Added health monitoring

## Iteration 3
- Integrated with Azure Blob Storage for file storage
- Added performance monitoring
- Need to optimize search queries

## Known Issues
- Search performance degrades with large datasets
- Direct database access in controllers - needs service layer abstraction
- Need to add proper error handling
- AWS credentials need to be properly secured (Note: Now using Azure)

## Next Steps
- Add caching layer
- Implement proper logging configuration
- Add unit tests for all controllers
- Implement service layer for better separation of concerns
- Add comprehensive error handling and logging
- Consider moving to proper database for production

## Architecture Notes
- Current implementation has direct DbContext access in controllers
- Planned: Service layer to separate business logic from controllers
- This will improve testability and maintainability
- Follows clean architecture principles