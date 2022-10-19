namespace CoalStore.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}
