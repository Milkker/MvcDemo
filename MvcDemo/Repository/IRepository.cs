using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcDemo.Repository
{
    interface IRepository<TEntity, TModel>
        where TEntity : class, IConvertToModel<TModel>
        where TModel : IConvertToEntity<TEntity>
    {
        void Create(TModel model);
        IQueryable<TModel> Read();
        void Update(TModel model);
        void Delete(TModel model);
        IQueryable<TModel> Where(Expression<Func<TEntity, bool>> Func);
    }
}