using System.Linq.Expressions;

namespace Application.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Return a list other type
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Get();

        /// <summary>
        /// Return of a type by it's id
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Add a new type
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Update a type (or create with it doesn't exists)
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete a type
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
