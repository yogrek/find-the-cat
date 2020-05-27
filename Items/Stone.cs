using System;
using System.Collections.Generic;
using System.Text;

namespace find_the_cat
{
    public class Stone : Item
    {
        public Stone() : base(name: "Камень", desc: "Обычный серый камень.", isAlive: false) { }
    }
}
