using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TaskTracker.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}