using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using MovieManagement.Business.Utilities;

namespace MovieManagement.Business.Services
{
    public class FilmService(IFilmRepository repository, IDirectorRepository directorRepository, ICategoryRepository categoryRepository)
    {
        private readonly IFilmRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        private readonly IDirectorRepository _directorRepository = directorRepository ?? throw new ArgumentNullException(nameof(directorRepository));
        private readonly ICategoryRepository _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));

        // Interactively adds a film with user input and validation.
        public void InteractiveAddFilm()
        {
            try
            {
                string title = PromptForValidTitle();
                int year = PromptForValidYear();
                string language = InputValidator.PromptForNonEmptyString("Language: ");
                int rating = PromptForValidRating();
                int directorId = PromptForValidDirector();
                int categoryId = PromptForValidCategory();

                if (directorId <= 0 || categoryId <= 0)
                    throw new InvalidOperationException("Cannot add film without director and category.");

                Film newFilm = new(title, year, language, rating, directorId, categoryId);
                _repository.Add(newFilm);
                Console.WriteLine($"Film '{title}' added successfully!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error adding film: {ex.Message}", ex);
            }
        }

        private string PromptForValidTitle()
        {
            while (true)
            {
                try
                {
                    string title = InputValidator.PromptForNonEmptyString("Title: ");
                    return InputValidator.ValidateTitle(title, titleToCheck =>
                        _repository.GetByTitle(titleToCheck) == null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Please try again.");
                }
            }
        }

        private static int PromptForValidYear()
        {
            while (true)
            {
                try
                {
                    int year = InputValidator.PromptForInteger("Year: ");
                    return InputValidator.ValidateYear(year);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Please try again.");
                }
            }
        }

        private static int PromptForValidRating()
        {
            while (true)
            {
                try
                {
                    int rating = InputValidator.PromptForInteger("Rating (0-5): ");
                    return InputValidator.ValidateRating(rating);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Please try again.");
                }
            }
        }

        private int PromptForValidDirector()
        {
            var directors = _directorRepository.GetAll();
            if (directors.Count == 0)
            {
                Console.WriteLine("Error: No directors available. Please add a director first.");
                return -1;
            }

            Console.WriteLine("\nAvailable Directors:");
            foreach (var director in directors)
            {
                Console.WriteLine($"  {director.Id}: {director.Name} ({director.Country})");
            }

            int directorId = InputValidator.PromptForInteger("Select Director ID: ");
            if (directors.Any(d => d.Id == directorId))
                return directorId;

            Console.WriteLine("Error: Invalid director ID.");
            return -1;
        }

        private int PromptForValidCategory()
        {
            var categories = _categoryRepository.GetAll();
            if (categories.Count == 0)
            {
                Console.WriteLine("Error: No categories available. Please add a category first.");
                return -1;
            }

            Console.WriteLine("\nAvailable Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine($"  {category.Id}: {category.Name}");
            }

            int categoryId = InputValidator.PromptForInteger("Select Category ID: ");
            if (categories.Any(c => c.Id == categoryId))
                return categoryId;

            Console.WriteLine("Error: Invalid category ID.");
            return -1;
        }

        // Programmatically adds a film with full validation.
        public void AddFilm(string title, int year, string language, int rating, int directorId, int categoryId)
        {
            ArgumentNullException.ThrowIfNull(title);
            ArgumentNullException.ThrowIfNull(language);

            InputValidator.ValidateNonEmptyString(title, nameof(title));
            InputValidator.ValidateTitle(title, titleToCheck => _repository.GetByTitle(titleToCheck) == null);
            InputValidator.ValidateYear(year);
            InputValidator.ValidateNonEmptyString(language, nameof(language));
            InputValidator.ValidateRating(rating);
            InputValidator.ValidateId(directorId, nameof(directorId));
            InputValidator.ValidateId(categoryId, nameof(categoryId));

            // Verify foreign keys exist
            var directors = _directorRepository.GetAll();
            if (!directors.Any(d => d.Id == directorId))
                throw new ArgumentException($"Director with ID {directorId} does not exist", nameof(directorId));

            var categories = _categoryRepository.GetAll();
            if (!categories.Any(c => c.Id == categoryId))
                throw new ArgumentException($"Category with ID {categoryId} does not exist", nameof(categoryId));

            Film newFilm = new(title, year, language, rating, directorId, categoryId);
            _repository.Add(newFilm);
        }

        // Lists all films.
        public List<Film> ListAll() => _repository.GetAll();

        // Finds a film by title.
        public Film? FindByTitle(string title) => _repository.GetByTitle(title);

        // Removes a film by ID.
        public void RemoveFilm(int id)
        {
            if (!_repository.Remove(id))
                throw new KeyNotFoundException("Film not found");
        }

        // Filters films by exact year.
        public List<Film> FilterByYear(int year) =>
            [.. _repository.GetAll().Where(f => f.Year == year)];

        // Filters films by year range (inclusive).
        public List<Film> FilterByYearRange(int minYear, int maxYear) =>
            [.. _repository.GetAll().Where(f => f.Year >= minYear && f.Year <= maxYear)];

        // Filters films by language (case-insensitive).
        public List<Film> FilterByLanguage(string language)
        {
            InputValidator.ValidateNonEmptyString(language, nameof(language));
            return [.. _repository.GetAll()
                .Where(f => f.Language.Equals(language, StringComparison.OrdinalIgnoreCase))];
        }

        // Filters films by exact rating.
        public List<Film> FilterByRating(int rating)
        {
            InputValidator.ValidateRating(rating);
            return [.. _repository.GetAll().Where(f => f.Rating == rating)];
        }

        // Filters films by minimum rating.
        public List<Film> FilterByMinimumRating(int minimumRating)
        {
            InputValidator.ValidateRating(minimumRating);
            return [.. _repository.GetAll().Where(f => f.Rating >= minimumRating)];
        }

        // Filters films by director.
        public List<Film> FilterByDirector(int directorId)
        {
            InputValidator.ValidateId(directorId, nameof(directorId));
            return [.. _repository.GetAll().Where(f => f.DirectorId == directorId)];
        }

        // Filters films by category.
        public List<Film> FilterByCategory(int categoryId)
        {
            InputValidator.ValidateId(categoryId, nameof(categoryId));
            return [.. _repository.GetAll().Where(f => f.CategoryId == categoryId)];
        }

        // Sorts films by title.
        public List<Film> SortByTitle(bool ascending = true) =>
            SortFilms(f => f.Title, ascending);

        // Sorts films by year.
        public List<Film> SortByYear(bool ascending = true) =>
            SortFilms(f => f.Year, ascending);

        // Sorts films by rating.
        public List<Film> SortByRating(bool ascending = true) =>
            SortFilms(f => f.Rating, ascending);

        // Sorts films by language.
        public List<Film> SortByLanguage(bool ascending = true) =>
            SortFilms(f => f.Language, ascending);

        private List<Film> SortFilms<T>(Func<Film, T> keySelector, bool ascending) where T : IComparable<T>
        {
            var sorted = _repository.GetAll().OrderBy(keySelector);
            return ascending ? [.. sorted] : [.. sorted.Reverse()];
        }

        // Performs an advanced search with multiple optional criteria.
        public List<Film> AdvancedSearch(string? title = null, int? year = null, string? language = null,
                                         int? minRating = null, int? directorId = null, int? categoryId = null)
        {
            var results = _repository.GetAll().AsEnumerable();

            if (!string.IsNullOrWhiteSpace(title))
                results = results.Where(f => f.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

            if (year.HasValue && year.Value > 0)
                results = results.Where(f => f.Year == year.Value);

            if (!string.IsNullOrWhiteSpace(language))
                results = results.Where(f => f.Language.Equals(language, StringComparison.OrdinalIgnoreCase));

            if (minRating.HasValue)
            {
                InputValidator.ValidateRating(minRating.Value);
                results = results.Where(f => f.Rating >= minRating.Value);
            }

            if (directorId.HasValue && directorId.Value > 0)
                results = results.Where(f => f.DirectorId == directorId.Value);

            if (categoryId.HasValue && categoryId.Value > 0)
                results = results.Where(f => f.CategoryId == categoryId.Value);

            return [.. results];
        }

        // Gets films grouped by director.
        public Dictionary<int, List<Film>> GetFilmsByDirector() =>
            _repository.GetAll()
                .GroupBy(f => f.DirectorId)
                .ToDictionary(g => g.Key, g => g.ToList());

        // Gets films grouped by category.
        public Dictionary<int, List<Film>> GetFilmsByCategory() =>
            _repository.GetAll()
                .GroupBy(f => f.CategoryId)
                .ToDictionary(g => g.Key, g => g.ToList());

        // Gets film count grouped by language.
        public Dictionary<string, int> GetFilmsByLanguage() =>
            _repository.GetAll()
                .GroupBy(f => f.Language)
                .ToDictionary(g => g.Key, g => g.Count());

        // Gets film count grouped by year.
        public Dictionary<int, int> GetFilmsByYear() =>
            _repository.GetAll()
                .GroupBy(f => f.Year)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());

        // Gets film count grouped by rating.
        public Dictionary<int, int> GetFilmsByRating() =>
            _repository.GetAll()
                .GroupBy(f => f.Rating)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());

        // Gets comprehensive statistics about films.
        public FilmStatistics GetFilmStatistics()
        {
            var films = _repository.GetAll();

            if (films.Count == 0)
                return new FilmStatistics();

            return new FilmStatistics
            {
                TotalFilms       = films.Count,
                AverageYear      = (int)films.Average(f => f.Year),
                AverageRating    = films.Average(f => f.Rating),
                MostRecentYear   = films.Max(f => f.Year),
                OldestYear       = films.Min(f => f.Year),
                HighestRating    = films.Max(f => f.Rating),
                LowestRating     = films.Min(f => f.Rating),
                UniqueLanguages  = films.Select(f => f.Language).Distinct().Count(),
                UniqueDirectors  = films.Select(f => f.DirectorId).Distinct().Count(),
                UniqueCategories = films.Select(f => f.CategoryId).Distinct().Count()
            };
        }
    }

    // Statistics about films in the system.
    public class FilmStatistics
    {
        public int TotalFilms { get; set; }
        public int AverageYear { get; set; }
        public double AverageRating { get; set; }
        public int MostRecentYear { get; set; }
        public int OldestYear { get; set; }
        public int HighestRating { get; set; }
        public int LowestRating { get; set; }
        public int UniqueLanguages { get; set; }
        public int UniqueDirectors { get; set; }
        public int UniqueCategories { get; set; }
    }
}