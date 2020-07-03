using System;
using System.Collections.Generic;
using System.Text;

namespace FindTheCat
{
    public static class ItemGenerator
    {
        public static void Generate(List<Type> itemTypes, Room room)
        {
            var rnd = new Random();
            int itemsCount = rnd.Next(0, 3);
            room.Items ??= new List<Item>(itemsCount);
            for (int i = 0; i < itemsCount; i++)
            {
                var item = itemTypes[rnd.Next(itemTypes.Count)];
                room.Items.Add((Item)Activator.CreateInstance(item));
            }
        }
    }
}
