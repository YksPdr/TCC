namespace ConectaBairro.Infrastructure.UnityOfWork
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
