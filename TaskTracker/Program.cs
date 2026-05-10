using TaskTracker.Enums;
using TaskTracker.Services;

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

var taskService = new TaskService("tasks.json");
var commandMap = new Dictionary<string, CommandEnum>
{
    { "add", CommandEnum.Add },
    { "update", CommandEnum.Update },
    { "delete", CommandEnum.Delete },
    { "mark-in-progress", CommandEnum.MarkInProgress },
    { "mark-done", CommandEnum.MarkDone },
    { "list", CommandEnum.List }
};

if (!commandMap.TryGetValue(args[1].ToLower(), out CommandEnum command))
{
    PrintError($"Unknown command: {args[1]}");
    return;
}

switch (command)
{
    case CommandEnum.Add:
        taskService.Add(args[2]);
        break;
    case CommandEnum.Update:
        taskService.Update(int.Parse(args[2]), args[3]);
        break;
    case CommandEnum.Delete:
        taskService.Delete(int.Parse(args[2]));
        break;
    case CommandEnum.MarkInProgress:
        Console.WriteLine("TODO");
        break;
    case CommandEnum.MarkDone:
        Console.WriteLine("TODO");
        break;
    case CommandEnum.List:
        Console.WriteLine("TODO");
        break;
}

// Customized error message display
void PrintError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n" + "ERROR: " + message + "\n");
    Console.ResetColor();
}

Console.ReadLine();