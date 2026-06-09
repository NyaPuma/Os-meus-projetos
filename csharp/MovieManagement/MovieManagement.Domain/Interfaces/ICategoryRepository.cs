using MovieManagement.Domain.Entities;

namespace MovieManagement.Domain.Interfaces
{
    // Isolate data access from business logic
    public interface ICategoryRepository
    {
        void Add(Category category);

        List<Category> GetAll();

        Category? GetByName(string name);

        bool Remove(int id);
    }
}
