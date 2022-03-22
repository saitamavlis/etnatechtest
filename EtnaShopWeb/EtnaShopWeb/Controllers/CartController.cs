using EtnaShop.DataAccess.Repository.IRepository;
using EtnaShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EtnaShopWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            string orderId = HttpContext.Request.Cookies["order_id"];
            IEnumerable<ShoppingCart> listCart;
            listCart = _unitOfWork.ShoppingCart.GetAll(x=>x.OrderId==orderId, includeProp: "Product");
            double total=0;
            List<double> subTotalsList = new List<double>();
            foreach(ShoppingCart cart in listCart)
            {
                subTotalsList.Add(cart.Count * cart.Product.Price);
                total += cart.Count * cart.Product.Price;
            }
            ViewBag.SubTotals = subTotalsList;
            ViewBag.Total=total;
            ViewBag.OrderId = orderId;
            return View(listCart);
        }

        
        public IActionResult Delete(int? id)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(x => x.Id == id);
            if (cartFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.ShoppingCart.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction("Index");


        }

        public IActionResult Details(string orderId)
        {
            IEnumerable<ShoppingCart> listCart;
            listCart = _unitOfWork.ShoppingCart.GetAll(x => x.OrderId == orderId, includeProp: "Product");
            double total = 0;
            List<double> subTotalsList = new List<double>();
            foreach (ShoppingCart cart in listCart)
            {
                subTotalsList.Add(cart.Count * cart.Product.Price);
                total += cart.Count * cart.Product.Price;
            }
            ViewBag.SubTotals = subTotalsList;
            ViewBag.Total = total;
            ViewBag.OrderId = orderId;
            string cookieValue = Guid.NewGuid().ToString();
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(3);
            HttpContext.Response.Cookies.Append("order_id", cookieValue, cookieOptions);
            return View(listCart);
        }


    }
}
