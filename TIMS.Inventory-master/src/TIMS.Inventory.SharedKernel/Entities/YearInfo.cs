﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using TIMS.Inventory.SharedKernel.Common;
namespace TIMS.Inventory.SharedKernel.Entities;

public class YearInfo:AuditableEntity
{
    public int YearId { get; set; }

    public int? YearCode { get; set; }

    public string OpeningField { get; set; }

    public DateTimeOffset? StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public string Description { get; set; }
}