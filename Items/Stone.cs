using System;
using System.Collections.Generic;
using System.Text;

namespace find_the_cat
{
    public class LivingItem : Item
    {
        public LivingItem() : base(name: "Камень", desc: "Обычный серый камень.", isAlive: false) { }
    }
}
