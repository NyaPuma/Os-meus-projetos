using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using MovieManagement.Business.Utilities;

namespace MovieManagement.Business.Services
{
    // Service for managing director operations.
    public class DirectorService(IDirectorRepository repository)
    {
        private readonly IDirectorRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        // Interactively adds a director with user input and validation.
        public void InteractiveAddDirector()
        {
            try
            {
                string name = PromptForValidName();
                string country = InputValidator.PromptForNonEmptyString("Country: ");

                Director newDirector = new() { Name = name, Country = country };
                _repository.Add(newDirector);
                Console.WriteLine($"Director '{name}' added successfully!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error adding director: {ex.Message}", ex);
            }
        }

        private string PromptForValidName()
        {
            while (true)
            {
                try
                {
                    string name = InputValidator.PromptForNonEmptyString("Director Name: ");
                    if (_repository.GetByName(name) != null)
                        throw new InvalidOperationException("A director with this name already exists");
                    return name;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Please try again.");
                }
            }
        }

        // Programmatically adds a director with validation.
        public void AddDirector(string name, string country)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(country);

            InputValidator.ValidateNonEmptyString(name, nameof(name));
            InputValidator.ValidateNonEmptyString(country, nameof(country));

            if (_repository.GetByName(name) != null)
                throw new InvalidOperationException("A director with this name already exists");

            Director newDirector = new() { Name = name, Country = country };
            _repository.Add(newDirector);
        }

        // Lists all directors.
        public List<Director> ListAll() => _repository.GetAll();

        // Finds a director by name.
        public Director? FindByName(string name) => _repository.GetByName(name);

        // Finds a director by ID.
        public Director? FindById(int id)
        {
            var directors = _repository.GetAll();
            return directors.FirstOrDefault(d => d.Id == id);
        }

        // Removes a director by ID.
        public void RemoveDirector(int id)
        {
            if (!_repository.Remove(id))
                throw new KeyNotFoundException("Director not found");
        }
    }
}
