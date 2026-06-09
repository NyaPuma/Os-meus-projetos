using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Data.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        // Use dictionaries for O(1) id and title lookups and to enforce title uniqueness
        private readonly Dictionary<int, Film> _byId = [];
        private readonly Dictionary<string, int> _titleIndex = new(StringComparer.OrdinalIgnoreCase);
        private readonly Lock _sync = new();
        private int _proximoId = 1;

        public void Add(Film film)
        {
            ArgumentNullException.ThrowIfNull(film);

            var title = film.Title?.Trim();
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required", nameof(film));

            // Validate rating (0 to 5)
            if (film.Rating < 0 || film.Rating > 5)
                throw new ArgumentOutOfRangeException(nameof(film), "Rating must be between 0 and 5");

            // Validate foreign keys
            if (film.DirectorId <= 0)
                throw new ArgumentException("DirectorId must be greater than 0", nameof(film));

            if (film.CategoryId <= 0)
                throw new ArgumentException("CategoryId must be greater than 0", nameof(film));

            lock (_sync)
            {
                if (_titleIndex.ContainsKey(title!))
                    throw new InvalidOperationException("Title already exists");

                film.Title = title!; // normalized title
                film.Id = _proximoId++;

                _byId[film.Id] = film;
                _titleIndex[film.Title] = film.Id;
            }
        }

        public List<Film> GetAll()
        {
            // Return a snapshot list of values; avoids exposing internal structures
            lock (_sync)
            {
                return [.. _byId.Values];
            }
        }

        public Film? GetByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required", nameof(title));

            title = title.Trim();
            lock (_sync)
            {
                if (_titleIndex.TryGetValue(title, out var id) && _byId.TryGetValue(id, out var film))
                    return film;
            }

            return null;
        }

        public bool Remove(int id)
        {
            lock (_sync)
            {
                if (!_byId.TryGetValue(id, out var film))
                    return false;

                _byId.Remove(id);
                if (!string.IsNullOrWhiteSpace(film.Title))
                    _titleIndex.Remove(film.Title);

                return true;
            }
        }
    }
}
