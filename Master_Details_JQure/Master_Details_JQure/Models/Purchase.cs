using Master_Details_JQure.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Master_Details_JQure.Models
{
    public class Purchase: BaseEntity
    {
        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; } = DateTime.Now.Date;
        [Required]
        [Display(Name = "Purchase Code")]
        public string PurchaseCode { get; set; } = "TS" + DateTime.Now.ToString("yyyyMMdd") +
        Guid.NewGuid().ToString().Substring(0, 3).ToUpper();
        [Display(Name = "Purchase Type")]
        public string PurchaseType { get; set; }
        [Display(Name = "Supplier")]
        [Required]
        public long SupplierId { get; set; }
        [Display(Name = "ATTN")]
        public string Attn { get; set; }

        [Display(Name = "LC Number")]
        [Required]
        public double LcNumber { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [Display(Name = "LC Date")]
        public DateTime LcDate { get; set; }

        [Display(Name = "PO Number")]
        [Required]
        public double PoNumber { get; set; }

        [Display(Name = "Total Amount")]
        public double? TotalAmount { get; set; }

        [Display(Name = "Discount Amount")]
        public double? DiscountAmount { get; set; }

        [Display(Name = "Discount Percent")]
        public double? DiscountPercent { get; set; } = 0;

        [Display(Name = "Vat Amount")]
        public double? VatAmount { get; set; }

        [Display(Name = "Vat Percent")]
        public double? VatPercent { get; set; } = 0;

        [Display(Name = "Payment Amount")]
        public double? PaymentAmount { get; set; }

        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        public bool Cancle { get; set; }
        public string Remarks { get; set; }
        public Supplier Supplier { get; set; }
        public virtual List<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
    }
}
