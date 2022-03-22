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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private AppDbContext _db;
        public ShoppingCartRepository(AppDbContext db): base(db)
        {
            _db= db;
        }
        
        
      
    }
}
