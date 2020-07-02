using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
using System.Linq;

namespace FindTheCat
{
    public static class Dialogues
    {
        private static readonly string dialoguesPath = Path.Combine(Directory.GetCurrentDirectory(), "dialogues");

        public static void Write(string dialogue)
        {
            var text = Read(dialogue);
            text.ToList().ForEach(i => Console.Write(i));
        }

        public static void Write(string dialogue, string playerName)
        {
            var text = Read(dialogue, playerName);
            text.ToList().ForEach(i => Console.Write(i));
        }

        private static string[] Read(string fileName)
        {
            var dialogue = File.ReadAllLines(GetFilePath(fileName));
            dialogue = dialogue.Select(i => i.Replace("\\n", "\n")).ToArray();
            return dialogue;
        }

        private static string[] Read(string fileName, string playerName)
        {
            var dialogue = File.ReadAllLines(GetFilePath(fileName));
            dialogue = dialogue.Select(i => i.Replace("%PlayerName%", playerName)).ToArray();
            dialogue = dialogue.Select(i => i.Replace("\\n", "\n")).ToArray();
            return dialogue;
        }

        private static string GetFilePath(string fileName)
        {
            var filePath = Path.Combine(dialoguesPath, String.Concat(fileName, ".txt"));
            if (!File.Exists(filePath))
                throw new Exception($"No such file or directory: {filePath}");
            else return filePath;
        }
    }
}
