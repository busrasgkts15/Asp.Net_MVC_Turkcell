using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC_Proje.Web.Models;

namespace MVC_Proje.Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductRepository _productRepository;


        public ProductsController()
        {
            _productRepository =new ProductRepository();
            if (!_productRepository.GetAll().Any()) {
                throw new Exception("Tüm datayı sildiniz.");
            }
        }
        public IActionResult Index()
        {

            var products = _productRepository.GetAll();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            _productRepository.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            return View();
        }
    }
}
