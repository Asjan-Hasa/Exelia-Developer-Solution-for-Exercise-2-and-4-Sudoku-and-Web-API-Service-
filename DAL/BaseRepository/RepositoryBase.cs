using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BaseRepository
{
    public class RepositoryBase<T>(BeerCollectionContext applicationDbContext
      ) : IRepositoryBase<T>
        where T : class
    {
        protected BeerCollectionContext _applicationDbContext = applicationDbContext;

        public void Delete(T? entity)
        {
            if (entity != null)
            {
                _applicationDbContext.Set<T>().Remove(entity);
                _applicationDbContext.SaveChanges();
            }
        }

        public T? GetById(long? id)
        {
            if (id != null)
                return _applicationDbContext.Set<T>().Find(id);
            else return null;
        }
        public List<T> GetAll()
        {
            return _applicationDbContext.Set<T>().ToList();
        }

        public void Insert(T? entity)
        {
            if (entity != null)
            {
                _applicationDbContext.Set<T>().Add(entity);
                _applicationDbContext.SaveChanges();
            }
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query;
            if (predicate == null)
            {
                query = _applicationDbContext.Set<T>();
            }
            else
            {
                query = _applicationDbContext.Set<T>().Where(predicate);
            }
           
            return query;
        }

        public void Update()
        {
            _applicationDbContext.SaveChanges();
        }

        public void UpdateEntity(T? entity)
        {
            if (entity != null)
            {
                _applicationDbContext.Entry(entity).State = EntityState.Modified;
                _applicationDbContext.SaveChanges();
            }
        }
        public ResultModel GetReturnMessage(string message, bool hasWarning, bool hasError)
        {
            return new ResultModel { HasError = hasError, HasWarning = hasWarning, Message = message };
        }
    }
}
