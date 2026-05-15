using TaskTracker.Models;

namespace TaskTracker.Services
{
    internal interface ITaskService
    {
        void Add(string description);
        void Update(int id, string description);
        void Delete(int id);
        void MarkInProgress(int id);
        void MarkDone(int id);
        void List(string? status = null);

        TaskItem? FindById(int id);
        void SaveTasks();
    }
}