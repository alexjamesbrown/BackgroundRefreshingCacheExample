using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundRefreshingCacheExample
{
    public class Cache
    {
        public Cache()
        {
            var cts = new CancellationTokenSource();

            var workerThread = Task.Run(async () =>
                        {
                            while (true)
                            {
                                await Refresh();
                                await Task.Delay(TimeSpan.FromSeconds(2), cts.Token); //refresh every 2 seconds
                            }
                        }, cts.Token);
        }

        private string cachedItem = null;

        public string GetItem()
        {
            if (cachedItem == null)
                Refresh().Wait(); //naff, but simulate loading first

            return cachedItem;
        }

        async Task Refresh()
        {
            await Task.Delay(150); //simulate delay from our api
            cachedItem = "From api: " + DateTime.Now.Ticks; ;
        }
    }
}
