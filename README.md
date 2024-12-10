# HearthStone

This project is a Hearthstone API developed using the Clean Architecture and Domain-Driven Design (DDD) principles. The solution is structured to adhere to the SOLID principles, ensuring a modular, maintainable, and scalable codebase.

### Project Overview
-  Domain Layer: Contains the core business logic and entities (e.g., Card, Rarity, CardSet).
-  Web API Layer: Exposes RESTful endpoints for interacting with the Hearthstone data. This layer depends on the application and domain layers for implementing use cases.
-  Data Layer: Manages data persistence using Entity Framework Core with a Repository Pattern. This layer is responsible for storing and retrieving data from the database.
-  Worker Service: Implements Hangfire jobs to periodically upsert data from a public API into the database. The worker service is hosted separately for background tasks.
  
### Environment Configuration
-  To run the Web API, you must add an .env file at the root of the Web API project containing the database connection string. The .env file should look like this:
### ConnectionString={YourConnectionString}

### Key Features
- Modularized architecture based on Clean Architecture and DDD principles.
- SOLID principles applied to ensure loosely coupled components.
- Hangfire integration for recurring tasks (data upsert every hour).
- MSSQL database for data storage.
- Public API integration to fetch Hearthstone data.
- Extensible design to add new features or integrate other systems in the future.
