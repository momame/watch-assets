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
- Integrated with AWS S3 for file storage
- Added performance monitoring
- Need to optimize search queries

## Known Issues
- Search performance degrades with large datasets
- AWS credentials need to be properly secured
- Need to add proper error handling

## Next Steps
- Add caching layer
- Implement proper logging
- Add unit tests for all controllers