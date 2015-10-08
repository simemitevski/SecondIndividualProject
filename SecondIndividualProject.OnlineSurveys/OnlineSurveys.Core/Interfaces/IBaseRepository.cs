using System;
using System.Collections.Generic;
using OnlineSurveys.Core.Models;

namespace OnlineSurveys.Core.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entiy);
        TEntity GetById(Guid id);
        IList<TEntity> GetAll();
        void Save();
    }

    public interface IUserRepository : IBaseRepository<User>
    {
        bool CheckIfExist(string email, string username);
        bool IfExistUserWithTheseEmailAndPass(string email, string password);
    }

    public interface IRoleRepository : IBaseRepository<Role>
    {

    }

    public interface ISurveyRepository : IBaseRepository<Survey>
    {

    }

    public interface IQuestionRepository : IBaseRepository<Question>
    {

    }

    public interface IUserWhoTookTheSurveyRepository : IBaseRepository<UserWhoTookTheSurvey>
    {

    }

    public interface ITextAnswerRepository : IBaseRepository<TextAnswer>
    {

    }

    public interface IStarRatingAnswerRepository : IBaseRepository<StarRatingAnswer>
    {

    }

    public interface IMatrixRatingAnswerRepository : IBaseRepository<MatrixRatingAnswer>
    {

    }

    public interface IBoolAnswerRepository : IBaseRepository<BoolAnswer>
    {

    }
}
