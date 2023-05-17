using System.ComponentModel.DataAnnotations;

namespace Tacsoft_Master_Details.Models
{
    public class Supplier
    {
      

        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string SupplierName { get; set; } = "";
        [Required]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; } = "";
        [Required]
        [Display(Name = "Email")]
        public string SupplierEmail { get; set; } = "";
        [Required]
        [Display(Name = "Phone")]
        public string SupplierPhone { get; set; } = "";
        [Display(Name = "Address")]
        public string SupplierAddress { get; set; } = "";
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = "";
        public List<Purchase>  Purchases { get; set; }
    }
}
