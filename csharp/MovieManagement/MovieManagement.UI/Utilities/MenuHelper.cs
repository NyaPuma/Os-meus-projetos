using MovieManagement.Business.Utilities;

namespace MovieManagement.UI.Utilities
{
    // Provides utilities for menu handling and option processing.
    public static class MenuHelper
    {
        // Gets the user's menu choice.
        public static string GetMenuChoice(string prompt = "Select an option: ")
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        // Displays a yes/no prompt and returns the choice.
        public static bool PromptYesNo(string prompt, bool defaultYes = true)
        {
            string yesNo = defaultYes ? "(Y/n)" : "(y/N)";
            Console.Write($"{prompt} {yesNo}: ");
            string? choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice))
                return defaultYes;

            return choice.Equals("y", StringComparison.OrdinalIgnoreCase);
        }

        // Prompts user to select from a list of items.
        public static T? SelectFromList<T>(List<T> items, Func<T, string> displayFunc, 
                                          Func<T, int> idFunc, string itemName)
        {
            if (items.Count == 0)
            {
                ConsoleFormatter.DisplayInfo($"No {itemName.ToLower()} available.");
                return default;
            }

            ConsoleFormatter.DisplayListHeader(itemName, items.Count);
            foreach (var item in items)
            {
                Console.WriteLine($"  {displayFunc(item)}");
            }

            int selectedId = InputValidator.PromptForInteger($"Select {itemName} ID: ");
            var selected = items.FirstOrDefault(item => idFunc(item) == selectedId);

            if (selected == null)
            {
                ConsoleFormatter.DisplayError($"Invalid {itemName} ID.");
                return default;
            }

            return selected;
        }

        // Handles a menu option that requires integer input.
        public static bool TryGetIntegerInput(string prompt, out int value)
        {
            Console.Write(prompt);
            return int.TryParse(Console.ReadLine(), out value);
        }

        // Displays and processes a confirmation prompt.
        public static bool ConfirmAction(string action)
        {
            return PromptYesNo($"Are you sure you want to {action}?", defaultYes: false);
        }
    }
}
