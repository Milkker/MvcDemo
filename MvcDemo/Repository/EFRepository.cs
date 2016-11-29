using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcDemo.Repository
{
    public abstract class EFRepository<TEntity, TModel> : IRepository<TEntity, TModel>
        where TEntity : class, IConvertToModel<TModel>
        where TModel : IConvertToEntity<TEntity>
    {
        public twd_demoEntities SqlDb { get; set; }

        public EFRepository(twd_demoEntities sqlDb)
        {
            SqlDb = sqlDb;
        }

        public void Create(TModel model)
        {
            var dbModel = SqlDb.Set<TEntity>().Create();

            //Mapping
            dbModel = model.ConverToEntity();

            SqlDb.Set<TEntity>().Add(dbModel);
            SqlDb.SaveChanges();
        }

        public IQueryable<TModel> Read()
        {
            var query = SqlDb.Set<TEntity>().Select(m => m.ConvertToModel());

            return query;
        }

        public void Update(TModel model)
        {
            //Mapping
            var dbModel = model.ConverToEntity();

            SqlDb.Set<TEntity>().Attach(dbModel);
            SqlDb.SaveChanges();
        }

        public void Delete(TModel model)
        {
            //Mapping
            var dbModel = model.ConverToEntity();

            SqlDb.Set<TEntity>().Attach(dbModel);
            SqlDb.Entry(dbModel).State = System.Data.Entity.EntityState.Deleted;
            SqlDb.SaveChanges();
        }
    }
}