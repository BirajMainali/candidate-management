# Documentation for Candidate Management Project

This document overviews the project structure and its purpose.


## Project Structure

### Root Directory
- **`CandidateManagement.sln`**: The solution file to manage all projects.
- **`compose.yaml`**: Configuration for Docker Compose.
- **`.dockerignore`**: Files and folders to exclude during Docker image build.

### Source Code (`src`)

#### 1. Application Layer (`CandidateManagement.Application`)
- Handles business logic and service definitions.
- components:
  - `DependencyResolution.cs`: Manages dependency injection.
  - `CandidateDto.cs`: Data Transfer Object (DTO) for candidate information.
  - `CandidateService.cs` and `ICandidateService.cs`: Business logic and its interface.

#### 2. Contracts Layer (`CandidateManagement.Contracts`)
- Defines API contracts and request models.
- components:
  - `CandidateRequest.cs`: Structure for API request payloads.

#### 3. Domain Layer (`CandidateManagement.Domain`)
- Core domain logic and entities.
- components:
  - `Candidate.cs`: Represents a candidate entity.
  - `IEntity.cs`: Base interface for all entities.

#### 4. Infrastructure Layer (`CandidateManagement.Infrastructure`)
- Handles data persistence and database interactions.
- components:
  - `CandiateHubDbContext.cs`: Entity Framework Core database context.
  - Repositories for database operations (e.g., `CandidateRepository.cs`).
  - Database: The project uses PostgreSQL for database management

#### 5. Presentation Layer (`CandidateManagement.Presentation`)
- Contains API controllers.
- components:
  - `CandidateController.cs`: Manages candidate-related API endpoints.

#### 6. Web Layer (`CandidateManagement.Web`)
- The entry point for the application.
- components:
  - `Program.cs`: Configures and runs the application.
  - `appsettings.json`: Configuration settings.
  - `Dockerfile`: Instructions for building the Docker image.

### Tests (`test`)
The `test` directory contains unit and integration tests for each layer:
- Example: `CandidateManagement.Application.Tests` tests the application layer.
- Placeholder files like `UnitTest1.cs` are ready for test cases.

## Additional Notes
- The project includes Docker support for containerization.
- EF Core is used for database interactions, with migrations stored under `Infrastructure/Migrations/`.
- Testing is organized by layer, promoting modularity.

## Suggestions for Improvement
- Document API endpoints for better integration support.
- Enhance Docker setup for production readiness.

## Development Time

The development of this project was completed in approximately 5 hours. This rapid turnaround was made possible through efficient planning, modular design, and leveraging modern development tools like Entity Framework Core and Docker for seamless integration and deployment.

