using TaskTracker.Enums;
using TaskTracker.Services;
using TaskTracker.Helpers;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<ITaskService>(provider =>
            new TaskService("tasks.json"));
var serviceProvider = services.BuildServiceProvider();
var taskService = serviceProvider.GetRequiredService<ITaskService>();

ConsoleHelper.Info("Welcome to Task-Tracker. Type 'exit' to quit.");

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)) break;

    var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    if (parts[0] != "task-cli" || parts.Length < 2)
    {
        ConsoleHelper.Error("Usage: task-cli <command> [arguments]");
        continue;
    }

    var rawCommand = parts[1].Replace("-", "");
    if (!Enum.TryParse(rawCommand, ignoreCase: true, out CommandEnum command) || !Enum.IsDefined(typeof(CommandEnum), command))
    {
        ConsoleHelper.Error($"Unknown command: {parts[1]}");
        continue;
    }

    switch (command)
    {
        case CommandEnum.Add:
            if (!ArgsHelper.Require(parts, 3, "add <description>")) break;
            taskService.Add(parts[2]);
            break;
        case CommandEnum.Update:
            if (!ArgsHelper.Require(parts, 4, "update <id> <description>")) break;
            if (!ArgsHelper.TryParseId(parts[2], out int updateId)) break;
            taskService.Update(updateId, parts[3]);
            break;
        case CommandEnum.Delete:
            if (!ArgsHelper.Require(parts, 3, "delete <id>")) break;
            if (!ArgsHelper.TryParseId(parts[2], out int deleteId)) break;
            taskService.Delete(deleteId);
            break;
        case CommandEnum.MarkInProgress:
            if (!ArgsHelper.Require(parts, 3, "mark-in-progress <id>")) break;
            if (!ArgsHelper.TryParseId(parts[2], out int inProgressId)) break;
            taskService.MarkInProgress(inProgressId);
            break;
        case CommandEnum.MarkDone:
            if (!ArgsHelper.Require(parts, 3, "mark-done <id>")) break;
            if (!ArgsHelper.TryParseId(parts[2], out int doneId)) break;
            taskService.MarkDone(doneId);
            break;
        case CommandEnum.List:
            if (!ArgsHelper.Require(parts, 2, "list <status>")) break;
            taskService.List(parts.Length > 2 ? parts[2] : null);
            break;
    }
}