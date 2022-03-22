using EtnaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtnaShop.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Method used to update data of and instance of Product class.
        /// </summary>
        /// <param name="obj">Product object.</param>
        void Update(Product obj);

       
    }
}
