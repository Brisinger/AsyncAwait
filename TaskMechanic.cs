using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class TaskMechanic : ITaskMechanic
    {
        public Task WashCar()
        {
            Console.WriteLine($"WashCar start {Thread.CurrentThread.ManagedThreadId}");
            return Task.Run(() =>
            {
                Console.WriteLine($"WashCar task {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(Random.Shared.Next(1000, 10_000));
            }).ContinueWith(t =>
                Console.WriteLine($"WashCar done {Thread.CurrentThread.ManagedThreadId}")
            );
        }

        public Task<int> GetGas()
        {
            Console.WriteLine($"GetGas start {Thread.CurrentThread.ManagedThreadId}");
            int result = Random.Shared.Next(1000, 10_000);
            return Task.Run(() =>
            {
                Console.WriteLine($"GetGas task {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(result);
                return result;
            }).ContinueWith(t =>
            {
                Console.WriteLine($"GetGas done {Thread.CurrentThread.ManagedThreadId}");
                return result;
            });
        }

        public Task ChangeOil()
        {
            Console.WriteLine($"ChangeOil start {Thread.CurrentThread.ManagedThreadId}");
            return Task.Run(() =>
            {
                Console.WriteLine($"ChangeOil task {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(Random.Shared.Next(1000, 10_000));
            }).ContinueWith(t =>
                Console.WriteLine($"ChangeOil done {Thread.CurrentThread.ManagedThreadId}")
            );
        }
    }
}
