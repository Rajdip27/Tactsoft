

using TIMS.Inventory.SharedKernel.Common;

namespace TIMS.Inventory.Infrastructure.Models;

public  class VoucherType:AuditableEntity
{
    public int VoucherTypeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Abbr { get; set; } = string.Empty;
}