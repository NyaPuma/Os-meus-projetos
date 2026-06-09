namespace MovieManagement.UI.Utilities
{
    // Provides consistent console output formatting throughout the application.
    public static class ConsoleFormatter
    {
        private const string Separator = "-----------------------------------------------------";

        // Displays a section header with separators.
        public static void DisplayHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine(Separator);
            Console.WriteLine(title);
            Console.WriteLine(Separator);
        }

        // Displays a menu option with number and description.
        public static void DisplayMenuOption(string number, string description)
        {
            Console.WriteLine($"{number} - {description}");
        }

        // Displays the end of a menu with separator.
        public static void DisplayMenuSeparator()
        {
            Console.WriteLine(Separator);
        }

        // Displays a success message.
        public static void DisplaySuccess(string message)
        {
            Console.WriteLine($"✓ {message}");
        }

        // Displays an error message.
        public static void DisplayError(string message)
        {
            Console.WriteLine($"✗ Error: {message}");
        }

        // Displays an info message.
        public static void DisplayInfo(string message)
        {
            Console.WriteLine($"ℹ {message}");
        }

        // Displays a warning message.
        public static void DisplayWarning(string message)
        {
            Console.WriteLine($"⚠ {message}");
        }

        // Displays a section separator line.
        public static void DisplaySeparator()
        {
            Console.WriteLine(Separator);
        }

        // Displays film details in a formatted manner.
        public static void DisplayFilmDetails(string id, string title, string year, string language, 
                                             string rating, string director, string category)
        {
            Console.WriteLine($"\n  ID: {id}");
            Console.WriteLine($"  Title: {title}");
            Console.WriteLine($"  Year: {year}");
            Console.WriteLine($"  Language: {language}");
            Console.WriteLine($"  Rating: {rating}");
            Console.WriteLine($"  Director: {director}");
            Console.WriteLine($"  Category: {category}");
        }

        // Displays entity details (Director or Category).
        public static void DisplayEntityDetails(string id, string name, string? additionalInfo = null)
        {
            Console.WriteLine($"  ID: {id}, Name: {name}" + 
                            (!string.IsNullOrEmpty(additionalInfo) ? $", {additionalInfo}" : ""));
        }

        // Displays a list of entities with numbering.
        public static void DisplayListHeader(string entityName, int count)
        {
            if (count == 0)
            {
                DisplayInfo($"No {entityName.ToLower()} found.");
                return;
            }

            Console.WriteLine($"\nAvailable {entityName}:");
        }

        // Displays a formatted result count.
        public static void DisplayResultCount(int count, string entityName = "result")
        {
            string plural = count == 1 ? entityName : $"{entityName}s";
            Console.WriteLine($"Found {count} {plural}.");
        }

        // Displays a statistics section header.
        public static void DisplayStatisticsHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine($"=== {title} ===");
        }

        // Displays a statistic line with label and value.
        public static void DisplayStatistic(string label, object value)
        {
            Console.WriteLine($"{label}: {value}");
        }
    }
}
