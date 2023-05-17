using Master_Details.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Master_Details.Models
{
    public class Item:BaseEntity
    {
        [Display(Name = "Item Name")]
        public string ItemName { get; set; } = "";

        [Display(Name = "Item Code")]
        public string ItemCode { get; set; } = "";
        public string Discription { get; set; } = "";
        public IList<PurchaseItem>  PurchaseItems { get; set; }
    }
}
