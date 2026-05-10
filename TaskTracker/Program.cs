using System.Text.Json;
using TaskTracker;

if (args.Length == 0 || args[0] != "task-cli")
{
    PrintError("Invalid format. Use: task-cli [arguments]");
    return;
}
else if (args.Length < 2)
{
    PrintError("Invalid number of arguments.");
    return;
}

string command = args[1].ToLower();
string filePath = "tasks.json";

// Load existing tasks or start fresh
List<TaskItem> tasks = File.Exists(filePath)
    ? JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(filePath)) ?? new List<TaskItem>()
    : new List<TaskItem>();

switch (command)
{
    case "add":
        if (args.Length < 3)
        {
            PrintError("Missing task description for 'add' command.");
            return;
        }
        AddTask(args[2]);
        break;
    case "update":
        Console.WriteLine("TODO");
        break;
    case "delete":
        Console.WriteLine("TODO");
        break;
    case "mark-in-progress":
        Console.WriteLine("TODO");
        break;
    case "mark-done":
        Console.WriteLine("TODO");
        break;
    case "list":
        Console.WriteLine("TODO");
        break;
    default:
        PrintError($"Unknown command: {command}");
        break;
}



// Add a new task
void AddTask(string description)
{
    var newTask = new TaskItem
    {
        Id = tasks.Count + 1,
        Description = description,
        Status = "todo",
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now
    };

    tasks.Add(newTask);
    SaveTasks();
    Console.WriteLine($"Task added successfully (ID: 1)");
}

// Save tasks back to JSON file
void SaveTasks()
{
    var options = new JsonSerializerOptions { WriteIndented = true };
    File.WriteAllText(filePath, JsonSerializer.Serialize(tasks, options));
}

// Customized error message display
void PrintError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n" + "ERROR: " + message + "\n");
    Console.ResetColor();
}

Console.ReadLine();