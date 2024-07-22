namespace MVC_Proje.Web.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public string? Color { get; set; }

        public bool IsPublish { get; set; }

        public int Expire { get; set; }


    }
}
