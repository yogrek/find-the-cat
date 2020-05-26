using System;
using System.Collections.Generic;
using System.Text;

namespace find_the_cat
{
    public class Chair : Item
    {
        public Chair() : base(name: "Стул", desc: "Обычный деревянный стул.", isAlive: false) { }
    }
}
