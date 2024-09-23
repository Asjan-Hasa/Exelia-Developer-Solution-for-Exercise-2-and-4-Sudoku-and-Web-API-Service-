using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BaseRepository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> SearchFor(Expression<Func<T, bool>>? predicate = null);
        T? GetById(long? id);
        void Insert(T? entity);
        void Delete(T? entity);
        void Update();
        void UpdateEntity(T? entity);
        ResultModel GetReturnMessage(string message, bool hasWarning, bool hasError);
    }
}
