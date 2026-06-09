using MovieManagement.Domain.Entities;

namespace MovieManagement.Domain.Interfaces
{
    // Isolate data access from business logic
    public interface IDirectorRepository
    {
        void Add(Director director);

        List<Director> GetAll();

        Director? GetByName(string name);

        bool Remove(int id);
    }
}
