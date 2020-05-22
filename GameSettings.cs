using System;
using System.IO;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace find_the_cat
{
    public class Room
    {
        public int X { get; }
        public int Y { get; }

        public Room(int x, int y) => (X, Y) = (x, y);
    }

    public static class GameSettings
    {
        // Number of horizontal cells
        public static readonly int Nx = 10;
        // Number of vertical cells
        public static readonly int Ny = 10;

        private static string dialoguesPath = Directory.GetCurrentDirectory() + @"\dialogues";

        public static void StartGame()
        {
            var welcome = ReadDialogue("welcome");
            welcome.ToList().ForEach(i => Console.WriteLine(i.ToString()));
            var acquaintance = ReadDialogue("acquaintance");
            acquaintance.ToList().ForEach(i => Console.Write(i.ToString()));
            var name = Console.ReadLine();
            Console.WriteLine(name);
        }

        private static string[] ReadDialogue(string fileName)
        {
            string dialoguePath = dialoguesPath + @"\" + fileName + ".txt";
            if (!File.Exists(dialoguePath))
                throw new Exception($"No such file or directory: {dialoguePath}");

            return File.ReadAllLines(dialoguePath);
        }

        private static Player CreatePlayer(string name)
        {
            return new Player(name, GenerateRoom());
        }

        private static Room GenerateRoom()
        {
            Random rnd = new Random();
            return new Room(rnd.Next(Nx), rnd.Next(Ny));
        }
    }
}
