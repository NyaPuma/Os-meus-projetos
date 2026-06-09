using MovieManagement.Data.Repositories;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Data
{
    // Factory for creating repository instances. Allows switching between in-memory and SQLite implementations.
    public static class RepositoryFactory
    {
        public enum PersistenceType
        {
            InMemory,
            Sqlite
        }

        // Creates a film repository based on the specified persistence type.
        public static IFilmRepository CreateFilmRepository(PersistenceType persistenceType)
        {
            return persistenceType switch
            {
                PersistenceType.InMemory => new FilmRepository(),
                PersistenceType.Sqlite => new FilmSqliteRepository(),
                _ => throw new ArgumentException($"Unknown persistence type: {persistenceType}", nameof(persistenceType))
            };
        }

        // Creates a director repository based on the specified persistence type.
        public static IDirectorRepository CreateDirectorRepository(PersistenceType persistenceType)
        {
            return persistenceType switch
            {
                PersistenceType.InMemory => new DirectorRepository(),
                PersistenceType.Sqlite => new DirectorSqliteRepository(),
                _ => throw new ArgumentException($"Unknown persistence type: {persistenceType}", nameof(persistenceType))
            };
        }

        // Creates a category repository based on the specified persistence type.
        public static ICategoryRepository CreateCategoryRepository(PersistenceType persistenceType)
        {
            return persistenceType switch
            {
                PersistenceType.InMemory => new CategoryRepository(),
                PersistenceType.Sqlite => new CategorySqliteRepository(),
                _ => throw new ArgumentException($"Unknown persistence type: {persistenceType}", nameof(persistenceType))
            };
        }
    }
}
