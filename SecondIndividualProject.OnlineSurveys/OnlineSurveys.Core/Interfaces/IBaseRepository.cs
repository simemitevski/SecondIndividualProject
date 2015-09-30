using System;
using System.Collections.Generic;

namespace OnlineSurveys.Core.Interfaces
{
    interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entiy);
        TEntity GetById(Guid id);
        IList<TEntity> GetAll();
    }
}
