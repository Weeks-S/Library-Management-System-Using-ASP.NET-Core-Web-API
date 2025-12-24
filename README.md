# LibraryManagement

A .NET 8.0 backend template demonstrating user management with authentication, built using ASP.NET Core, Entity Framework Core, and JWT tokens.

## Features

- User registration and login
- JWT-based authentication
- PostgreSQL database integration with Entity Framework Core
- Repository pattern implementation
- Clean architecture with separation of concerns
- Swagger API documentation (in development)
- BCrypt password hashing

## Technologies Used

- **Framework**: ASP.NET Core 8.0
- **Database**: PostgreSQL with Entity Framework Core
- **Authentication**: JWT Bearer tokens
- **Password Hashing**: BCrypt.Net
- **ORM**: Entity Framework Core
- **API Documentation**: Swagger/OpenAPI

## Prerequisites

- .NET 8.0 SDK
- PostgreSQL database
- Environment variables configured (see below)

## Installation

1. Clone the repository:

   ```bash
   git clone <repository-url>
   cd LibraryManagement
   ```

2. Restore NuGet packages:

   ```bash
   dotnet restore
   ```

3. Set up environment variables. Create a `.env` file in the root directory with the following:

   ```
   DB_CONNECTION=Host=localhost;Database=LibraryManagement;Username=your_username;Password=your_password
   JWT_KEY=your_super_secret_jwt_key_here
   JWT_ISSUER=your_issuer
   JWT_AUDIENCE=your_audience
   ```

4. Run database migrations:
   ```bash
   dotnet ef database update
   ```

## Running the Application

1. Start the application:

   ```bash
   dotnet run
   ```

2. The API will be available at `https://localhost:5001` (or the port configured in `launchSettings.json`)

3. In development, Swagger UI is available at `https://localhost:5001/swagger`

## API Endpoints

### Authentication

- `POST /api/auth/login` - User login (returns JWT token)

### Users

- `POST /api/users` - Register a new user
- `GET /api/users` - Get all users (requires authentication)
- `GET /api/users/{id}` - Get user by ID (requires authentication)
- `PUT /api/users/{id}` - Update user (requires authentication)
- `DELETE /api/users/{id}` - Delete user

## Project Structure

- **Controllers/**: API controllers (AuthController, UsersController)
- **Data/**: Database context and configuration
- **DTOs/**: Data Transfer Objects for requests/responses
- **Model/**: Entity models (User)
- **Repositories/**: Data access layer with repository pattern
- **Services/**: Business logic layer
- **Migrations/**: Entity Framework database migrations

## Configuration

- `appsettings.json`: Application settings
- `appsettings.Development.json`: Development-specific settings
- Environment variables are loaded from `.env` file using DotNetEnv

## Database

The application uses PostgreSQL. Update the connection string in your `.env` file to point to your database instance.

## Authentication

The API uses JWT (JSON Web Tokens) for authentication. Include the token in the Authorization header as `Bearer <token>` for protected endpoints.

## Development

- Use `dotnet watch run` for hot reloading during development
- Swagger UI provides interactive API documentation
- Entity Framework migrations handle database schema changes

## License

This is a template project. Modify and use according to your needs.
