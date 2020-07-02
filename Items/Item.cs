using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FindTheCat
{
    public abstract class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public bool IsAlive { get; private set; }

        public Item(string name, string desc, bool isAlive)
        {
            Name = name;
            Description = desc;
            IsAlive = isAlive;
        }

        public virtual string GetInfo()
        {
            return $"{Name}: {Description}.";
        }
    }
}
