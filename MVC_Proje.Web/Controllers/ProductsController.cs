using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC_Proje.Web.Helpers;
using MVC_Proje.Web.Models;
using MVC_Proje.Web.ViewModels;

namespace MVC_Proje.Web.Controllers
{
    public class ProductsController : Controller
    {

        private AppDbContext _context;


        private readonly IMapper _mapper;


        public ProductsController(AppDbContext context , IMapper mapper)
        {

            _context = context;
            _mapper = mapper;

        }

        public IActionResult Index()
        {
            
            var products = _context.Products.ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products));
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
           
          ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 ay" , 1},
                {"3 ay" , 3 },
                {"6 ay" ,6 },
                {"12 ay" ,12}
            };
            
            ViewBag.Color = new Dictionary<int, string>()
            {
                {1 , "Sarı" },
                {2 , "Gri" },
                {3 , "Yeşil" },
                {4 , "Mor" },
                {5 , "Siyah" },
                {6 , "Kırmızı" }
            };
            return View();
        }

        [HttpPost]
        public IActionResult SaveProduct(Product product)
        {

            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla eklendi.";
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.ColorValue = product.Color;

            ViewBag.ExpireValue = product.Expire;

            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 ay" , 1},
                {"3 ay" , 3 },
                {"6 ay" ,6 },
                {"12 ay" ,12}
            };

            ViewBag.Color = new Dictionary<int, string>()
            {
                {1 , "Sarı" },
                {2 , "Gri" },
                {3 , "Yeşil" },
                {4 , "Mor" },
                {5 , "Siyah" },
                {6 , "Kırmızı" }
            };








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

    internal class SelectList<T>
    {
    }
}
