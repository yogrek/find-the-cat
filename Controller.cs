using System;
using System.Collections.Generic;
using System.Text;

namespace FindTheCat
{
    public static class Controller
    {
        public static void CreatePlayer()
        {
            Dialogues.Write("welcome");
            var name = ReadName();
            Game.m_Player = new Player(name, Game.GenerateRoom());
        }

        public static void ReadCommand()
        {
            Dialogues.Write("wait_command");
            var command = Console.ReadLine().ToLower();
            DoCommand(command);
        }

        private static string ReadName()
        {
            Dialogues.Write("acquaintance");
            var name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Dialogues.Write("wrong_name");
                ReadName();
            }
            return name;
        }

        private static void DoCommand(string command)
        {
            switch (command)
            {
                case "я":
                    Game.m_Player.ShowInfo();
                    break;
                case "осмотреться":
                    Game.m_Player.LookAround();
                    break;
                case "идти на север":
                    Game.m_Player.Go(Direction.Up);
                    break;
                case "идти на юг":
                    Game.m_Player.Go(Direction.Down);
                    break;
                case "идти на восток":
                    Game.m_Player.Go(Direction.Right);
                    break;
                case "идти на запад":
                    Game.m_Player.Go(Direction.Left);
                    break;
                case "помощь":
                    Dialogues.Write("help");
                    break;
                case "выход":
                    Game.Exit();
                    break;
                default:
                    Dialogues.Write("no_command_error");
                    break;
            }
        }
    }
}
