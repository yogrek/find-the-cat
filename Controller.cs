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
            GameSettings.m_Player = new Player(name, GameSettings.GenerateRoom());
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
                    GameSettings.m_Player.ShowInfo();
                    break;
                case "осмотреться":
                    GameSettings.m_Player.LookAround();
                    break;
                case "идти на север":
                    GameSettings.m_Player.Go(Direction.Up);
                    break;
                case "идти на юг":
                    GameSettings.m_Player.Go(Direction.Down);
                    break;
                case "идти на восток":
                    GameSettings.m_Player.Go(Direction.Right);
                    break;
                case "идти на запад":
                    GameSettings.m_Player.Go(Direction.Left);
                    break;
                case "помощь":
                    Dialogues.Write("help");
                    break;
                case "выход":
                    GameSettings.Exit();
                    break;
                default:
                    Dialogues.Write("no_command_error");
                    break;
            }
        }
    }
}
