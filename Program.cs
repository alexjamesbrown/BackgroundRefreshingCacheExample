using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundRefreshingCacheExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var cache = new Cache();

            //this is to mimic 'singleton' behaviour of the class that consumes Cache
            //keeps the console app alive
            while (true)
            {
                var itemFromCache = cache.GetItem();
                Console.WriteLine(itemFromCache);

                Thread.Sleep(500);
            }
        }
    }
}