using System;

namespace AsyncAwait
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine($"Calling Mechanic {Thread.CurrentThread.ManagedThreadId}");
            Mechanic m = new();
            Console.WriteLine("Getting Gas.");
            int amount = m.GetGas();
            Console.WriteLine("Washing Car.");
            m.WashCar();
            Console.WriteLine("Changing Oil.");
            m.ChangeOil();
            Console.WriteLine($"Mechanic done {Thread.CurrentThread.ManagedThreadId}.");

            Console.WriteLine($"\nCalling Task Mechanic {Thread.CurrentThread.ManagedThreadId}\n");
            TaskMechanic taskMechanic = new();
            Console.WriteLine("Getting Gas.");
            var gasTask = taskMechanic.GetGas();
            Console.WriteLine("Washing Car.");
            var washTask = taskMechanic.WashCar();
            Console.WriteLine("Changing Oil.");
            var oilTask = taskMechanic.ChangeOil();
            var tasks = new List<Task> { gasTask, washTask, oilTask };
            Console.WriteLine($"Main - tasks started {Thread.CurrentThread.ManagedThreadId}");

            while (tasks.Any())
            {
                var t = Task.WhenAny(tasks).Result;
                Console.WriteLine($"Main - A task complete {Thread.CurrentThread.ManagedThreadId}");
                tasks.Remove(t);
            }

            Console.WriteLine($"Task Mechanic done {Thread.CurrentThread.ManagedThreadId}");
            MainAsync().Wait();
            Console.WriteLine($"Main - done {Thread.CurrentThread.ManagedThreadId}");
        }

        public static async Task MainAsync()
        {
            Console.WriteLine($"\nCalling MechanicAsync {Thread.CurrentThread.ManagedThreadId}\n");
            MechanicAsync taskMechanic = new();
            Console.WriteLine("Getting Gas.");
            var gasTask = taskMechanic.GetGas();
            Console.WriteLine("Washing Car.");
            var washTask = taskMechanic.WashCar();
            Console.WriteLine("Changing Oil.");
            var oilTask = taskMechanic.ChangeOil();
            var tasks = new List<Task> { gasTask, washTask, oilTask };
            Console.WriteLine($"MainAsync - tasks started {Thread.CurrentThread.ManagedThreadId}");

            while (tasks.Any())
            {
                var t = await Task.WhenAny(tasks);
                Console.WriteLine($"MainAsync - A task complete {Thread.CurrentThread.ManagedThreadId}");
                tasks.Remove(t);
            }

            Console.WriteLine($"MechanicAsync done {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"MainAsync - done {Thread.CurrentThread.ManagedThreadId}");
        }
    }

}
