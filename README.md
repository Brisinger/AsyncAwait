# AsyncAwait
Async and Await, from synchronous, task based asynchronous executions till async and await asynchronous sequential style code. It covers everything required to understand about Async and Await keywords and how it differs from awaitable task based programming with ContinueWith syntax. 
A simple .NET 6 Console based application.
To build the application use command: dotnet build.
To run the console app use command: dotnet run.
It contains class with synchronous methods.
It contains class with Task based methods executed asynchronously on different task threads.
It contains class with Async methods executed asynchronously, with await statements on the same task thread from thread pool.
Shows the difference between execution of methods in 3 different classes.
The async keyword allocates task thread from thread pool provided by CPU, in the most optimized manner such that no threads remain idle.
