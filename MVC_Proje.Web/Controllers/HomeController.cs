using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC_Proje.Web.Models;
using MVC_Proje.Web.ViewModels;
using System.Diagnostics;

namespace MVC_Proje.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public HomeController(ILogger<HomeController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _context.Products.OrderByDescending(x => x.Id).Select(x => new ProductPartialViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock
            }).ToList();


            ViewBag.ProductListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products
            };
            return View();
        }

        public IActionResult Privacy()
        {
            var products = _context.Products.OrderByDescending(x => x.Id).Select(x => new ProductPartialViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock
            }).ToList();


            ViewBag.ProductListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products
            };
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Visitor()
        {
            return View();
        }


        public IActionResult SaveVisitorComment(VisitorViewModel visitorViewModel)
        {


            try
            {
                var visitor = _mapper.Map<Visitor>(visitorViewModel);

                visitor.Created = DateTime.Now;

                _context.Visitors.Add(visitor);
                _context.SaveChanges();

                TempData["result"] = "Yorum kaydedildi.";

                return RedirectToAction("Visitor");
            }
            catch(Exception)
            {
                TempData["result"] = "Yorum kaydedilirken bir hata meydana geldi.";

                return RedirectToAction("Visitor");
            }
           
        }

    }

}
