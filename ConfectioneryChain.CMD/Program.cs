using ConfectioneryChain.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryChain.CMD
{
    class Program
    {
        static void Main(string[] args)
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
