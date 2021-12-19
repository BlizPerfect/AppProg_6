using System;

namespace AppProg_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new MyStupidLogger("log.txt");

            var roulette = new Roulette(logger);

            while (!roulette.IsEmpty)
            {
                Console.ReadKey();
                roulette.PullOutKeg();
            }
            logger.СallToFinishWork();
        }
    }
}
