using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {


        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context=new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            using (var context = new TContext())
            {
                DbSet<TEntity> dbSet = context.Set<TEntity>();

                TEntity item = null;
                foreach (var includeExpression in includeExpressions)
                {
                    item =dbSet.Include(includeExpression).SingleOrDefault(filter);
                }

                return item;
            }
        }
        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ?
                     context.Set<TEntity>().ToList() :
                     context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null,params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            using (var context = new TContext())
            {
                DbSet<TEntity> dbSet = context.Set<TEntity>();

                List<TEntity> list = null;
                foreach (var includeExpression in includeExpressions)
                {
                    list = filter==null?dbSet.Include(includeExpression).ToList()
                        : dbSet.Include(includeExpression).Where(filter).ToList();
                }

                return list;
            }
        }
        public void Add(TEntity entity)
        {
            using (var context=new TContext())
            {
               var addedEntity= context.Entry(entity);
                //addedEntity.State = EntityState.Added;
                addedEntity.Context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
