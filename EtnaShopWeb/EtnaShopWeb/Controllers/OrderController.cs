using EtnaShop.DataAccess.Repository.IRepository;
using EtnaShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EtnaShopWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<ShoppingCart> listCart;
            listCart = _unitOfWork.ShoppingCart.GetAll();
            return View(listCart);
        }


        public IActionResult Details(string orderId)
        {
            IEnumerable<ShoppingCart> listCart;
            listCart = _unitOfWork.ShoppingCart.GetAll(x => x.OrderId==orderId, includeProp: "Product");
            double total = 0;
            List<double> subTotalsList = new List<double>();
            foreach (ShoppingCart cart in listCart)
            {
                subTotalsList.Add(cart.Count * cart.Product.Price);
                total += cart.Count * cart.Product.Price;
            }
            ViewBag.SubTotals = subTotalsList;
            ViewBag.Total = total;
            ViewBag.OrderId=orderId;
            
            return View(listCart);
        }
    }
}
