﻿using System;
using System.IO;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace FindTheCat
{
    public static class GameSettings
    {
        // Number of horizontal cells
        public static readonly int Nh = 10;
        // Number of vertical cells
        public static readonly int Nv = 10;
        public static Room[,] Rooms = new Room[Nh, Nv];

        private static Player m_Player;
        private static string dialoguesPath = Directory.GetCurrentDirectory() + @"\dialogues";
        private static List<Type> itemTypes = new List<Type>();

        static GameSettings()
        {
            GetTypes();
            GenerateMap();
            SpawnTheCat();
        }

        public static void StartGame()
        {
            var welcome = ReadDialogue("welcome");
            welcome.ToList().ForEach(i => Console.WriteLine(i.ToString()));
            var acquaintance = ReadDialogue("acquaintance");
            acquaintance.ToList().ForEach(i => Console.Write(i.ToString()));
            var name = Console.ReadLine();

            m_Player = CreatePlayer(name);
        }

        public static void ReadCommand()
        {
            var wait_command = ReadDialogue("wait_command");
            wait_command.ToList().ForEach(i => Console.Write(i.ToString()));
            var command = Console.ReadLine().ToLower();
            DoCommand(command);
        }

        private static void DoCommand(string command)
        {
            switch(command)
            {
                case "я":
                    m_Player.GetInfo();
                    break;
                case "осмотреться":
                    m_Player.LookAround();
                    break;
                case "идти на север":
                    m_Player.Go(Direction.Up);
                    break;
                case "идти на юг":
                    m_Player.Go(Direction.Down);
                    break;
                case "идти на восток":
                    m_Player.Go(Direction.Right);
                    break;
                case "идти на запад":
                    m_Player.Go(Direction.Left);
                    break;
                case "помощь":
                    var help = ReadDialogue("help");
                    help.ToList().ForEach(i => Console.WriteLine(i.ToString()));
                    break;
                case "выход":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Нет такой команды.");
                    break;
            }
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
            return Rooms[rnd.Next(Nh), rnd.Next(Nv)];
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
            for(int i = 0; i < Nh; i++)
            {
                for(int j = 0; j < Nv; j++)
                {
                    Rooms[i, j] = new Room(i, j);
                    Rooms[i, j].GenerateItems(itemTypes);
                    //Console.Write($"({Rooms[i, j].X}, {Rooms[i, j].Y})  ");
                }
                //Console.WriteLine();
            }
        }

        private static void SpawnTheCat()
        {
            var rnd = new Random();
            int catX = rnd.Next(Nh);
            int catY = rnd.Next(Nv);

            Rooms[catX, catY].Items.Add(new Cat());
            Console.WriteLine($"Котик в комнате ({catX}, {catY})");
        }

        private static void Exit()
        {
            Environment.Exit(-1);
        }
    }
}
