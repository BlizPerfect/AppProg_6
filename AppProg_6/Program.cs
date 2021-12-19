using System;

namespace AppProg_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var roulette = new Roulette();
            while (!roulette.IsEmpty)
            {
                Console.ReadKey();
                roulette.PullOutKeg();
            }
        }
    }
}
