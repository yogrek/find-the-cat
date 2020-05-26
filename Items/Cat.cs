using System;
using System.Collections.Generic;
using System.Text;

namespace find_the_cat
{
    public class Cat : Item
    {
        public Cat() : base(name: "Уголек", desc: "Твой котик, которого ты искал.", isAlive: true) { }
    }
}
