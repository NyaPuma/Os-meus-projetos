using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Data.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        // Use dictionaries for O(1) id and name lookups and to enforce name uniqueness
        private readonly Dictionary<int, Director> _byId = [];
        private readonly Dictionary<string, int> _nameIndex = new(StringComparer.OrdinalIgnoreCase);
        private readonly Lock _sync = new();
        private int _proximoId = 1;

        public void Add(Director director)
        {
            ArgumentNullException.ThrowIfNull(director);

            var name = director.Name?.Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(director));

            var country = director.Country?.Trim();
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country is required", nameof(director));

            lock (_sync)
            {
                if (_nameIndex.ContainsKey(name!))
                    throw new InvalidOperationException("Director name already exists");

                director.Name    = name!; // normalized name
                director.Country = country!; // normalized country
                director.Id      = _proximoId++;

                _byId[director.Id] = director;
                _nameIndex[director.Name] = director.Id;
            }
        }

        public List<Director> GetAll()
        {
            // Return a snapshot list of values; avoids exposing internal structures
            lock (_sync)
            {
                return [.. _byId.Values];
            }
        }

        public Director? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));

            name = name.Trim();
            lock (_sync)
            {
                if (_nameIndex.TryGetValue(name, out var id) && _byId.TryGetValue(id, out var director))
                    return director;
            }

            return null;
        }

        public bool Remove(int id)
        {
            lock (_sync)
            {
                if (!_byId.TryGetValue(id, out var director))
                    return false;

                _byId.Remove(id);
                if (!string.IsNullOrWhiteSpace(director.Name))
                    _nameIndex.Remove(director.Name);

                return true;
            }
        }
    }
}
