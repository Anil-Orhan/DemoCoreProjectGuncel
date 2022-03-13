using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Demo.Core.DAL.Conrete;
using Demo.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Core.DAL.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
       
    {
        public NorthwindContext _NorthwindContext;
        public EfEntityRepositoryBase(NorthwindContext northwindContext)
        {
            _NorthwindContext=northwindContext;
        }
        public void Add(TEntity entity)
        {
          
                var addedEntity = _NorthwindContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                _NorthwindContext.SaveChanges();
            
        }

        public void Delete(TEntity entity)
        {
           
                var deletedEntity = _NorthwindContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                _NorthwindContext.SaveChanges();
           
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
           
                return _NorthwindContext.Set<TEntity>().SingleOrDefault(filter);
           

        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
           
                return filter == null
                    ? _NorthwindContext.Set<TEntity>().ToList()
                    : _NorthwindContext.Set<TEntity>().Where(filter).ToList();
           
        }

        public void Update(TEntity entity)
        {
           
                var updatedEntity = _NorthwindContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                _NorthwindContext.SaveChanges();
            
        }
    }
}
