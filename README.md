# 📋 Task Tracker CLI

A lightweight command-line task management tool built with **C# (.NET)** that lets you track your to-dos, work in progress, and completed tasks — all stored locally in a JSON file.

> Inspired by the [roadmap.sh Task Tracker project](https://roadmap.sh/projects/task-tracker).

---

## 📖 Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
  - [Add a Task](#add-a-task)
  - [Update a Task](#update-a-task)
  - [Delete a Task](#delete-a-task)
  - [Mark Task Status](#mark-task-status)
  - [List Tasks](#list-tasks)
- [Task Properties](#task-properties)
- [Data Storage](#data-storage)
- [Error Handling](#error-handling)
- [Project Structure](#project-structure)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)

---

## ✨ Features

- ✅ Add tasks with a description
- 🔄 Update task descriptions
- 🗑️ Delete tasks
- 📌 Mark tasks as **in-progress** or **done**
- 📃 List all tasks or filter by status
- 💾 Persistent JSON file storage — no database required
- 🎨 Color-coded error messages in the terminal

---

## 🛠️ Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) **6.0 or later**
- A terminal / command prompt

---

## 🚀 Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/Melvinots/task-tracker-cli.git
   cd task-tracker-cli
   ```

2. **Build the project:**

   ```bash
   dotnet build
   ```

3. **Run directly with `dotnet run`:**

   ```bash
   dotnet run -- task-cli <command> [arguments]
   ```

   Or **publish a self-contained executable:**

   ```bash
   dotnet publish -c Release -r win-x64 --self-contained
   # Then run the output binary directly:
   task-cli <command> [arguments]
   ```

---

## 📌 Usage

All commands follow this structure:

```
task-cli <command> [arguments]
```

> ⚠️ The first argument must always be `task-cli`.

---

### Add a Task

Create a new task with a description. New tasks start with the status `todo`.

```bash
task-cli add "Buy groceries"
# Output: Task added successfully (ID: 1)

task-cli add "Write unit tests"
# Output: Task added successfully (ID: 2)
```

---

### Update a Task

Update the description of an existing task by its ID.

```bash
task-cli update 1 "Buy groceries and cook dinner"
```

---

### Delete a Task

Remove a task permanently by its ID.

```bash
task-cli delete 1
```

---

### Mark Task Status

Change the status of a task:

```bash
# Mark as in-progress
task-cli mark-in-progress 2

# Mark as done
task-cli mark-done 2
```

---

### List Tasks

List all tasks, or filter by status:

```bash
# List all tasks
task-cli list

# List only to-do tasks
task-cli list todo

# List only in-progress tasks
task-cli list in-progress

# List only completed tasks
task-cli list done
```

**Example output:**

```
ID  Description              Status        Created              Updated
--  -----------------------  ------------  -------------------  -------------------
1   Buy groceries            todo          2024-01-10 09:00:00  2024-01-10 09:00:00
2   Write unit tests         in-progress   2024-01-10 09:05:00  2024-01-10 10:00:00
3   Push code to GitHub      done          2024-01-10 08:00:00  2024-01-10 11:00:00
```

---

## 🗂️ Task Properties

Each task stored in `tasks.json` contains the following fields:

| Property      | Type       | Description                              |
|---------------|------------|------------------------------------------|
| `Id`          | `int`      | Unique auto-incremented identifier       |
| `Description` | `string`   | The task description text                |
| `Status`      | `string`   | One of: `todo`, `in-progress`, `done`    |
| `CreatedAt`   | `DateTime` | Timestamp when the task was created      |
| `UpdatedAt`   | `DateTime` | Timestamp when the task was last updated |

---

## 💾 Data Storage

Tasks are stored in a file called **`tasks.json`** in the same directory where the application is run. The file is created automatically on first use.

**Example `tasks.json`:**

```json
[
  {
    "Id": 1,
    "Description": "Buy groceries",
    "Status": "todo",
    "CreatedAt": "2024-01-10T09:00:00",
    "UpdatedAt": "2024-01-10T09:00:00"
  },
  {
    "Id": 2,
    "Description": "Write unit tests",
    "Status": "in-progress",
    "CreatedAt": "2024-01-10T09:05:00",
    "UpdatedAt": "2024-01-10T10:00:00"
  }
]
```

---

## ⚠️ Error Handling

The CLI provides descriptive, color-coded error messages for common mistakes:

| Scenario                          | Error Message                                      |
|-----------------------------------|----------------------------------------------------|
| Missing `task-cli` prefix         | `Invalid format. Use: task-cli [arguments]`        |
| No command provided               | `Invalid number of arguments.`                     |
| `add` with no description         | `Missing task description for 'add' command.`      |
| Unrecognized command              | `Unknown command: <command>`                       |

All errors are printed in **red** to the console for easy visibility.

---

## 📁 Project Structure

```
task-tracker-cli/
├── Program.cs          # Entry point, command routing, core logic
├── TaskItem.cs         # Task model definition
├── tasks.json          # Auto-generated task storage file (git-ignored)
├── TaskTracker.csproj  # .NET project file
└── README.md           # This file
```

---

## 🛣️ Roadmap

The following commands are currently stubbed and under development:

- [ ] `update <id> <description>` — Edit a task's description
- [ ] `delete <id>` — Remove a task by ID
- [ ] `mark-in-progress <id>` — Set a task's status to `in-progress`
- [ ] `mark-done <id>` — Set a task's status to `done`
- [ ] `list [status]` — List tasks with optional status filter

---

## 🤝 Contributing

Contributions are welcome! To get started:

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/my-feature`
3. Commit your changes: `git commit -m "Add my feature"`
4. Push to your branch: `git push origin feature/my-feature`
5. Open a Pull Request

Please make sure your code follows the existing style and includes appropriate error handling.

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
