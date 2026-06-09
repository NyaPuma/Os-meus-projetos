using MovieManagement.Data;
using MovieManagement.Business.Services;
using MovieManagement.Domain.Interfaces;
using MovieManagement.Domain.Entities;
using MovieManagement.UI.Utilities;

namespace MovieManagement.UI
{
    internal class Program
    {
        static void Main()
        {
            // Choose persistence type: InMemory or Sqlite
            var persistenceType = RepositoryFactory.PersistenceType.InMemory;
            // Uncomment the line below to use SQLite instead of in-memory:
            // var persistenceType = RepositoryFactory.PersistenceType.Sqlite;

            // Create repositories and services
            var (filmService, directorService, categoryService) = InitializeServices(persistenceType);

            MainMenuLoop(filmService, directorService, categoryService);

            Console.WriteLine("\nGoodbye!");
        }

        private static (FilmService, DirectorService, CategoryService) InitializeServices(RepositoryFactory.PersistenceType persistenceType)
        {
            IFilmRepository filmRepo = RepositoryFactory.CreateFilmRepository(persistenceType);
            IDirectorRepository directorRepo = RepositoryFactory.CreateDirectorRepository(persistenceType);
            ICategoryRepository categoryRepo = RepositoryFactory.CreateCategoryRepository(persistenceType);

            return (
                new FilmService(filmRepo, directorRepo, categoryRepo),
                new DirectorService(directorRepo),
                new CategoryService(categoryRepo)
            );
        }

