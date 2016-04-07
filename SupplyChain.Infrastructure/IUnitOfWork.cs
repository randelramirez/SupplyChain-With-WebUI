namespace SupplyChain.Infrastructure
{
    public interface IUnitOfWork
    {
        //public IContext context;

        void Save();

    }
}