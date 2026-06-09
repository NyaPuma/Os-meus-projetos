using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        // Use dictionaries for O(1) id and name lookups and to enforce name uniqueness
        private readonly Dictionary<int, Category> _byId = [];
        private readonly Dictionary<string, int> _nameIndex = new(StringComparer.OrdinalIgnoreCase);
        private readonly Lock _sync = new();
        private int _proximoId = 1;

        public void Add(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);

            var name = category.Name?.Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(category));

            lock (_sync)
            {
                if (_nameIndex.ContainsKey(name!))
                    throw new InvalidOperationException("Category name already exists");

                category.Name = name!; // normalized name
                category.Id = _proximoId++;

                _byId[category.Id] = category;
                _nameIndex[category.Name] = category.Id;
            }
        }

        public List<Category> GetAll()
        {
            // Return a snapshot list of values; avoids exposing internal structures
            lock (_sync)
            {
                return [.. _byId.Values];
            }
        }

        public Category? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));

            name = name.Trim();
            lock (_sync)
            {
                if (_nameIndex.TryGetValue(name, out var id) && _byId.TryGetValue(id, out var category))
                    return category;
            }

            return null;
        }

        public bool Remove(int id)
        {
            lock (_sync)
            {
                if (!_byId.TryGetValue(id, out var category))
                    return false;

                _byId.Remove(id);
                if (!string.IsNullOrWhiteSpace(category.Name))
                    _nameIndex.Remove(category.Name);

                return true;
            }
        }
    }
}
