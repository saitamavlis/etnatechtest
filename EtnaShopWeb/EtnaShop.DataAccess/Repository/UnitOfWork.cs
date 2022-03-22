using EtnaShop.DataAccess.Data;
using EtnaShop.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtnaShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository Product { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        
        private AppDbContext _db;

        public UnitOfWork(AppDbContext db) 
        {
            _db = db;
            Product = new ProductRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
