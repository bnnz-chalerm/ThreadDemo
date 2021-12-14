using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThreadDemo
{
     class Program
    {
        static void Main(string[] args)
        {
             Task.Run(async () => await Measure());
          //  var services = new UsersService();
          //  var userIds = GetUserIds(3);
          //Task.Run(async () =>   await services.GetUsersSynchrnously(userIds));
            //var priceComparer = new PriceComparerInit();
            //priceComparer.Init(1000, 10000);
            Console.WriteLine("end");
            System.Console.ReadKey();
        }
        private static async Task Measure()
        {
            var services = new UsersService();
            var stopper = new Stopwatch();
            var userIds = GetUserIds(1001);

            stopper.Start();
            await services.GetUsersSynchrnously(userIds);
            System.Console.WriteLine("Synchronous: " + stopper.Elapsed);

            stopper.Restart();
            await services.GetUsersInParallel(userIds);
            System.Console.WriteLine("In paralell: " + stopper.Elapsed);

            stopper.Restart();
            await services.GetUsersInParallelFixed(userIds);
            System.Console.WriteLine("In paralell fixed: " + stopper.Elapsed);

            stopper.Restart();
            await services.GetUsersInParallelInWithBatches(userIds);
            System.Console.WriteLine("In paralell with batches: " + stopper.Elapsed);
        }

        private static IEnumerable<int> GetUserIds(int numberOfIds)
        {
            //Console.WriteLine("get loop users");
            for (int i = 2; i <= numberOfIds; i++)
            {
                yield return i;
            }
        }
    }
}
