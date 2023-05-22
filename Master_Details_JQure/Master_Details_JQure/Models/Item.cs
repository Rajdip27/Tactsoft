using Master_Details_JQure.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Master_Details_JQure.Models
{
    public class Item: BaseEntity
    {
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }
        [Display(Name = "Discription")]
        public string Discription { get; set; }
        public List<PurchaseItem> PurchaseItems { get; set; }
    }
}
