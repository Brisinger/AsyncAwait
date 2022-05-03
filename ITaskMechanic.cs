namespace AsyncAwait
{
    public interface ITaskMechanic
    {
        Task ChangeOil();
        Task<int> GetGas();
        Task WashCar();
    }
}