using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC_Proje.Web.Models;

namespace MVC_Proje.Web.Controllers
{
    public class ProductsController : Controller
    {

        private AppDbContext _context;

        private readonly ProductRepository _productRepository;


        public ProductsController(AppDbContext context)
        {
            _productRepository =new ProductRepository();
            

            _context = context;

            if (!_context.Products.Any())  // herhangi bir data yok ise bunu kaydet
            {
                _context.Products.Add(new Product()
                {
                    Name = "Çanta",
                    Price = 322,
                    Stock = 12,
                    Color = "Blue",
                    

                });

                _context.Products.Add(new Product()
                {
                    Name = "Saat",
                    Price = 65,
                    Stock = 9,
                    Color = "Black",
                    
                });

                _context.Products.Add(new Product()
                {
                    Name = "Gözlük",
                    Price = 169,
                    Stock = 34,
                    Color = "Colorful",
                    
                });

                _context.SaveChanges();
            }
           
        }
        public IActionResult Index()
        {

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
