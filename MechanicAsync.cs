using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class MechanicAsync : ITaskMechanic
    {
        public async Task WashCar()
        {
            Console.WriteLine($"WashCar start {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() =>
            {
                Console.WriteLine($"WashCar task {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(Random.Shared.Next(1000, 10_000));
            });

            Console.WriteLine($"WashCar done {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task<int> GetGas()
        {
            Console.WriteLine($"GetGas start {Thread.CurrentThread.ManagedThreadId}");
            var result = await Task.Run(() =>
            {
                Console.WriteLine($"GetGas task {Thread.CurrentThread.ManagedThreadId}");
                int result = Random.Shared.Next(1000, 10_000);
                Thread.Sleep(result);
                return result;
            });
            Console.WriteLine($"GetGas done {Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        public async Task ChangeOil()
        {
            Console.WriteLine($"ChangeOil start {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() =>
            {
                Console.WriteLine($"ChangeOil task {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(Random.Shared.Next(1000, 10_000));
            });
            Console.WriteLine($"ChangeOil done {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
