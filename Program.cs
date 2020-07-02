using System;
using System.IO;
using System.Security.Cryptography;

namespace FindTheCat
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSettings.StartGame();
            while (true)
            {
                GameSettings.ReadCommand();
            }
        }
    }
}
