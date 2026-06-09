using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using MovieManagement.Business.Utilities;

namespace MovieManagement.Business.Services
{
    // Service for managing category operations.
    public class CategoryService(ICategoryRepository repository)
    {
        private readonly ICategoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        // Interactively adds a category with user input and validation.
        public void InteractiveAddCategory()
        {
            try
            {
                string name = PromptForValidName();
                Category newCategory = new(0, name);
                _repository.Add(newCategory);
                Console.WriteLine($"Category '{name}' added successfully!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error adding category: {ex.Message}", ex);
            }
        }

        private string PromptForValidName()
        {
            while (true)
            {
                try
                {
                    string name = InputValidator.PromptForNonEmptyString("Category Name: ");
                    if (_repository.GetByName(name) != null)
                        throw new InvalidOperationException("A category with this name already exists");
                    return name;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Please try again.");
                }
            }
        }

        // Programmatically adds a category with validation.
        public void AddCategory(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            InputValidator.ValidateNonEmptyString(name, nameof(name));

            if (_repository.GetByName(name) != null)
                throw new InvalidOperationException("A category with this name already exists");

            Category newCategory = new(0, name);
            _repository.Add(newCategory);
        }

        // Lists all categories.
        public List<Category> ListAll() => _repository.GetAll();

        // Finds a category by name.
        public Category? FindByName(string name) => _repository.GetByName(name);

        // Finds a category by ID.
        public Category? FindById(int id)
        {
            var categories = _repository.GetAll();
            return categories.FirstOrDefault(c => c.Id == id);
        }

        // Removes a category by ID.
        public void RemoveCategory(int id)
        {
            if (!_repository.Remove(id))
                throw new KeyNotFoundException("Category not found");
        }
    }
}
