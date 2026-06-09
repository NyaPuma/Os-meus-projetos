namespace MovieManagement.Business.Utilities
{
    // Centralized input validation for consistency across the application.
    public static class InputValidator
    {
        private const int MaxTitleLength = 255;
        private const int MinYear = 1800;
        private const int MaxRating = 5;
        private const int MinRating = 0;

        // Validates a film title for length and uniqueness.
        public static string ValidateTitle(string? input, Func<string, bool> isUnique)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Title cannot be empty");

            if (input.Length > MaxTitleLength)
                throw new ArgumentException($"Title cannot exceed {MaxTitleLength} characters");

            if (!isUnique(input))
                throw new InvalidOperationException("A film with this title already exists");

            return input;
        }

        // Validates a year for a film.
        public static int ValidateYear(int year)
        {
            int currentYear = DateTime.Now.Year;
            if (year < MinYear || year > currentYear)
                throw new ArgumentOutOfRangeException(nameof(year), $"Year must be between {MinYear} and {currentYear}");

            return year;
        }

        // Validates a rating between 0-5.
        public static int ValidateRating(int rating)
        {
            if (rating < MinRating || rating > MaxRating)
                throw new ArgumentOutOfRangeException(nameof(rating), $"Rating must be between {MinRating} and {MaxRating}");

            return rating;
        }

        // Validates that a string is not empty or whitespace.
        public static string ValidateNonEmptyString(string? input, string paramName = "Input")
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException($"{paramName} cannot be empty", paramName);

            return input;
        }

        // Validates that an ID is valid (greater than 0).
        public static int ValidateId(int id, string paramName = "Id")
        {
            if (id <= 0)
                throw new ArgumentException($"{paramName} must be greater than 0", paramName);

            return id;
        }

        // Prompts user for input until valid input is provided.
        public static string PromptForNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Error: Input cannot be empty. Please try again.");
            }
        }

        // Prompts user for integer until valid integer is provided.
        public static int PromptForInteger(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;

                Console.WriteLine("Error: Please enter a valid integer.");
            }
        }

        // Prompts user for yes/no confirmation.
        public static bool PromptForConfirmation(string prompt, bool defaultYes = true)
        {
            Console.Write($"{prompt} ({(defaultYes ? "Y/n" : "y/N")}): ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return defaultYes;

            return input.Equals("y", StringComparison.OrdinalIgnoreCase);
        }
    }
}