        private static void MainMenuLoop(FilmService filmService, DirectorService directorService, CategoryService categoryService)
        {
            bool continueLoop = true;

            while (continueLoop)
            {
                ConsoleFormatter.DisplayHeader("MAIN MENU");
                ConsoleFormatter.DisplayMenuOption("1", "Film Management");
                ConsoleFormatter.DisplayMenuOption("2", "Director Management");
                ConsoleFormatter.DisplayMenuOption("3", "Category Management");
                ConsoleFormatter.DisplayMenuOption("0", "Exit");
                ConsoleFormatter.DisplayMenuSeparator();

                string choice = MenuHelper.GetMenuChoice();

                switch (choice)
                {
                    case "1":
                        ManageFilmsMenu(filmService, directorService, categoryService);
                        break;
                    case "2":
                        ManageDirectorsMenu(directorService);
                        break;
                    case "3":
                        ManageCategoriesMenu(categoryService);
                        break;
                    case "0":
                        continueLoop = false;
                        break;
                    default:
                        ConsoleFormatter.DisplayError("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void ManageFilmsMenu(FilmService filmService, DirectorService directorService, CategoryService categoryService)
        {
            ArgumentNullException.ThrowIfNull(filmService);
            ArgumentNullException.ThrowIfNull(directorService);
            ArgumentNullException.ThrowIfNull(categoryService);

            bool continueMenu = true;

            while (continueMenu)
            {
                ConsoleFormatter.DisplayHeader("FILM MANAGEMENT");
                ConsoleFormatter.DisplayMenuOption("1", "Add film");
                ConsoleFormatter.DisplayMenuOption("2", "List films");
                ConsoleFormatter.DisplayMenuOption("3", "Find film");
                ConsoleFormatter.DisplayMenuOption("4", "Remove film");
                ConsoleFormatter.DisplayMenuOption("5", "Advanced search");
                ConsoleFormatter.DisplayMenuOption("6", "Sort films");
                ConsoleFormatter.DisplayMenuOption("7", "Filter films");
                ConsoleFormatter.DisplayMenuOption("8", "View reports");
                ConsoleFormatter.DisplayMenuOption("0", "Back");
                ConsoleFormatter.DisplayMenuSeparator();

                string choice = MenuHelper.GetMenuChoice();

                switch (choice)
                {
                    case "1":
                        HandleAddFilm(filmService);
                        break;
                    case "2":
                        HandleListFilms(filmService, directorService, categoryService);
                        break;
                    case "3":
                        HandleFindFilm(filmService, directorService, categoryService);
                        break;
                    case "4":
                        HandleRemoveFilm(filmService);
                        break;
                    case "5":
                        HandleAdvancedSearch(filmService, directorService, categoryService);
                        break;
                    case "6":
                        HandleSortFilms(filmService, directorService, categoryService);
                        break;
                    case "7":
                        HandleFilterFilms(filmService, directorService, categoryService);
                        break;
                    case "8":
                        HandleViewReports(filmService, directorService, categoryService);
                        break;
                    case "0":
                        continueMenu = false;
                        break;
                    default:
                        ConsoleFormatter.DisplayError("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void HandleAddFilm(FilmService filmService)
        {
            try
            {
                filmService.InteractiveAddFilm();
                ConsoleFormatter.DisplaySuccess("Film added successfully");
            }
            catch (Exception ex)
            {
                ConsoleFormatter.DisplayError(ex.Message);
            }
        }

        private static void HandleListFilms(FilmService filmService, DirectorService directorService, CategoryService categoryService)
        {
            var films = filmService.ListAll();

            if (films.Count == 0)
            {
                ConsoleFormatter.DisplayInfo("No films found.");
                return;
            }

            ConsoleFormatter.DisplayResultCount(films.Count, "film");
            foreach (var film in films)
            {
                DisplayFilmDetails(film, directorService, categoryService);
            }
        }

        private static void HandleFindFilm(FilmService filmService, DirectorService directorService, CategoryService categoryService)
        {
            Console.Write("Enter film title: ");
            string title = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(title))
            {
                ConsoleFormatter.DisplayWarning("Title cannot be empty.");
                return;
            }

            var film = filmService.FindByTitle(title);

            if (film == null)
            {
                ConsoleFormatter.DisplayInfo("Film not found.");
                return;
            }

            DisplayFilmDetails(film, directorService, categoryService);
        }

        private static void HandleRemoveFilm(FilmService filmService)
        {
            if (!MenuHelper.TryGetIntegerInput("Enter film ID to remove: ", out int filmId))
            {
                ConsoleFormatter.DisplayError("Invalid ID format.");
                return;
            }

            if (!MenuHelper.ConfirmAction("remove this film"))
                return;

            try
            {
                filmService.RemoveFilm(filmId);
                ConsoleFormatter.DisplaySuccess("Film removed successfully");
            }
            catch (KeyNotFoundException)
            {
                ConsoleFormatter.DisplayError("Film not found.");
            }
        }

        private static void HandleAdvancedSearch(FilmService filmService, DirectorService directorService, CategoryService categoryService)
        {
            ConsoleFormatter.DisplayHeader("ADVANCED SEARCH");
            Console.WriteLine("Leave fields empty to skip:\n");

            Console.Write("Title (contains): ");
            string? title = Console.ReadLine();
            title = string.IsNullOrWhiteSpace(title) ? null : title;

            int? year = null;
            Console.Write("Year (or empty): ");
            if (int.TryParse(Console.ReadLine(), out int yearValue))
                year = yearValue;

            Console.Write("Language (or empty): ");
            string? language = Console.ReadLine();
            language = string.IsNullOrWhiteSpace(language) ? null : language;

            int? minRating = null;
            Console.Write("Minimum rating 0-5 (or empty): ");
            if (int.TryParse(Console.ReadLine(), out int ratingValue))
                minRating = ratingValue;

            int? directorId = null;
            var directors = directorService.ListAll();
            if (directors.Count > 0)
            {
                Console.WriteLine("Available Directors:");
                foreach (var director in directors)
                    Console.WriteLine($"  {director.Id}: {director.Name}");
                Console.Write("Director ID (or empty): ");
                if (int.TryParse(Console.ReadLine(), out int dirId))
                    directorId = dirId;
            }

            int? categoryId = null;
            var categories = directorService.ListAll();
            if (categories.Count > 0)
            {
                Console.WriteLine("Available Categories:");
                foreach (var category in categories)
                    Console.WriteLine($"  {category.Id}: {category.Name}");
                Console.Write("Category ID (or empty): ");
                if (int.TryParse(Console.ReadLine(), out int catId))
                    categoryId = catId;
            }

            try
            {
                var results = filmService.AdvancedSearch(title, year, language, minRating, directorId, categoryId);

                if (results.Count == 0)
                {
                    ConsoleFormatter.DisplayInfo("No films found matching your criteria.");
                    return;
                }

                ConsoleFormatter.DisplayResultCount(results.Count, "film");
                foreach (var film in results)
                    DisplayFilmDetails(film, directorService, categoryService);
            }
            catch (Exception ex)
            {
                ConsoleFormatter.DisplayError(ex.Message);
            }
        }

        private static void HandleSortFilms(FilmService filmService, DirectorService directorService, CategoryService categoryService)
        {
            ConsoleFormatter.DisplayHeader("SORT FILMS");
            ConsoleFormatter.DisplayMenuOption("1", "Sort by title");
            ConsoleFormatter.DisplayMenuOption("2", "Sort by year");
            ConsoleFormatter.DisplayMenuOption("3", "Sort by rating");
            ConsoleFormatter.DisplayMenuOption("4", "Sort by language");
            ConsoleFormatter.DisplayMenuOption("0", "Back");
            ConsoleFormatter.DisplayMenuSeparator();

            string choice = MenuHelper.GetMenuChoice();
            List<Film> sortedFilms;

            bool ascending = MenuHelper.PromptYesNo("Sort ascending?", true);

            switch (choice)
            {
                case "1":
                    sortedFilms = filmService.SortByTitle(ascending);
                    break;
                case "2":
                    sortedFilms = filmService.SortByYear(ascending);
                    break;
                case "3":
                    sortedFilms = filmService.SortByRating(ascending);
                    break;
                case "4":
                    sortedFilms = filmService.SortByLanguage(ascending);
                    break;
                case "0":
                    return;
                default:
                    ConsoleFormatter.DisplayError("Invalid option.");
                    return;
            }

            DisplayFilmList(sortedFilms, directorService, categoryService);
        }

        private static void HandleFilterFilms(FilmService filmService, DirectorService directorService, CategoryService categoryService)
        {
            ConsoleFormatter.DisplayHeader("FILTER FILMS");
            ConsoleFormatter.DisplayMenuOption("1", "Filter by year");
            ConsoleFormatter.DisplayMenuOption("2", "Filter by year range");
            ConsoleFormatter.DisplayMenuOption("3", "Filter by language");
            ConsoleFormatter.DisplayMenuOption("4", "Filter by rating");
            ConsoleFormatter.DisplayMenuOption("5", "Filter by minimum rating");
            ConsoleFormatter.DisplayMenuOption("6", "Filter by director");
            ConsoleFormatter.DisplayMenuOption("7", "Filter by category");
            ConsoleFormatter.DisplayMenuOption("0", "Back");
            ConsoleFormatter.DisplayMenuSeparator();

            string choice = MenuHelper.GetMenuChoice();
            var filteredFilms = new List<Film>();

            try
            {
                switch (choice)
                {
                    case "1":
                        if (MenuHelper.TryGetIntegerInput("Enter year: ", out int year))
                            filteredFilms = filmService.FilterByYear(year);
                        break;
                    case "2":
                        if (MenuHelper.TryGetIntegerInput("Enter minimum year: ", out int minYear) &&
                            MenuHelper.TryGetIntegerInput("Enter maximum year: ", out int maxYear))
                            filteredFilms = filmService.FilterByYearRange(minYear, maxYear);
                        break;
                    case "3":
                        Console.Write("Enter language: ");
                        string? language = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(language))
                            filteredFilms = filmService.FilterByLanguage(language);
                        break;
                    case "4":
                        if (MenuHelper.TryGetIntegerInput("Enter rating (0-5): ", out int rating))
                            filteredFilms = filmService.FilterByRating(rating);
                        break;
                    case "5":
                        if (MenuHelper.TryGetIntegerInput("Enter minimum rating (0-5): ", out int minRating))
                            filteredFilms = filmService.FilterByMinimumRating(minRating);
                        break;
                    case "6":
                        var directors = directorService.ListAll();
                        if (directors.Count == 0)
                        {
                            ConsoleFormatter.DisplayInfo("No directors available.");
                            return;
                        }
                        ConsoleFormatter.DisplayListHeader("Directors", directors.Count);
                        foreach (var director in directors)
                            Console.WriteLine($"  {director.Id}: {director.Name}");
                        if (MenuHelper.TryGetIntegerInput("Enter director ID: ", out int directorId))
                            filteredFilms = filmService.FilterByDirector(directorId);
                        break;
                    case "7":
                        var categories = categoryService.ListAll();
                        if (categories.Count == 0)
                        {
                            ConsoleFormatter.DisplayInfo("No categories available.");
                            return;
                        }
                        ConsoleFormatter.DisplayListHeader("Categories", categories.Count);
                        foreach (var category in categories)
                            Console.WriteLine($"  {category.Id}: {category.Name}");
                        if (MenuHelper.TryGetIntegerInput("Enter category ID: ", out int categoryId))
                            filteredFilms = filmService.FilterByCategory(categoryId);
                        break;
                    case "0":
                        return;
                    default:
                        ConsoleFormatter.DisplayError("Invalid option.");
                        return;
                }
            }
            catch (Exception ex)
            {
                ConsoleFormatter.DisplayError(ex.Message);
                return;
            }

            DisplayFilmList(filteredFilms, directorService, categoryService);
        }

        private static void HandleViewReports(FilmService filmService, DirectorService directorService, CategoryService categoryService)
        {
            bool continueReports = true;

            while (continueReports)
            {
                ConsoleFormatter.DisplayHeader("FILM REPORTS");
                ConsoleFormatter.DisplayMenuOption("1", "General statistics");
                ConsoleFormatter.DisplayMenuOption("2", "Films by director");
                ConsoleFormatter.DisplayMenuOption("3", "Films by category");
                ConsoleFormatter.DisplayMenuOption("4", "Films by language");
                ConsoleFormatter.DisplayMenuOption("5", "Films by year");
                ConsoleFormatter.DisplayMenuOption("6", "Films by rating");
                ConsoleFormatter.DisplayMenuOption("0", "Back");
                ConsoleFormatter.DisplayMenuSeparator();

                string choice = MenuHelper.GetMenuChoice();

                switch (choice)
                {
                    case "1":
                        DisplayGeneralStatistics(filmService);
                        break;
                    case "2":
                        DisplayFilmsByDirector(filmService, directorService);
                        break;
                    case "3":
                        DisplayFilmsByCategory(filmService, categoryService);
                        break;
                    case "4":
                        DisplayFilmsByLanguage(filmService);
                        break;
                    case "5":
                        DisplayFilmsByYear(filmService);
                        break;
                    case "6":
                        DisplayFilmsByRating(filmService);
                        break;
                    case "0":
                        continueReports = false;
                        break;
                    default:
                        ConsoleFormatter.DisplayError("Invalid option.");
                        break;
                }
            }
        }

        private static void ManageDirectorsMenu(DirectorService directorService)
        {
            bool continueMenu = true;

            while (continueMenu)
            {
                ConsoleFormatter.DisplayHeader("DIRECTOR MANAGEMENT");
                ConsoleFormatter.DisplayMenuOption("1", "Add director");
                ConsoleFormatter.DisplayMenuOption("2", "List directors");
                ConsoleFormatter.DisplayMenuOption("3", "Find director");
                ConsoleFormatter.DisplayMenuOption("4", "Remove director");
                ConsoleFormatter.DisplayMenuOption("0", "Back");
                ConsoleFormatter.DisplayMenuSeparator();

                string choice = MenuHelper.GetMenuChoice();

                switch (choice)
                {
                    case "1":
                        HandleAddDirector(directorService);
                        break;
                    case "2":
                        HandleListDirectors(directorService);
                        break;
                    case "3":
                        HandleFindDirector(directorService);
                        break;
                    case "4":
                        HandleRemoveDirector(directorService);
                        break;
                    case "0":
                        continueMenu = false;
                        break;
                    default:
                        ConsoleFormatter.DisplayError("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void HandleAddDirector(DirectorService directorService)
        {
            try
            {
                directorService.InteractiveAddDirector();
                ConsoleFormatter.DisplaySuccess("Director added successfully");
            }
            catch (Exception ex)
            {
                ConsoleFormatter.DisplayError(ex.Message);
            }
        }

        private static void HandleListDirectors(DirectorService directorService)
        {
            var directors = directorService.ListAll();

            if (directors.Count == 0)
            {
                ConsoleFormatter.DisplayInfo("No directors found.");
                return;
            }

            ConsoleFormatter.DisplayResultCount(directors.Count, "director");
            foreach (var director in directors)
            {
                Console.WriteLine($"  ID: {director.Id}, Name: {director.Name}, Country: {director.Country}");
            }
        }

        private static void HandleFindDirector(DirectorService directorService)
        {
            Console.Write("Enter director name: ");
            string name = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleFormatter.DisplayWarning("Name cannot be empty.");
                return;
            }

            var director = directorService.FindByName(name);

            if (director == null)
            {
                ConsoleFormatter.DisplayInfo("Director not found.");
                return;
            }

            Console.WriteLine($"\n  ID: {director.Id}, Name: {director.Name}, Country: {director.Country}");
        }

        private static void HandleRemoveDirector(DirectorService directorService)
        {
            if (!MenuHelper.TryGetIntegerInput("Enter director ID to remove: ", out int directorId))
            {
                ConsoleFormatter.DisplayError("Invalid ID format.");
                return;
            }

            if (!MenuHelper.ConfirmAction("remove this director"))
                return;

            try
            {
                directorService.RemoveDirector(directorId);
                ConsoleFormatter.DisplaySuccess("Director removed successfully");
            }
            catch (KeyNotFoundException)
            {
                ConsoleFormatter.DisplayError("Director not found.");
            }
        }

        private static void ManageCategoriesMenu(CategoryService categoryService)
        {
            bool continueMenu = true;

            while (continueMenu)
            {
                ConsoleFormatter.DisplayHeader("CATEGORY MANAGEMENT");
                ConsoleFormatter.DisplayMenuOption("1", "Add category");
                ConsoleFormatter.DisplayMenuOption("2", "List categories");
                ConsoleFormatter.DisplayMenuOption("3", "Find category");
                ConsoleFormatter.DisplayMenuOption("4", "Remove category");
                ConsoleFormatter.DisplayMenuOption("0", "Back");
                ConsoleFormatter.DisplayMenuSeparator();

                string choice = MenuHelper.GetMenuChoice();

                switch (choice)
                {
                    case "1":
                        HandleAddCategory(categoryService);
                        break;
                    case "2":
                        HandleListCategories(categoryService);
                        break;
                    case "3":
                        HandleFindCategory(categoryService);
                        break;
                    case "4":
                        HandleRemoveCategory(categoryService);
                        break;
                    case "0":
                        continueMenu = false;
                        break;
                    default:
                        ConsoleFormatter.DisplayError("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void HandleAddCategory(CategoryService categoryService)
        {
            try
            {
                categoryService.InteractiveAddCategory();
                ConsoleFormatter.DisplaySuccess("Category added successfully");
            }
            catch (Exception ex)
            {
                ConsoleFormatter.DisplayError(ex.Message);
            }
        }

        private static void HandleListCategories(CategoryService categoryService)
        {
            var categories = categoryService.ListAll();

            if (categories.Count == 0)
            {
                ConsoleFormatter.DisplayInfo("No categories found.");
                return;
            }

            ConsoleFormatter.DisplayResultCount(categories.Count, "category");
            foreach (var category in categories)
            {
                Console.WriteLine($"  ID: {category.Id}, Name: {category.Name}");
            }
        }

        private static void HandleFindCategory(CategoryService categoryService)
        {
            Console.Write("Enter category name: ");
            string name = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleFormatter.DisplayWarning("Name cannot be empty.");
                return;
            }

            var category = categoryService.FindByName(name);

            if (category == null)
            {
                ConsoleFormatter.DisplayInfo("Category not found.");
                return;
            }

            Console.WriteLine($"\n  ID: {category.Id}, Name: {category.Name}");
        }

        private static void HandleRemoveCategory(CategoryService categoryService)
        {
            if (!MenuHelper.TryGetIntegerInput("Enter category ID to remove: ", out int categoryId))
            {
                ConsoleFormatter.DisplayError("Invalid ID format.");
                return;
            }

            if (!MenuHelper.ConfirmAction("remove this category"))
                return;

            try
            {
                categoryService.RemoveCategory(categoryId);
                ConsoleFormatter.DisplaySuccess("Category removed successfully");
            }
            catch (KeyNotFoundException)
            {
                ConsoleFormatter.DisplayError("Category not found.");
            }
        }

        // Helper methods for display
        private static void DisplayFilmDetails(Film film, DirectorService directorService, CategoryService categoryService)
        {
            ArgumentNullException.ThrowIfNull(film);
            ArgumentNullException.ThrowIfNull(directorService);
            ArgumentNullException.ThrowIfNull(categoryService);

            var director = directorService.FindById(film.DirectorId);
            var category = categoryService.FindById(film.CategoryId);

            string directorName = director?.Name ?? "Unknown";
            string categoryName = category?.Name ?? "Unknown";

            ConsoleFormatter.DisplayFilmDetails(
                film.Id.ToString(),
                film.Title,
                film.Year.ToString(),
                film.Language,
                film.Rating.ToString(),
                directorName,
                categoryName
            );
        }

        private static void DisplayFilmList(List<Film> films, DirectorService directorService, CategoryService categoryService)
        {
            if (films.Count == 0)
            {
                ConsoleFormatter.DisplayInfo("No films found matching the criteria.");
                return;
            }

            ConsoleFormatter.DisplayResultCount(films.Count, "film");
            foreach (var film in films)
            {
                DisplayFilmDetails(film, directorService, categoryService);
            }
        }

        private static void DisplayGeneralStatistics(FilmService filmService)
        {
            var stats = filmService.GetFilmStatistics();

            ConsoleFormatter.DisplayStatisticsHeader("GENERAL STATISTICS");
            ConsoleFormatter.DisplayStatistic("Total Films", stats.TotalFilms);

            if (stats.TotalFilms > 0)
            {
                ConsoleFormatter.DisplayStatistic("Average Year", stats.AverageYear);
                ConsoleFormatter.DisplayStatistic("Average Rating", $"{stats.AverageRating:F2}");
                ConsoleFormatter.DisplayStatistic("Most Recent Year", stats.MostRecentYear);
                ConsoleFormatter.DisplayStatistic("Oldest Year", stats.OldestYear);
                ConsoleFormatter.DisplayStatistic("Highest Rating", stats.HighestRating);
                ConsoleFormatter.DisplayStatistic("Lowest Rating", stats.LowestRating);
                ConsoleFormatter.DisplayStatistic("Unique Languages", stats.UniqueLanguages);
                ConsoleFormatter.DisplayStatistic("Unique Directors", stats.UniqueDirectors);
                ConsoleFormatter.DisplayStatistic("Unique Categories", stats.UniqueCategories);
            }
        }

        private static void DisplayFilmsByDirector(FilmService filmService, DirectorService directorService)
        {
            var filmsByDirector = filmService.GetFilmsByDirector();
            var allDirectors = directorService.ListAll();

            ConsoleFormatter.DisplayStatisticsHeader("FILMS BY DIRECTOR");
            if (filmsByDirector.Count == 0)
            {
                ConsoleFormatter.DisplayInfo("No films found.");
                return;
            }

            foreach (var (directorId, films) in filmsByDirector)
            {
                var director = allDirectors.FirstOrDefault(d => d.Id == directorId);
                string directorName = director?.Name ?? $"Unknown (ID: {directorId})";
                Console.WriteLine($"\n{directorName}: {films.Count} film(s)");
                foreach (var film in films)
                {
                    Console.WriteLine($"  - {film.Title} ({film.Year})");
                }
            }
        }

        private static void DisplayFilmsByCategory(FilmService filmService, CategoryService categoryService)
        {
            var filmsByCategory = filmService.GetFilmsByCategory();
            var allCategories = categoryService.ListAll();

            ConsoleFormatter.DisplayStatisticsHeader("FILMS BY CATEGORY");
            if (filmsByCategory.Count == 0)
            {
                ConsoleFormatter.DisplayInfo("No films found.");
                return;
            }

            foreach (var (categoryId, films) in filmsByCategory)
            {
                var category = allCategories.FirstOrDefault(c => c.Id == categoryId);
                string categoryName = category?.Name ?? $"Unknown (ID: {categoryId})";
                Console.WriteLine($"\n{categoryName}: {films.Count} film(s)");
                foreach (var film in films)
                {
                    Console.WriteLine($"  - {film.Title} ({film.Year})");
                }
            }
        }

        private static void DisplayFilmsByLanguage(FilmService filmService)
        {
            var filmsByLanguage = filmService.GetFilmsByLanguage();

            ConsoleFormatter.DisplayStatisticsHeader("FILMS BY LANGUAGE");
            if (filmsByLanguage.Count == 0)
            {
                ConsoleFormatter.DisplayInfo("No films found.");
                return;
            }

            foreach (var (language, count) in filmsByLanguage.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{language}: {count} film(s)");
            }
        }

        private static void DisplayFilmsByYear(FilmService filmService)
        {
            var filmsByYear = filmService.GetFilmsByYear();

            ConsoleFormatter.DisplayStatisticsHeader("FILMS BY YEAR");
            if (filmsByYear.Count == 0)
            {
                ConsoleFormatter.DisplayInfo("No films found.");
                return;
            }

            foreach (var (year, count) in filmsByYear)
            {
                Console.WriteLine($"{year}: {count} film(s)");
            }
        }

        private static void DisplayFilmsByRating(FilmService filmService)
        {
            var filmsByRating = filmService.GetFilmsByRating();

            ConsoleFormatter.DisplayStatisticsHeader("FILMS BY RATING");
            if (filmsByRating.Count == 0)
            {
                ConsoleFormatter.DisplayInfo("No films found.");
                return;
            }

            foreach (var (rating, count) in filmsByRating)
            {
                Console.WriteLine($"Rating {rating}: {count} film(s)");
            }
        }
    }
}
