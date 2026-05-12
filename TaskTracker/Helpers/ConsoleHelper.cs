using TaskTracker.Models;

namespace TaskTracker.Helpers
{
    public static class ConsoleHelper
    {
        public static void Success(string message) => Print("[OK]", message, ConsoleColor.Green);
        public static void Error(string message) => Print("[ERROR]", message, ConsoleColor.Red);
        public static void Info(string message) => Print("[INFO]", message, ConsoleColor.Cyan);
        public static void Warning(string message) => Print("[WARN]", message, ConsoleColor.Yellow);

        private static void Print(string prefix, string message, ConsoleColor color)
        {
            Console.WriteLine();
            Console.ForegroundColor = color;
            Console.WriteLine($"{prefix} {message}");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void PrintTable(List<TaskItem> tasks)
        {
            ConsoleHelper.Info($"Listing {tasks.Count} task(s)...");
            Console.WriteLine($"{"ID",-5} {"DESCRIPTION",-45} {"STATUS",-15} {"CREATED AT",-25} {"UPDATED AT",-25}");
            Console.WriteLine(new string('─', 116));

            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id,-5} {Truncate(task.Description, 40),-45} {task.Status,-15} {task.CreatedAt,-25} {task.UpdatedAt,-25}");
            }

            Console.WriteLine(new string('─', 116));
            Console.WriteLine();
        }

        public static string Truncate(string value, int maxLength)
        {
            return value?.Length > maxLength ? value[..(maxLength - 3)] + "..." : value ?? "";
        }
    }
}