using EtnaShop.DataAccess.Data;
using EtnaShop.DataAccess.Repository.IRepository;
using EtnaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EtnaShop.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _db;
        public ProductRepository(AppDbContext db): base(db)
        {
            _db= db;
        }
        

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
