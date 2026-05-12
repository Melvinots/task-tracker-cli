# 📋 Task Tracker CLI

A lightweight command-line task manager built with **C# (.NET)** — stores tasks locally in a JSON file.

> Inspired by the [roadmap.sh Task Tracker project](https://roadmap.sh/projects/task-tracker).

---

## ✨ Features

- Add, update, and delete tasks
- Mark tasks as **in-progress** or **done**
- List all tasks or filter by status
- Persistent JSON storage — no database required
- Color-coded console output

---

## 🛠️ Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) **6.0 or later**

---

## 🚀 Installation

```bash
git clone https://github.com/Melvinots/task-tracker-cli.git
cd task-tracker-cli
dotnet build
```

Run with:
```bash
dotnet run -- task-cli <command> [arguments]
```

Or publish a self-contained executable:
```bash
dotnet publish -c Release -r win-x64 --self-contained
task-cli <command> [arguments]
```

---

## 📌 Usage

All commands follow this structure:

```
task-cli <command> [arguments]
```

| Command | Description |
|---|---|
| `add <description>` | Add a new task |
| `update <id> <description>` | Update a task's description |
| `delete <id>` | Delete a task |
| `mark-in-progress <id>` | Mark a task as in-progress |
| `mark-done <id>` | Mark a task as done |
| `list [status]` | List all tasks or filter by status |

### Examples

```bash
task-cli add "Buy groceries"
task-cli update 1 "Buy groceries and cook dinner"
task-cli delete 1
task-cli mark-in-progress 2
task-cli mark-done 2
task-cli list
task-cli list todo
task-cli list in-progress
task-cli list done
```

**Sample output:**

```
ID    DESCRIPTION                    STATUS          CREATED AT                UPDATED AT
────────────────────────────────────────────────────────────────────────────────────────────
1     Buy groceries                  todo            2024-01-10 09:00:00       2024-01-10 09:00:00
2     Write unit tests               in-progress     2024-01-10 09:05:00       2024-01-10 10:00:00
3     Push code to GitHub            done            2024-01-10 08:00:00       2024-01-10 11:00:00
────────────────────────────────────────────────────────────────────────────────────────────
```

---

## 🗂️ Task Properties

| Property | Type | Description |
|---|---|---|
| `Id` | `int` | Auto-incremented unique identifier |
| `Description` | `string` | Task description |
| `Status` | `string` | `todo`, `in-progress`, or `done` |
| `CreatedAt` | `DateTime` | When the task was created |
| `UpdatedAt` | `DateTime` | When the task was last updated |

---

## 💾 Data Storage

Tasks are saved to **`tasks.json`** in the working directory, created automatically on first use.

```json
[
  {
    "Id": 1,
    "Description": "Buy groceries",
    "Status": "todo",
    "CreatedAt": "2024-01-10T09:00:00",
    "UpdatedAt": "2024-01-10T09:00:00"
  }
]
```

---

## 📁 Project Structure

```
task-tracker-cli/
├── Program.cs                  # Entry point and command routing
├── TaskItem.cs                 # Task model
├── Services/
│   └── TaskService.cs          # Task business logic
├── Helpers/
│   ├── ConsoleHelper.cs        # Colored output and table formatting
│   └── ArgsHelper.cs           # CLI argument validation
├── Enums/
│   └── CommandEnum.cs          # Supported commands
├── tasks.json                  # Auto-generated task storage (git-ignored)
└── README.md
```

---

## ⚠️ Error Handling

All errors are printed in **red**. Common cases:

| Scenario | Message |
|---|---|
| Missing `task-cli` prefix | `Usage: task-cli <command> [arguments]` |
| Unknown command | `Unknown command: <command>` |
| Invalid ID (non-number) | `Invalid ID. ID must be a number.` |
| Missing required argument | `Usage: <command> <arguments>` |

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
