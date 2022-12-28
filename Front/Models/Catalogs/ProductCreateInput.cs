using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Front.Models.Catalogs
{
    public class ProductCreateInput
    {
        [Display(Name = "Ürün ismi")]
        public string Name { get; set; }

        [Display(Name = "Ürün açıklama")]
        public string Description { get; set; }

        [Display(Name = "Ürün fiyat")]
        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string UserId { get; set; }

        public FeatureViewModel Feature { get; set; }

        [Display(Name = "Ürün kategori")]
        public string CategoryId { get; set; }

        [Display(Name = "Ürün Resim")]
        public IFormFile PhotoFormFile { get; set; }
    }
}