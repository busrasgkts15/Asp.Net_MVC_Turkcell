using System.ComponentModel.DataAnnotations;

namespace MVC_Proje.Web.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }

        public DateTime? PublishDate { get; set; }

        [Required(ErrorMessage = "İsim Alanı Boş Bırakılamaz!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Fiyat Alanı Boş Bırakılamaz!")]
        [Range(1, 1000, ErrorMessage = "Fiyatı 1000 tl altında olamaz.")]
        public decimal? Price { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Stok Alanı Boş Bırakılamaz!")]
        [Range(1,8 , ErrorMessage = "Stok değeri 1 ile 8 arasında olmalıdır.")]
        public int? Stock { get; set; }

        public string? Color { get; set; }

        public bool IsPublish { get; set; }

        public int Expire { get; set; }


    }
}
