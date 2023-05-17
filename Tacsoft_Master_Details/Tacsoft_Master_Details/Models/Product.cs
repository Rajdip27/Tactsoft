using System.ComponentModel.DataAnnotations;

namespace Tacsoft_Master_Details.Models
{
    public class Product
    {
        public Product()
        {
            this.PurchaseItems = new List<PurchaseItem>();
        }
        public int ID { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = "";
        [Required]

        [Display(Name = "Product Code")]
        public string ProductCode { get; set; } = "";
        [Required]
        [Display(Name = "Discription")]
        public string Discription { get; set; } = "";
        public List<PurchaseItem> PurchaseItems { get; set;}

    }
}
