using System.Text.Json;
using TaskTracker.Helpers;
using TaskTracker.Models;

namespace TaskTracker.Services
{
    public class TaskService : ITaskService
    {
        private readonly string _filePath;
        private List<TaskItem> _tasks;

        public TaskService(string filePath)
        {
            _filePath = filePath;
            _tasks = File.Exists(filePath)
            ? JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(filePath)) ?? new()
            : new();
        }

        public void Add(string description)
        {
            var newTask = new TaskItem
            {
                Id = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1,
                Description = description,
                Status = "todo",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _tasks.Add(newTask);
            this.SaveTasks();
            ConsoleHelper.Success($"Task created successfully (ID: {newTask.Id})");
        }

        public void Update(int id, string description)
        {
            var task = this.FindById(id);
            if (task == null) { ConsoleHelper.Error($"Task ID {id} not found."); return; }

            task.Description = description;
            task.UpdatedAt = DateTime.Now;
            this.SaveTasks();
            ConsoleHelper.Success($"Task updated successfully (ID: {task.Id})");
        }

        public void Delete(int id)
        {
            var task = this.FindById(id);
            if (task == null) { ConsoleHelper.Error($"Task ID {id} not found."); return; }

            _tasks.Remove(task);
            this.SaveTasks();
            ConsoleHelper.Success($"Task deleted successfully (ID: {task.Id})");
        }

        public void MarkInProgress(int id)
        {
            var task = this.FindById(id);
            if (task == null) { ConsoleHelper.Error($"Task ID {id} not found."); return; }

            task.Status = "in-progress";
            this.SaveTasks();
            ConsoleHelper.Success($"Task marked as in progress (ID: {task.Id})");
        }

        public void MarkDone(int id)
        {
            var task = this.FindById(id);
            if (task == null) { ConsoleHelper.Error($"Task ID {id} not found."); return; }

            task.Status = "done";
            this.SaveTasks();
            ConsoleHelper.Success($"Task marked as done (ID: {task.Id})");
        }

        public void List(string? status = null)
        {
            var filteredTasks = string.IsNullOrEmpty(status)
                ? _tasks
                : _tasks.Where(t => t.Status?.Equals(status, StringComparison.OrdinalIgnoreCase) == true).ToList();

            if (!filteredTasks.Any())
            {
                ConsoleHelper.Warning("No tasks available.");
                return;
            }

            ConsoleHelper.PrintTable(filteredTasks);
        }

        public TaskItem? FindById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }
            
        public void SaveTasks()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_filePath, JsonSerializer.Serialize(_tasks, options));
        }
    }
}