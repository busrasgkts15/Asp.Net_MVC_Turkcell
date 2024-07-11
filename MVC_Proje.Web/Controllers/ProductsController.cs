using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC_Proje.Web.Helpers;
using MVC_Proje.Web.Models;

namespace MVC_Proje.Web.Controllers
{
    public class ProductsController : Controller
    {

        private AppDbContext _context;

        private IHelper _helper;

       


        public ProductsController(AppDbContext context , IHelper helper)
        {

            _helper = helper;

            _context = context;

        }
        public IActionResult Index([FromServices]IHelper helper2)
        {

            var text = "Asp.net";
            var upperText = _helper.Upper(text);
            
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            //Pimary key alanıma göre bir sorhgu gerçekleştirip silmek istediğim datayı bulup silecek.
            _context.Products.Remove(product);
            // Bu bilgilerin veri tabanı taafından da değişmesi için:
            _context.SaveChanges();
            TempData["remove"] = "Ürün başarıyla silindi.";
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveProduct(Product product)
        {

            ////1.yöntem
            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price =decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock =int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();
            // 2. yöntem
            //Product newProduct = new Product() { Name = Name, Price = Price, Stock = Stock, Color = Color };

            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla eklendi.";
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {

            var product = _context.Products.Find(id);
            return View(product);
        }


        [HttpPost]
        public IActionResult Update(Product updateProduct , int productId)
        {
            updateProduct.Id = productId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
