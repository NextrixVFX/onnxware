using MelonLoader;
using System;
using UnityEngine;

namespace onnxware.ConsoleAPI
{
    public static class Logger
    {
        private static string[] levels =
        {
            "Info",
            "Warning",
            "Error",
            "Critical"
        };

        private static ConsoleColor[] colorPallete =
        {
            ConsoleColor.White,
            ConsoleColor.Yellow,
            ConsoleColor.Red,
            ConsoleColor.Magenta,
        };

        private static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void Msg(string msg, LoggerLevel msgLevel = LoggerLevel.Info, ConsoleColor customColor = ConsoleColor.White)
        {
            if (!Initialize.consoleCreated)
            { MelonLogger.Msg(msg); return; }

            float timestamp = Time.realtimeSinceStartup;

            WriteColored($"[{timestamp}] ", ConsoleColor.Cyan);
            WriteColored($"({levels[(int)msgLevel]}) ", colorPallete[(int)msgLevel]);
            WriteColored(msg + "\n", customColor);

            /*if (msgLevel == LoggerLevel.Critical)
                Application.Quit();*/ // todo when i add a log
        }

        public static void Warning(string msg) => Msg(msg, LoggerLevel.Warning);

        public static void Error(string msg) => Msg(msg, LoggerLevel.Error);

        public static void Critical(string msg) => Msg(msg, LoggerLevel.Error);

        public enum LoggerLevel
        {
            Info = 0,
            Warning = 1,
            Error = 2,
            Critical = 3,
        }
    }
}
