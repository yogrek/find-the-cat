using System;
using System.Collections.Generic;
using System.Text;

namespace find_the_cat
{
    public enum Direction
    {
        Up,
        Left,
        Right,
        Down
    }

    public class Player
    {
        public Room CurrentRoom { get; set; }
        public string Name { get; private set; }

        public List<Item> Backpack;

        public Player(string name, Room startRoom)
        {
            Name = name;
            CurrentRoom = new Room(startRoom);
        }

        public void GetInfo()
        {
            Console.WriteLine($"Меня зовут {Name}. Я ищу своего котика Уголька.");
        }

        public void Go(Direction dir)
        {
            Console.WriteLine($"Я сейчас в комнате {CurrentRoom.X}, {CurrentRoom.Y}");
            switch (dir)
            {
                case Direction.Up:
                    GoUp();
                    break;
                case Direction.Left:
                    GoLeft();
                    break;
                case Direction.Right:
                    GoRight();
                    break;
                case Direction.Down:
                    GoDown();
                    break;
                default:
                    throw new ArgumentException("Invalid direction!");
            }
        }

        public void LookAround()
        {
            CurrentRoom.ShowItems();
        }

        public void TakeItem(Item item)
        {
            Backpack ??= new List<Item>();
            if (item.IsAlive)
            {
                Backpack.Add(item);
            }
            else
            {
                Console.WriteLine("Вы не можете взять этот предмет.");
            }
        }

        public void ShowInventory()
        {
            Backpack.ForEach(i => Console.WriteLine(i.ToString()));
        }

        private void GoUp()
        {
            if (!CurrentRoom.IsOnTopBorder())
            {
                CurrentRoom.X--;
            }
            else
            {
                Console.WriteLine("Вы не можете двигаться на север.");
            }
        }

        private void GoLeft()
        {
            if (!CurrentRoom.IsOnLeftBorder())
            {
                CurrentRoom.Y--;
            }
            else
            {
                Console.WriteLine("Вы не можете двигаться на запад.");
            }
        }

        private void GoRight()
        {
            if (!CurrentRoom.IsOnRightBorder())
            {
                CurrentRoom.Y++;
            }
            else
            {
                Console.WriteLine("Вы не можете двигаться на восток.");
            }
        }

        private void GoDown()
        {
            if (!CurrentRoom.IsOnBottomBorder())
            {
                CurrentRoom.X++;
            }
            else
            {
                Console.WriteLine("Вы не можете двигаться на юг.");
            }
        }
    }
}
