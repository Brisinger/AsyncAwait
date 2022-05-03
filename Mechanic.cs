using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Mechanic : IMechanic
    {
        public void WashCar()
        {
            Console.WriteLine($"WashCar start {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(Random.Shared.Next(1000, 10_000));
            Console.WriteLine($"WashCar done {Thread.CurrentThread.ManagedThreadId}");
        }

        public int GetGas()
        {
            Console.WriteLine($"GetGas start {Thread.CurrentThread.ManagedThreadId}");
            int result = Random.Shared.Next(1000, 10_000);
            Thread.Sleep(result);
            Console.WriteLine($"GetGas done {Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        public void ChangeOil()
        {
            Console.WriteLine($"ChangeOil start {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(Random.Shared.Next(1000, 10_000));
            Console.WriteLine($"ChangeOil done {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
