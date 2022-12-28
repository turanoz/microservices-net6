using System.ComponentModel.DataAnnotations;

namespace Front.Models.Catalogs
{
    public class FeatureViewModel
    {
        [Display(Name = "Ürün süre")]
        public int Duration { get; set; }
    }
}