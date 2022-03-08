using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace healthsystem.Data
{

    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext _appDbContext;
        public RepositoryBase(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return _appDbContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _appDbContext.Set<T>().Where(expression);
        }

        public IEnumerable<T> FindByConditionAsce(Expression<Func<T, bool>> expression, string sortBy)
        {
            return _appDbContext.Set<T>().Where(expression)
                //.OrderBy(x => EF.Property<object>(x, sortBy))
                ;
        }

        public IEnumerable<T> FindByConditionDesc(Expression<Func<T, bool>> expression, string sortBy)
        {
            return _appDbContext.Set<T>().Where(expression)
                //.OrderByDescending(x => EF.Property<object>(x, sortBy))
                ;
        }

        public T GetById(int id)
        {
            return _appDbContext.Set<T>().Find(id);
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
