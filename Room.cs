using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FindTheCat
{
    public class Room
    {
        public int X { get; set; }
        public int Y { get; set; }

        public List<Item> Items;

        public Room(int x, int y)
        {
            X = x;
            Y = y;
            Items = new List<Item>();
        }

        public Room(Room r)
        {
            X = r.X;
            Y = r.Y;
            Items = new List<Item>(r.Items);
        }

        public void GenerateItems(List<Type> itemTypes)
        {
            var rnd = new Random();
            int itemsCount = rnd.Next(0, 3);
            Items = new List<Item>(itemsCount);
            for (int i = 0; i < itemsCount; i++)
            {
                var item = itemTypes[rnd.Next(itemTypes.Count)];
                Items.Add((Item)Activator.CreateInstance(item));
            }
        }

        public void ShowItems()
        {
            if (Items.Count == 0)
            {
                Dialogues.Write("no_items");
                return;
            }
            Dialogues.Write("show_items");
            Items.ToList().ForEach(i => Console.WriteLine(i.Name));
        }

        public bool IsOnTopBorder() => X == 0;

        public bool IsOnLeftBorder() => Y == 0;

        public bool IsOnRightBorder() => Y == Game.Nh - 1;

        public bool IsOnBottomBorder() => X == Game.Nv - 1;
    }
}
