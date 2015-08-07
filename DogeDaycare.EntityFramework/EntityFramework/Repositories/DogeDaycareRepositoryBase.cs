using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace DogeDaycare.EntityFramework.Repositories
{
    public abstract class DogeDaycareRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<DogeDaycareDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected DogeDaycareRepositoryBase(IDbContextProvider<DogeDaycareDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class DogeDaycareRepositoryBase<TEntity> : DogeDaycareRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected DogeDaycareRepositoryBase(IDbContextProvider<DogeDaycareDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
