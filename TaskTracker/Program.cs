using TaskTracker.Enums;
using TaskTracker.Services;
using TaskTracker.Helpers;

if (args.Length < 2 || args[0] != "task-cli")
{
    ConsoleHelper.Error("Usage: task-cli <command> [arguments]");
    return;
}

var taskService = new TaskService("tasks.json");
var rawCommand = args[1].Replace("-", "");

if (!Enum.TryParse(rawCommand, ignoreCase: true, out CommandEnum command) || !Enum.IsDefined(typeof(CommandEnum), command))
{
    ConsoleHelper.Error($"Unknown command: {args[1]}");
    return;
}

switch (command)
{
    case CommandEnum.Add:
        if (!ArgsHelper.Require(args, 3, "add <description>")) break;
        taskService.Add(args[2]);
        break;
    case CommandEnum.Update:
        if (!ArgsHelper.Require(args, 4, "update <id> <description>")) break;
        if (!ArgsHelper.TryParseId(args[2], out int updateId)) break;
        taskService.Update(updateId, args[3]);
        break;
    case CommandEnum.Delete:
        if (!ArgsHelper.Require(args, 3, "delete <id>")) break;
        if (!ArgsHelper.TryParseId(args[2], out int deleteId)) break;
        taskService.Delete(deleteId);
        break;
    case CommandEnum.MarkInProgress:
        if (!ArgsHelper.Require(args, 3, "mark-in-progress <id>")) break;
        if (!ArgsHelper.TryParseId(args[2], out int inProgressId)) break;
        taskService.MarkInProgress(inProgressId);
        break;
    case CommandEnum.MarkDone:
        if (!ArgsHelper.Require(args, 3, "mark-done <id>")) break;
        if (!ArgsHelper.TryParseId(args[2], out int doneId)) break;
        taskService.MarkDone(doneId);
        break;
    case CommandEnum.List:
        if (!ArgsHelper.Require(args, 2, "list <status>")) break;
        taskService.List(args.Length > 2 ? args[2] : null);
        break;
}

Console.ReadLine();