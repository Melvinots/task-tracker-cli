using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Helpers
{
    public static class ArgsHelper
    {
        public static bool Require(string[] args, int minimum, string usage)
        {
            if (args.Length >= minimum) return true;
            ConsoleHelper.Error($"Usage: {usage}");
            return false;
        }

        public static bool TryParseId(string value, out int id)
        {
            if (int.TryParse(value, out id)) return true;
            ConsoleHelper.Error($"Invalid ID '{value}'. ID must be a number.");
            return false;
        }
    }
}
