# Movie Management System

A well-structured .NET 10 C# 14 console application for managing films, directors, and categories with both in-memory and SQLite persistence options.

## Project Structure

```
MovieManagement/
├── MovieManagement.Domain/          # Domain entities and interfaces
│   ├── Entities/
│   │   ├── Film.cs
│   │   ├── Director.cs
│   │   └── Category.cs
│   └── Interfaces/
│       ├── IFilmRepository.cs
│       ├── IDirectorRepository.cs
│       └── ICategoryRepository.cs
│
├── MovieManagement.Business/        # Business logic and services
│   ├── Services/
│   │   ├── FilmService.cs
│   │   ├── DirectorService.cs
│   │   └── CategoryService.cs
│   └── Utilities/
│       └── InputValidator.cs
│
├── MovieManagement.Data/            # Data access layer
│   ├── Repositories/
│   │   ├── FilmRepository.cs
│   │   ├── FilmSqliteRepository.cs
│   │   ├── DirectorRepository.cs
│   │   ├── DirectorSqliteRepository.cs
│   │   ├── CategoryRepository.cs
│   │   └── CategorySqliteRepository.cs
│   └── RepositoryFactory.cs
│
└── MovieManagement.UI/              # Presentation layer
	├── Program.cs
	└── Utilities/
		├── ConsoleFormatter.cs
		└── MenuHelper.cs
```

## Features

### Film Management
- **Add Films**: Create new films with title, year, language, rating, director, and category
- **List Films**: View all films with complete details
- **Find Films**: Search by title
- **Remove Films**: Delete films from the system
- **Advanced Search**: Search with multiple criteria (title, year, language, rating, director, category)
- **Sorting**: Sort by title, year, rating, or language (ascending/descending)
- **Filtering**: Filter by year range, language, rating, director, or category
- **Reports**: View statistics and group films by various criteria

### Director Management
- Add, list, find, and remove directors
- Track director country information

### Category Management
- Add, list, find, and remove film categories

### Reporting
- **General Statistics**: Total films, average year/rating, highest/lowest ratings, unique counts
- **Group Analysis**: Films grouped by director, category, language, year, and rating

## Architecture

### Design Patterns
- **Repository Pattern**: Abstract data access with interface-based design
- **Dependency Injection**: Services receive dependencies via constructors
- **Factory Pattern**: Create repositories based on persistence type
- **Separation of Concerns**: Clear boundaries between domain, business, data, and UI layers

### Key Classes

#### Utilities
- **InputValidator**: Centralized validation for all user inputs
  - Validates titles, years, ratings, IDs, and strings
  - Prompts users for input with retry logic

- **ConsoleFormatter**: Consistent console output formatting
  - Headers, menus, messages, and statistics display
  - Success, error, warning, and info message types

- **MenuHelper**: Menu and user input handling
  - Gets menu choices
  - Validates integer inputs
  - Confirmation prompts
  - List selection

#### Services
Each service provides both interactive (user-prompting) and programmatic (validation-heavy) methods:

- **FilmService**: Complete film CRUD operations with advanced search and filtering
- **DirectorService**: Director CRUD operations
- **CategoryService**: Category CRUD operations

#### Repositories
Dual implementation for flexibility:

- **In-Memory**: `FilmRepository`, `DirectorRepository`, `CategoryRepository`
  - Dictionary-based O(1) lookups
  - Thread-safe with Lock synchronization
  - Fast for testing and small datasets

- **SQLite**: `FilmSqliteRepository`, `DirectorSqliteRepository`, `CategorySqliteRepository`
  - Persistent storage to `films.db`
  - Foreign key constraints enabled
  - Production-ready implementation

## Usage

### Switching Persistence Type

Edit the `Main` method in `Program.cs`:

```csharp
// Use in-memory repository
var persistenceType = RepositoryFactory.PersistenceType.InMemory;

// Or use SQLite
var persistenceType = RepositoryFactory.PersistenceType.Sqlite;
```

### Running the Application

```bash
dotnet run
```

### Main Menu
```
1 - Film Management
2 - Director Management
3 - Category Management
0 - Exit
```

## Technology Stack

- **.NET**: 10.0
- **C#**: 14.0
- **Database**: SQLite (optional)
- **ORM**: Direct SQL with parameterized queries
- **Threading**: Lock-based synchronization for thread safety

## Code Quality

- ✅ **SOLID Principles**: Single responsibility, Dependency inversion, Interface segregation
- ✅ **DRY (Don't Repeat Yourself)**: Validation logic centralized
- ✅ **Clean Code**: Meaningful names, small methods, clear intent
- ✅ **XML Documentation**: Comprehensive comments on public methods
- ✅ **Thread Safety**: Repositories use Lock for concurrent access
- ✅ **Error Handling**: Specific exception types with meaningful messages

## Performance Characteristics

- **In-Memory**: O(1) lookups by ID or name, O(n) iteration
- **SQLite**: Index-optimized queries, foreign key constraints
- **Memory Usage**: Dictionary index for fast lookups
- **Concurrency**: Thread-safe implementations prevent race conditions

## Future Enhancements

1. **Async Operations**: Convert repository methods to async/await
2. **Unit Tests**: Comprehensive test suite with xUnit
3. **Configuration**: Move hardcoded values to appsettings.json
4. **Logging**: Add ILogger integration with Serilog
5. **Validation**: Expand validation rules for business logic
6. **API Layer**: Expose functionality via REST API
7. **Data Export**: Export reports to CSV/PDF
8. **User Preferences**: Save user preferences (sort order, filters)

## Requirements

- .NET 10.0 SDK or later
- No external dependencies for core functionality
- Microsoft.Data.Sqlite for SQLite support (already included)

## Contributing

This project follows clean code principles and SOLID design patterns. When contributing:

1. Maintain separation of concerns
2. Add XML documentation to public members
3. Use InputValidator for all validation
4. Use ConsoleFormatter for all console output
5. Keep methods small and focused
6. Add appropriate exception handling

## License

See LICENSE file in the repository.

## Author

Original structure refactored for improved clarity and maintainability.
