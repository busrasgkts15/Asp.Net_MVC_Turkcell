using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC_Proje.Web.Models;
using MVC_Proje.Web.ViewModels;

namespace MVC_Proje.Web.Views.Shared.ViewComponents
{
    public class VisitorViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public VisitorViewComponent(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var visitors = _context.Visitors.ToList();

            var visitorViewModel = _mapper.Map<List<VisitorViewModel>>(visitors);
            ViewBag.visitorViewModel = visitorViewModel;

            return View();
        }
    }
}
