using System;
using System.IO;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace FindTheCat
{
    public static class Game
    {
        // Number of horizontal cells
        public static readonly int Nh = 10;
        // Number of vertical cells
        public static readonly int Nv = 10;
        public static Room[,] Rooms = new Room[Nh, Nv];
        public static Player m_Player;

        private static List<Type> itemTypes = new List<Type>();
        private static Random random;

        static Game()
        {
            GetTypes();
            GenerateMap();
            SpawnTheCat();
        }

        public static void Start()
        {
            Controller.CreatePlayer();
        }

        public static void Exit()
        {
            Environment.Exit(-1);
        }

        public static Room GenerateRoom()
        {
            random = new Random();
            return Rooms[random.Next(Nh), random.Next(Nv)];
        }

        private static void GetTypes()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                if (type.IsSubclassOf(typeof(Item)) && type != typeof(Cat))
                {
                    itemTypes.Add(type);
                }
            }
        }

        private static void GenerateMap()
        {
            for (int i = 0; i < Nh; i++)
            {
                for (int j = 0; j < Nv; j++)
                {
                    Rooms[i, j] = new Room(i, j);
                    ItemGenerator.Generate(itemTypes, Rooms[i, j]);
                    //Console.Write($"({Rooms[i, j].X}, {Rooms[i, j].Y})  ");
                }
                //Console.WriteLine();
            }
        }

        private static void SpawnTheCat()
        {
            random = new Random();
            Rooms[random.Next(Nh), random.Next(Nv)].Items.Add(new Cat());
        }
    }
}
