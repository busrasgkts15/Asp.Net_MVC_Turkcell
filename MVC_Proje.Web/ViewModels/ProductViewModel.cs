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
        public decimal? Price { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Stok Alanı Boş Bırakılamaz!")]
        public int? Stock { get; set; }

        public string? Color { get; set; }


        [Required(ErrorMessage = "Yayınlansın mı?")]
        public bool? IsPublish { get; set; }

        public int Expire { get; set; }


    }
}
