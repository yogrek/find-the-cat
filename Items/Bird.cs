using System;
using System.Collections.Generic;
using System.Text;

namespace find_the_cat
{
    public class Bird : Item
    {
        public Bird() : base(name: "Птица", desc: "Обычная маленькая птичка.", isAlive: true) { }
    }
}
