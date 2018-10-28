using OMPhoenix.Data.Infrastructure;
using OMPhoenix.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace OMPhoenix.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new()
    {
        private OMPhoenixContext _dataContext;

        #region Properties
        protected IDbFactory DbFactory { get; }

        protected OMPhoenixContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        public EntityBaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion
        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().Where(x=>x.IsDeleted==false);
        } 
        public virtual IQueryable<T> All => GetAll();

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = DbContext.Set<T>().Where(x => x.IsDeleted == false);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        //public T GetSingle(Guid id)
        //{
        //    return GetAll().FirstOrDefault(x => x.ID == id);
        //}
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate).Where(x => x.IsDeleted == false);
        }

        public virtual void Add(T entity)
        {
            entity.IsDeleted = false;
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedDate = DateTime.UtcNow;
            //DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            DbContext.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = false;
                entity.CreatedDate = DateTime.UtcNow;
                entity.ModifiedDate = DateTime.UtcNow;
                //DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
                DbContext.Set<T>().Add(entity);
            } 
        }

        public virtual void Edit(T oldEntity, T newEntity)
        {
            newEntity.KeyId = oldEntity.KeyId;
            newEntity.IsDeleted = false;
            newEntity.CreatedDate = oldEntity.CreatedDate;
            newEntity.ModifiedDate = DateTime.UtcNow;
            DbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity); 
        }
      
        public virtual void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.UtcNow;
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        #region Get Data By Id..
        //to get data by id
        //public virtual T GetById(Guid entity)
        //{
        //    var abc = DbContext.Set<T>().FirstOrDefault(x => (x.ID == entity) && (x.IsDeleted == false));
        //    return abc;
        //}
        #endregion
    }
}
