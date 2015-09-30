using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using OnlineSurveys.Core.Interfaces;
using OnlineSurveys.Core.Models;

namespace OnlinceSurveys.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseModel
    {
        protected OnlineSurveysDbContext _context;
        public BaseRepository(OnlineSurveysDbContext context)
        {
            _context = context;
        }

        //DbContext.Set<TEntity> Method:
        //Returns a DbSet<TEntity> instance for access to entities of the given type in the context and the underlying store.
        //TEntity - The type entity for which a set should be returned.

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().AddOrUpdate(entity);
        }

        public void Delete(TEntity entiy)
        {
            _context.Set<TEntity>().Remove(entiy);
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IList<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
