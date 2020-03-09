using System.Threading.Tasks;

using GameStore.DAL.Models;

using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class Repository<TContext, TEntity> : ReadonlyRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        public Repository(TContext context)
            : base(context)
        {
        }

        public void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public TEntity Delete(object id)
        {
            TEntity entity = Context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                Delete(entity);
            }
            return entity;
        }

        public async Task<TEntity> DeleteAsync(object id)
        {
            TEntity entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                Delete(entity);
            }
            return entity;
        }

        public void Delete(TEntity entity)
        {
            var dbSet = Context.Set<TEntity>();
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
