using ConfectioneryChain.DB;
using System;
using System.Data.Entity;
using System.Linq;

namespace ConfectioneryChain.CMD
{
    internal class Program
    {
        private static void Main()
        {
            ConfectioneryChain_V5Entities db = new ConfectioneryChain_V5Entities();
            db.Confectioneries.Load();
            Console.WriteLine($"Вы имеете {db.Confectioneries.Count()} Кофейн");

            Console.WriteLine();
            Console.WriteLine("ALL!!!");
            Console.ReadLine();

        }
    }
}
