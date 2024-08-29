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


        public ProductsController(AppDbContext context, IMapper mapper)
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
        public IActionResult Add(ProductViewModel product)
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


            if (ModelState.IsValid)
            {

                try
                {
                    _context.Products.Add(_mapper.Map<Product>(product));
                    _context.SaveChanges();
                    TempData["status"] = "Ürün başarıyla eklendi.";
                    return RedirectToAction("Index");

                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ürün kaydedilirken hata meydana geldi.");

                    return View();
                }

            }
            else
            {

                return View();
            }

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


            return View(_mapper.Map<ProductViewModel>(product));
        }


        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct, int productId)
        {
            var product = _context.Products.Find(productId);
            if (!ModelState.IsValid)
            {

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
                return View();
            }
            updateProduct.Id = productId;
            _context.Products.Update(_mapper.Map<Product>(updateProduct));
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }


        [AcceptVerbs("GET", "POST")]
        public IActionResult HasProductName(string Name)
        {
            var anyProduct = _context.Products.Any(x => x.Name.ToLower() == Name.ToLower());

            if (anyProduct)
            {
                return Json("Ürün ismi veri tabanında bulunmaktadır.");
            }
            else
            {
                return Json(true);
            }
        }
    }



    internal class SelectList<T>
    {
    }
}
