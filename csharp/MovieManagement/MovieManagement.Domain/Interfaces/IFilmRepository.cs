using MovieManagement.Domain.Entities;

namespace MovieManagement.Domain.Interfaces
{
    // Isolate data access from business logic
    public interface IFilmRepository
    {
        void Add(Film film);

        List<Film> GetAll();

        Film? GetByTitle(string title);

        bool Remove(int id);
    }
}
