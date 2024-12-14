# HearthStoneApp Documentation

## Project Overview
HearthStoneApp is a .NET 8-based solution designed to demonstrate a clean architecture implementation combined with Domain-Driven Design (DDD) principles. The solution includes both a WebAPI and a Worker Service, utilizing EF Core for data persistence and Hangfire for background job processing.

![image](https://github.com/user-attachments/assets/4ae21d80-8423-46b8-b8be-e99834e4fb4f)


## Table of Contents
1. [Project Structure](#project-structure)
2. [Setup Instructions](#setup-instructions)
3. [Environment Variables](#environment-variables)
4. [Frontend](#frontend)
5. [Database](#database)
6. [Background Job Configuration](#background-job-configuration)
7. [Technology Stack](#technology-stack)

## Project Structure
The solution is divided into the following projects:

- **HearthStoneApp.Application**
  - Contains Dtos, Profiles for AutoMapper configurations, Repository interfaces, and Services for business logic.
 

- **HearthStoneApp.Domain**
 - Holds entities under `Entities` folder.
 - 
- **HearthStoneApp.Infrastructure**
  - Contains the `Data` folder for `DbContext` and database migrations.
  - Implements repository patterns.

- **HearthStoneApp.WebApi**
  - Contains Controllers for defining API endpoints.

- **HearthStoneApp.WorkerService**
  - Implements Hangfire jobs under the `HostedService` folder.
  - Includes a `Services` folder for the external API logic.
  - Interfaces for jobs and service logic.

## Setup Instructions

### Prerequisites
- .NET 8 SDK
- MSSQL Server
- Node.js and npm (for the frontend setup)
- A valid API key for the external Hearthstone API.

### Steps to Run the Solution

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd HearthStoneApp
   ```

2. **Restore NuGet Packages**
   ```bash
   dotnet restore
   ```

3. **Set Up the Database**
   - Ensure MSSQL Server is running.
   - Update the connection string in the `.env` file for both WebAPI and WorkerService (see [Environment Variables](#environment-variables)).
   - Apply migrations:
     ```bash
     dotnet ef database update --project HearthStoneApp.Infrastructure
     ```

4. **Run the WebAPI**
   ```bash
   dotnet run --project HearthStoneApp.WebApi
   ```

5. **Run the Worker Service**
   ```bash
   dotnet run --project HearthStoneApp.WorkerService
   ```

6. **Set Up the Frontend**
   - Navigate to the frontend directory and install dependencies:
     ```bash
     cd frontend
     npm install
     ```
   - Start the frontend:
     ```bash
     npm run serve
     ```

## Environment Variables

Each project requires an `.env` file to be created manually at the root of the respective project directory. The following variables need to be defined:

### WebAPI `.env` File:
```
ConnectionString={Your-Database-Connection-String}
```

### WorkerService `.env` File:
```
ConnectionString={Your-Database-Connection-String}
RapidApiaKey=49a89ab881msh18ebcb276da4fcbp1bee0fjsn23b5638cac55
```

## Frontend
- **Technology:** Vue.js with TypeScript.
- **Features:**
  - Displays data in a filterable grid.
  - Connects to the WebAPI for data retrieval.

## Database
- **Technology:** MSSQL Server
- **Configuration:**
  - Ensure the `ConnectionString` in `.env` files points to a valid MSSQL Server instance.
  - Use EF Core migrations to create the necessary schema.

## Background Job Configuration
- **Technology:** Hangfire
- **Job:** `CardSyncJob`
  - Fetches data from the Hearthstone API.
  - Performs upsert operations on the database.
- **Schedule:** Configured to run every hour.

## Technology Stack
- **Backend:** .NET 8, C#
- **Frontend:** Vue.js, TypeScript
- **Database:** MSSQL Server
- **Job Scheduler:** Hangfire
- **External API:** Hearthstone API

