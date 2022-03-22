using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EtnaShop.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        /// <summary>
        /// Method to obtain the first or default coincidence on a list.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProp = null);
        
        /// <summary>
        /// Method that returns all the objects of a model class.
        /// </summary>
        /// <returns>Objects Collection.</returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? includeProp = null);

        /// <summary>
        /// Method for adding objects to the database.
        /// </summary>
        /// <param name="entity">Object</param>
        void Add(T entity);

        /// <summary>
        /// Method to remove
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// Method for removing a colection of objects.
        /// </summary>
        /// <param name="entities"></param>
        void Removerange(IEnumerable<T> entities);
    }
}
