using EtnaShop.DataAccess.Repository.IRepository;
using EtnaShop.Models;
using EtnaShopWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace EtnaShopWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ShoppingCartController(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
            
            
        }

        public IActionResult Index()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("order_id"))
            {
                string cookieValue = Guid.NewGuid().ToString();
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(3);
                HttpContext.Response.Cookies.Append("order_id", cookieValue, cookieOptions);
            }
            IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll();
            return View(objProductList);
        }
       
       

        //Get
        public IActionResult Details(int productId)
        {
            ShoppingCart cart;
            Product product = _unitOfWork.Product.GetFirstOrDefault(x=>x.Id
            == productId);
            
           
                cart = new()
                {
                    Count = 1,
                    ProductId = productId,
                    Product = product,
                    OrderId = HttpContext.Request.Cookies["order_id"].ToString()
                };

           
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ShoppingCart cart)
        {
                _unitOfWork.ShoppingCart.Add(cart);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            
            
        }
    }
}