using Microsoft.AspNetCore.Mvc;
using MVC_Proje.Web.Controllers;
using System.ComponentModel.DataAnnotations;

namespace MVC_Proje.Web.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }

        public DateTime? PublishDate { get; set; }

        [StringLength(30, ErrorMessage = "isim alanı max 30 karakter olmalı")]
        [Required(ErrorMessage = "İsim Alanı Boş Bırakılamaz!")]

        [Remote(action: "HasProductName",controller: "Products")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Fiyat Alanı Boş Bırakılamaz!")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})", ErrorMessage ="Fiyat alanını düzenleyiniz.")]
        public string? Price { get; set; }

        [StringLength(200, MinimumLength = 10, ErrorMessage = "açıklama 10 ila 200 arasında olmalıdır.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Stok Alanı Boş Bırakılamaz!")]
        [Range(1, 8, ErrorMessage = "Stok değeri 1 ile 8 arasında olmalıdır.")]
        public int? Stock { get; set; }

        public string? Color { get; set; }

        public bool IsPublish { get; set; }

        public int Expire { get; set; }

    }
}
