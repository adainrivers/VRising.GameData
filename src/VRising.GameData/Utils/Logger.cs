using System;
using BepInEx.Logging;

namespace VRising.GameData.Utils
{
    internal static class Logger
    {
        private static void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine($"[{logLevel}] {message}");
        }

        internal static void LogInfo(string message) => Log(LogLevel.Info, message);
        internal static void LogWarning(string message) =>  Log(LogLevel.Warning, message);
        internal static void LogDebug(string message) =>  Log(LogLevel.Debug, message);
        internal static void LogFatal(string message) =>  Log(LogLevel.Fatal, message);
        internal static void LogError(string message) =>  Log(LogLevel.Error, message);
        internal static void LogError(Exception exception) =>  Log(LogLevel.Error, exception.ToString());
        internal static void LogMessage(string message) =>  Log(LogLevel.Message, message);
    }
}