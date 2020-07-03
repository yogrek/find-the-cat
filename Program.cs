using System;
using System.IO;
using System.Security.Cryptography;

namespace FindTheCat
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Start();
            while (true)
            {
                Controller.ReadCommand();
            }
        }
    }
}
