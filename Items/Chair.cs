using System;
using System.Collections.Generic;
using System.Text;

namespace FindTheCat
{
    public class Chair : Item
    {
        public Chair() : base(name: "Стул", desc: "Обычный деревянный стул.", isAlive: false) { }
    }
}
