namespace SupplyChain.Infrastructure
{
    public interface ICrudRepository<TEntity>: IReadonlyRepository<TEntity> where TEntity : class, new()
    {

        //void Add<T>(TEntity entity) where T : TEntity;

        //void Update<T>(TEntity entity) where T : TEntity;

        //void Delete<T>(TEntity entity) where T : TEntity;

        //void DeleteById(int id);


        //Without the generics
        void Add(TEntity entity);

        void Update(TEntity entity);

        //void Delete(TEntity entity);
        //void DeleteById(int id);

        void Delete(int id);


    }
}
