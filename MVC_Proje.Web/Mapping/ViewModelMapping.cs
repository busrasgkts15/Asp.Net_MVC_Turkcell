using AutoMapper;
using MVC_Proje.Web.Models;
using MVC_Proje.Web.ViewModels;

namespace MVC_Proje.Web.Mapping
{
    public class ViewModelMapping : Profile
    {

        public ViewModelMapping()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Visitor, VisitorViewModel>().ReverseMap();
        }

    }
}
