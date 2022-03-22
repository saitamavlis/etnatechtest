using EtnaShop.DataAccess.Repository.IRepository;
using EtnaShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EtnaShopWeb.Controllers
{
    public class ProductController : Controller
    {
        /*NOTES:
         The names of the variables that corresponse to model objects
        obtained from database will have the structure "modelname"+FromDb*/
        
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll();
            return View(objProductList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Producto creado correctamente";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _unitOfWork.Product.GetFirstOrDefault(x=>x.Id==id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Producto editado correctamente";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var productFromDb = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(productFromDb);
            _unitOfWork.Save();
            return RedirectToAction("Index");


        }
        
        //Get
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
    }
}
