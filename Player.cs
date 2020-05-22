using System;
using System.Collections.Generic;
using System.Text;

namespace find_the_cat
{
    public class Player
    {
        public Room CurrentRoom { get; set; }
        public string Name { get; }

        public Player(string name, Room startRoom)
        {
            Name = name;
            CurrentRoom = startRoom;
        }
    }
}
