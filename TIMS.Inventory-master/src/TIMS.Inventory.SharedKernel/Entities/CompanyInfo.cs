﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using TIMS.Inventory.SharedKernel.Common;

namespace TIMS.Inventory.SharedKernel.Entities;

public class CompanyInfo:AuditableEntity
{
    public int BranchId { get; set; }

    public string CompanyName { get; set; } =string.Empty;

    public string BranchName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Fax { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Web { get; set; } = string.Empty;

    public string ContactPerson { get; set; } = string.Empty;
}