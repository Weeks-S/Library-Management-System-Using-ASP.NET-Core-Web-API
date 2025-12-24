# Library Management System

A comprehensive .NET 8.0 backend for library management, featuring user authentication, book catalog management, and integration with OpenLibrary API. Built using ASP.NET Core, Entity Framework Core, and JWT tokens.

## Features

- **User Management**: Registration, login, and user CRUD operations
- **Book Management**: Full CRUD operations for books with automatic data fetching
- **OpenLibrary Integration**: Automatically fetch book details and author information
- **JWT-based Authentication**: Secure API access with token-based auth
- **PostgreSQL Database**: Robust data persistence with Entity Framework Core
- **Repository Pattern**: Clean data access layer
- **Clean Architecture**: Separation of concerns across layers
- **Swagger API Documentation**: Interactive API docs
- **BCrypt Password Hashing**: Secure password storage

## Technologies Used

- **Framework**: ASP.NET Core 8.0
- **Database**: PostgreSQL with Entity Framework Core
- **Authentication**: JWT Bearer tokens
- **External API**: OpenLibrary.NET for book data
- **Password Hashing**: BCrypt.Net
- **ORM**: Entity Framework Core
- **API Documentation**: Swagger/OpenAPI
- **Environment Config**: DotNetEnv for .env files

## Prerequisites

- .NET 8.0 SDK
- PostgreSQL database
- Internet connection (for OpenLibrary API calls)
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

### Books

- `GET /api/books` - Get all books (requires authentication)
- `GET /api/books/{id}` - Get book by ID (requires authentication)
- `GET /api/books/search?title={title}&author={author}` - Search books by title or author (requires authentication)
- `POST /api/books` - Add a new book by title (fetches data from OpenLibrary, requires authentication)
- `PUT /api/books/{id}` - Update book details (requires authentication)
- `DELETE /api/books/{id}` - Delete a book (requires authentication)

## Project Structure

```
LibraryManagement/
├── Controllers/          # API controllers (AuthController, UsersController, BooksController)
├── Data/                 # Database context and configuration
├── DTOs/                 # Data Transfer Objects for requests/responses
├── Models/               # Entity models (User, Book)
├── Repositories/         # Data access layer with repository pattern
├── Services/             # Business logic layer
├── Migrations/           # Entity Framework database migrations
├── appsettings.json      # Application settings
├── Program.cs            # Application entry point
└── README.md            # This file
```

## Configuration

- `appsettings.json`: Application settings
- `appsettings.Development.json`: Development-specific settings
- Environment variables are loaded from `.env` file using DotNetEnv

## Database

The application uses PostgreSQL with Entity Framework Core. The database schema includes:

- **Users**: User accounts with authentication
- **Books**: Book catalog with title, author, and stock information

Update the connection string in your `.env` file to point to your database instance.

## Authentication

The API uses JWT (JSON Web Tokens) for authentication. Include the token in the Authorization header as `Bearer <token>` for protected endpoints.

## Book Management

Books can be added by providing just the title - the system automatically fetches detailed information (author, etc.) from the OpenLibrary API. The stock is initialized to 1 and can be updated manually.

## Development

- Use `dotnet watch run` for hot reloading during development
- Swagger UI provides interactive API documentation
- Entity Framework migrations handle database schema changes
- Clean architecture ensures maintainable and testable code

## License

This is a library management system project. Modify and use according to your needs.
