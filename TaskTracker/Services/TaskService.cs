using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TaskTracker.Models;

namespace TaskTracker.Services
{
    public class TaskService
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
                Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1,
                Description = description,
                Status = "todo",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _tasks.Add(newTask);
            this.SaveTasks();
            Console.WriteLine($"Task added successfully (ID: {newTask.Id})");
        }

        public void Update(int id, string description)
        {
            var task = this.FindById(id);
            if (task == null) { Console.WriteLine($"Task {id} not found."); return; }

            task.Description = description;
            task.UpdatedAt = DateTime.Now;
            this.SaveTasks();
            Console.WriteLine($"Task updated successfully (ID: {task.Id})");
        }

        public void Delete(int id)
        {
            var task = this.FindById(id);
            if (task == null) { Console.WriteLine($"Task {id} not found."); return; }

            _tasks.Remove(task);
            this.SaveTasks();
            Console.WriteLine($"Task deleted successfully (ID: {task.Id})");
        }

        public void MarkInProgress(int id)
        {
            throw new NotImplementedException();
        }

        public void MarkDone(int id)
        {
            throw new NotImplementedException();
        }

        public void List(string? status = null)
        {
            throw new NotImplementedException();
        }

        private TaskItem? FindById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        private void SaveTasks()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_filePath, JsonSerializer.Serialize(_tasks, options));
        }
    }
}